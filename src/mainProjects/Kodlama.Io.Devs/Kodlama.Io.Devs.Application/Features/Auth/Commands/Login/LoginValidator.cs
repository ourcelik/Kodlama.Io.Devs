using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.Io.Devs.Application.Features.Auth.Commands.Login
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Username).MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakter olmalıdır");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Username).Matches("^[a-zA-Z0-9]*$").WithMessage("Kullanıcı adı sadece harf ve rakam içerebilir");
            RuleFor(x => x.Password).Matches("^[a-zA-Z0-9]*$").WithMessage("Şifre sadece harf ve rakam içerebilir");
        }

    }
}