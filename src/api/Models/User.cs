using System;
using System.Linq;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Displayname { get; set; }

    }
}