namespace Beekeeping.Web.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;
    using Beekeeping.Data.Models;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;

    using static Beekeeping.Common.Validations.DataConstants.ApplicationUserValidations;
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
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [StringLength(PasswordMaxLength, MinimumLength = PasswordMinLength, ErrorMessage = "Паролата трябва да бъде между {2} и {1} символа")]
            [DataType(DataType.Password)]
            [Display(Name = "Парола")]
            public string Password { get; set; } = null!;

            [DataType(DataType.Password)]
            [Display(Name = "Повторете паролата")]
            [Compare("Password", ErrorMessage = "Двете пароли трябва да съвпадат!")]
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
