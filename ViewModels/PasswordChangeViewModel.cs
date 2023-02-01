using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Eski şifrenizi girmeniz zorunludur")]
        [Display(Name = "Eski şifreniz")]
        public string PasswordOld { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Yeni şifrenizi girmeniz zorunludur")]
        [Display(Name = "Yeni şifreniz")]
        public string PasswordNew { get; set; }
        [Required(ErrorMessage = "Yeni şifrenizi girmeniz zorunludur")]
        [DataType(DataType.Password)]
        [Display(Name = "Yeni şifrenizi yeniden giriniz")]
        [Compare("PasswordNew", ErrorMessage = "Yeni şifrenizi doğru girdiğinizden emin olun")]
        public string PasswordConfirm { get; set; }
    }
}
