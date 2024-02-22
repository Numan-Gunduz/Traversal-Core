using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
	public class SendContactUsValidator:AbstractValidator<SendMessageDTO>
	{
        public SendContactUsValidator()
        {
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Alanı Boş Geçemezsiniz!");
			RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Alanı Boş Geçilemez!");
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Geçilemez!");
			RuleFor(x => x.MessageBody).NotEmpty().WithMessage("İsim Alanı Geçilemez!");
			RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Konu Alanına en az 5 karakter veri girişi yapmalısınız!");
			RuleFor(x => x.Subject).MaximumLength(200).WithMessage("Konu Alanına en fazla 200 karakter veri girişi yapmalısınız!(5-200)");
		
		}
    }
}
