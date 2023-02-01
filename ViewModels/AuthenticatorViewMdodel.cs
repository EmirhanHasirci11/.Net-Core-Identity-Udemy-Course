using IdentityUdemyCourse.Enums;
using System.ComponentModel.DataAnnotations;

namespace IdentityUdemyCourse.ViewModels
{
    public class AuthenticatorViewMdodel
    {
        public string SharedKey{ get; set; }
        public string AuthenticationUrl{ get; set; }
        [Required(ErrorMessage ="Doğrulama Kodu gereklidir")]
        [Display(Name ="Doğrulama Kodunuz")]
        public string VerificationCode{ get; set; }
        [Display(Name ="Doğrulama Tipiniz")]
        public TwoFactor TwoFactorType{ get; set; }
    }
}
