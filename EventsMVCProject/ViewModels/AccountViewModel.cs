using System.ComponentModel.DataAnnotations;

namespace EventsMVCProject.ViewModels
{
    public class AccountViewModel
    {
        public int id { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email Address")]
        public string EmailId { get; set; }

        [DataType(DataType.Password)]
        [Required, MinLength(5)]
        public string Password { get; set; }


        public string FullName { get; set; }
    }
}