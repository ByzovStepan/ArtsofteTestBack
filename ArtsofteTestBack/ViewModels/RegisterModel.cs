using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArtsofteTestBack.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Поле ФИО является обязательным!")]
        [Display(Name = "ФИО")]
        [MaxLength(250, ErrorMessage = "Максимальная длина строки 250 символов!")]
        public string FIO { get; set; }

        [Required(ErrorMessage = "Поле Номер телефона является обязательным!")]
        [Display(Name = "Номер телефона")]
        [MaxLength(11, ErrorMessage = "Максимальная длина строки 11 символов!")]
        [RegularExpression(@"^7+\d{10}", ErrorMessage = "Номер телефона должен соответствовать формату!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Поле Email является обязательным!")]
        [Display(Name = "Email")]
        [MaxLength(150, ErrorMessage = "Максимальная длина строки 150 символов!")]
        [EmailAddress(ErrorMessage = "Email должен соответствовать формату!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле Пароль является обязательным!")]
        [Display(Name = "Пароль")]
        [MaxLength(20, ErrorMessage = "Максимальная длина строки 20 символов!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле Подтверждение пароля является обязательным!")]
        [Display(Name = "Подтверждение пароля")]
        [MaxLength(20, ErrorMessage = "Максимальная длина строки 20 символов!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

    }
}
