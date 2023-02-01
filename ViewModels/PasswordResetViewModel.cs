using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.ViewModels
{
    public class PasswordResetViewModel
    {
        [Required]
        [Display(Name = "Kullanıcı maili")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
