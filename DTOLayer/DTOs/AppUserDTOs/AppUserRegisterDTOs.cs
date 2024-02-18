using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserRegisterDTOs
    {
        //[Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }


        //[Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string Surname { get; set; }


        //[Required(ErrorMessage = "Lütfen Kullanıcı Adınızı Giriniz")]
        public string UserName { get; set; }


        //[Required(ErrorMessage = "Lütfen Mail Adresini Giriniz")]
        public string Email { get; set; }

        //[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz")]
        public string Password { get; set; }

        //[Required(ErrorMessage = "Lütfen Şifreyi Tekrar Giriniz")]

        //[Compare("Password", ErrorMessage = "Şifreler Uyumlu Değil!")]
        public string ConfirmPassword { get; set; }
    }
}
