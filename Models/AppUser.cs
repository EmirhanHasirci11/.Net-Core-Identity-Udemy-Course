using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using IdentityUdemyCourse.Enums;
using Microsoft.AspNetCore.Identity;
namespace IdentityUdemyCourse.Models
{
    public class AppUser:IdentityUser
    {
        [MaxLength(30,ErrorMessage ="Şehir bilgisi en fazla 30 karakterden oluşmalıdır")]
        public string City{ get; set; }
        [MaxLength(300,ErrorMessage ="Şehir bilgisi en fazla 30 karakterden oluşmalıdır")]
        [Display(Name ="Kullanıcı resmi")]
        public string Picture{ get; set; }        
        [Display(Name ="Doğum Tarihi")]
        public DateTime? BirthDate{ get; set; }
        [Display(Name ="Cinsiyet")]
        [Required(ErrorMessage ="Lütfen bir cinsiyet seçiniz")]
        public int Gender{ get; set; }
        public sbyte? TwoFactor { get; set; }

    }
}
