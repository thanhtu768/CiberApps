using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ciber.ViewModels.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string  Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(a => a.UserName).NotEmpty().WithMessage("UserName is required");

            RuleFor(a => a.Password).NotEmpty().WithMessage("Password is required");
        }
    }
}
