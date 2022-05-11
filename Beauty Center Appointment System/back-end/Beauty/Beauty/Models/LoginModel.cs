using System.ComponentModel.DataAnnotations;

namespace Beauty.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
