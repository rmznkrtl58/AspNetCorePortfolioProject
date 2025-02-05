using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PortfolioValidator:AbstractValidator<Portfolio>
    {
        public PortfolioValidator()//ctor
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Proje Adı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("Proje Adı En Az 4 karakter olmalıdır");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Proje Adı En Az 4 karakter olmalıdır");
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Proje Platformu Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat Alanı Boş Geçilemez");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Değer Alanı Boş Geçilemez");
        }
    }
}
