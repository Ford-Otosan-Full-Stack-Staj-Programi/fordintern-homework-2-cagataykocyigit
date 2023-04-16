using Homework2.Base.Attribute;
using Homework2.Base.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Dto.Dto
{
    public class AccountDto : BaseDto
    {
        [Required]
        [MaxLength(125)]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
       // [PasswordAttribute]
        public string Password { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        //[RoleAttribute]
        public string Role { get; set; }

        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
