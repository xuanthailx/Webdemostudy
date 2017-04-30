using System.ComponentModel.DataAnnotations;
namespace Demostudyweb.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = " Email  ")]
        public string eMail { set; get; }
        [Required(ErrorMessage = " Passwork ")]
        public string PassWord { set; get; }
        public string UserRole { set; get; }
        public bool RememberMe { set; get; }

        
    }
}