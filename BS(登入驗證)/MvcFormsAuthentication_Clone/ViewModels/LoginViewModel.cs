using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace MvcFormsAuthentication_Clone.ViewModels
{
    public class LoginViewModel //這邊跟後端資料庫沒有關係，並不需要Add-Migration
    {
        //盡量讓前端去驗證，不要讓後端驗證
        [Required]  //不允許空白
        [Display(Name="帳號")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "帳號長度介於3-25個字元")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "密碼")]
        [DataType(DataType.Password)] //這個功能，會讓密碼輸入變成暗碼
        [StringLength(30,MinimumLength =3,ErrorMessage = "密碼長度介於3-30個字元")]
        public string Password { get; set; }
    }
}