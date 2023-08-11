namespace Beekeeping.Common.NotificationMessages
{
    public static class ErrorMessages
    {
        public const string FieldMinAndMaxStringLenghtErrorMessage = "Полето трябва да съдържа между {2} и {1} символа.";

        public const string FieldMinAndMaxRangeValueErrorMessage = "Полето трябва да съдържа между {1} и {2} символа.";

        public const string RequiredFieldErrorMessage = "Полето е задължително.";

        public const string StringRequirmentFieldsErrorMessage = "Полето може да съдържа само големи и малки букви, цифри или символите -.,;():.";

        public const string CommonErrorMessage = "Възникна неочаквана грешка. Моля, свържете се с нас или опитайте по-късно.";

        public const string NotAuthorizedErrorMessage = "Нямате достъп до тази страница!";

        public const string PasswordRegexErrorMessage = "Полето трябва да съдържа поне една главна буква и цифра.";

        public const string ConfirmPasswordErrorMessage = "Двете пароли трябва да съвпадат.";

        public const string EmailIsNotValidErrorMessage = "Невалиден email.";

    }
}