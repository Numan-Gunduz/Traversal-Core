using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AppUserDTOs
{
    public class AppUserLoginDTOs
    {
        //[Required(ErrorMessage = "Lütfen Kullanıcı Adını Giriniz!")]
        public string username { get; set; }


        //[Required(ErrorMessage = "Lütfen Şifrenizi Giriniz!")]
        public string password { get; set; }
    }
}
