using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteTestBack.ViewModels
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Поле Номер телефона является обязательным!")]
        [Display(Name = "Номер телефона")]
        [MaxLength(11, ErrorMessage = "Максимальная длина строки 11 символов!")]
        [RegularExpression(@"^7+\d{10}", ErrorMessage = "Номер телефона должен соответствовать формату!")]
        public string Phone { get; set; }


        [Required(ErrorMessage = "Поле Пароль является обязательным!")]
        [Display(Name = "Пароль")]
        [MaxLength(20, ErrorMessage = "Максимальная длина строки 20 символов!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
