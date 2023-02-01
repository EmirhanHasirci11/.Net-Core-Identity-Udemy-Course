using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityUdemyCourse.ViewModels
{
    public class RoleViewModel
    {
        [Required(ErrorMessage ="Rol ismi gereklidir")]
        [Display(Name="Rol ismi")]
        public string Name{ get; set; }
        public string Id{ get; set; }
    }
}
