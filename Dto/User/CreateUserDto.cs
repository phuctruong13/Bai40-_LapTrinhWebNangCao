using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace blogAPI.Dto.User
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Không được bỏ trống tên")]
        [DataType(DataType.Text)]
        public String DisplayName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]

        [EmailAddress]
        public String Email { get; set; }
        public String Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
    }
}