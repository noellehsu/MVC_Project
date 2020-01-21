using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcFormsAuthentication.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "姓名長度介於3-25個字元")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "密碼長度介於3-30個字元")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [NotMapped]
        [Compare("Password", ErrorMessage = "密碼不一致!")]
        public string ConfirmPassword { get; set; }
    }
}