using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }
        public string Username { set; get; }
        public string Password { set; get; }
        public string FullName { set; get; }
        public string Address { set; get; }

    }
}
