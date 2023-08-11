namespace Beekeeping.Web.Areas.Identity.Pages.Account
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;

    using Data.Models;

    using static Beekeeping.Common.Validations.DataConstants.ApplicationUserValidations;
    using static Common.NotificationMessages.ErrorMessages;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [BindProperty]
        public InputModel Input { get; set; } = null!;

        public string ReturnUrl { get; set; } = null!;

        public class InputModel
        {
            [Required(ErrorMessage = RequiredFieldErrorMessage)]
            [EmailAddress(ErrorMessage = EmailIsNotValidErrorMessage)]
            public string Email { get; set; } = null!;

            [Required(ErrorMessage = RequiredFieldErrorMessage)]
            [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = StringRequirmentFieldsErrorMessage)]
            [DataType(DataType.Password)]
            [RegularExpression(RegularExpressionValidation, ErrorMessage = PasswordRegexErrorMessage)]
            [Display(Name = "Парола")]
            public string Password { get; set; } = null!;

            [Required(ErrorMessage = RequiredFieldErrorMessage)]
            [DataType(DataType.Password)]
            [Display(Name = "Повторете паролата")]
            [RegularExpression(RegularExpressionValidation, ErrorMessage = PasswordRegexErrorMessage)]
            [Compare("Password", ErrorMessage = ConfirmPasswordErrorMessage)]
            public string ConfirmPassword { get; set; } = null!;
        }

        public void OnGetAsync(string? returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email
                };

                var result = await this.userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    await this.signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Page();
        }
    }
}
