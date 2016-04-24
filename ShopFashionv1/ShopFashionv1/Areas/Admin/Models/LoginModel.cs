using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopFashionv1.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Mời Bạn Nhập UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Mời Bạn Nhập PassWord")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}