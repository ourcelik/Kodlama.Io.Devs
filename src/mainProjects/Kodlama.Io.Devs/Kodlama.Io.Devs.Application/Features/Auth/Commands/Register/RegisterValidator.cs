using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Kodlama.Io.Devs.Application.Features.Auth.Commands.Register
{
    public class RegisterValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı adı boş olamaz");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır");
            RuleFor(x => x.Password).MaximumLength(20).WithMessage("Şifre en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Username).MinimumLength(6).WithMessage("Kullanıcı adı en az 6 karakter olmalıdır");
            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Kullanıcı adı en fazla 20 karakter olmalıdır");
            RuleFor(x => x.Username).Matches("^[a-zA-Z0-9]*$").WithMessage("Kullanıcı adı sadece harf ve rakam içerebilir");
            RuleFor(x => x.Password).Matches("^[a-zA-Z0-9]*$").WithMessage("Şifre sadece harf ve rakam içerebilir");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email boş olamaz");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email formatı hatalı");
            RuleFor(x => x.Email).MaximumLength(50).WithMessage("Email en fazla 50 karakter olmalıdır");
            RuleFor(x => x.Email).MinimumLength(6).WithMessage("Email en az 6 karakter olmalıdır");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş olamaz");
            RuleFor(x => x.FirstName).MaximumLength(50).WithMessage("Ad en fazla 50 karakter olmalıdır");
            RuleFor(x => x.FirstName).MinimumLength(2).WithMessage("Ad en az 2 karakter olmalıdır");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyad boş olamaz");
            RuleFor(x => x.LastName).MaximumLength(50).WithMessage("Soyad en fazla 50 karakter olmalıdır");
            RuleFor(x => x.LastName).MinimumLength(2).WithMessage("Soyad en az 2 karakter olmalıdır");
        }

    }
}