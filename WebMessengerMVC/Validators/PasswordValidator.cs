using System;
using WebMessengerMVC.Interfaces;

namespace WebMessengerMVC.Validators
{
    public class PasswordValidator : IValidator
    {
        private readonly string password;
        private readonly string repeatedPassword;

        public PasswordValidator(string password, string repeatedPassword)
        {
            this.password = password;

            this.repeatedPassword = repeatedPassword;
        }
        public bool Validate()
        {
            if (password == repeatedPassword)
                return true;
            else
                return false;
        }
    }
}
