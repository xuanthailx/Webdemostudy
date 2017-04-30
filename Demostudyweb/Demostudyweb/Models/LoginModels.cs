using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Demostudyweb.Models
{
    public class LoginModels
    { 
        [Key]
        [Display(Name="Tên đăng nhập" )]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        public string UserName { set; get; }
        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage ="Bận phải nhập mật khẩu")]
        public string Password { get; set; }
    }
}