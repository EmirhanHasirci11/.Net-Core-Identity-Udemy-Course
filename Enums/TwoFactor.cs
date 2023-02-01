using System.ComponentModel.DataAnnotations;

namespace IdentityUdemyCourse.Enums
{
    public enum TwoFactor
    {
        [Display(Name ="Hiçbiri")]
        None=0,
        [Display(Name ="Sms yöntemi")]
        Phone=1,
        [Display(Name ="Tek kullanımlık mail şifresi")]
        Email=2,
        [Display(Name ="Microsoft/Google Authentication uygulaması")]
        MicrosoftGoogle=3

    }
}
