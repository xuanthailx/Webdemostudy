using System.ComponentModel.DataAnnotations;
namespace Demostudyweb.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = " User name ")]
        public string UserName { set; get; }
        [Required(ErrorMessage = " Passwork ")]
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }
        
    }
}