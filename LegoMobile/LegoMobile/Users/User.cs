using System;
using System.Collections.Generic;
using System.Text;

namespace LegoMobile
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }

        public User(int id, string name, string email, string token)
        {
            Id = id;
            Name = name;
            Email = email;
            Token = token;
        }
    }
}
