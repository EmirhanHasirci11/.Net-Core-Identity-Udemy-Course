using IdentityUdemyCourse.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Kullanıcı ismi gereklidir!")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
        [Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "email adresi gereklidir!")]
        [Display(Name = "Email adresiniz")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi girdiğinizden emin olunuz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir!")]
        [Display(Name = "Şifreniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Şehir")]        
        public string City { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Cinsiyet")]
        public Gender Gender { get; set; }        
        public string Picture { get; set; }
    }
}
