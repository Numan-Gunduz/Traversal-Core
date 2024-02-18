using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Lütfen Rehberin Adını Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen Rehber Açıklamasını Giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Rehberin Görselini Giriniz");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("İsim Değeri Maximum 30 karakter olmalıdır");
            RuleFor(x => x.Name).MinimumLength(4).WithMessage("İsim Değeri Minimum 4 karakter olmalıdır");
        }
    }
}
