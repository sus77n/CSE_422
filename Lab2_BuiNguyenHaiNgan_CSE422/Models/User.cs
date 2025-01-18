using System.ComponentModel.DataAnnotations;

namespace Lab2_BuiNguyenHaiNgan_CSE422.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }

        [MaxLength(10)]
        public string PhoneNumber { get; set; }

        public User() { }
        public User(string fullname, string email, string role, string phonenumber)
        {
            FullName = fullname;
            Email = email;
            Role = role;
            PhoneNumber = phonenumber;
        }
    }
}
