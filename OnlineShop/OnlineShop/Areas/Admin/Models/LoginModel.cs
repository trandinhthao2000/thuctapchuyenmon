using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Key]
        [Required(ErrorMessage = "Moi ban nhap username")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Moi ban nhap password")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}