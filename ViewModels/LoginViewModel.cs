using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name ="Kullanıcı maili")]
        [EmailAddress]
        public string Email{ get; set; }

        [Required]
        [Display(Name = "Şifreniz")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Şifreniz en az 6 karakterden oluşmalıdır")]
        public string Password{ get; set; }
    }
}
