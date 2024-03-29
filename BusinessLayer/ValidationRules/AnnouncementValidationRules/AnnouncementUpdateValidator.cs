﻿using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
	public class AnnouncementUpdateValidator:AbstractValidator<AnnouncementUpdateDto>
	{
        public AnnouncementUpdateValidator()
        {
			RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen Başlık Bilgisini Doldurunuz");
			RuleFor(x => x.Content).NotEmpty().WithMessage("Lütfen Duyuru İçeriğini Doldurunuz");
			RuleFor(x => x.Title).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız(5-100)");
			RuleFor(x => x.Title).MaximumLength(100).WithMessage("Lütfen en fazla 100 karakter veri girişi yapınız(5-100)");
			RuleFor(x => x.Content).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakter veri girişi yapınız(5-500)");
			RuleFor(x => x.Content).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız(5-500)");
		}
    }
}
