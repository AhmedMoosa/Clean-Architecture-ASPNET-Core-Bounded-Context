using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Users.Core.DTOs
{
    public class InputUser
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Mobile { get; set; }
    }

    public class UserViewModel
    {
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Id { get; set; }
    }
}
