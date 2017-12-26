using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(50)]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(100)]
        public string Displayname { get; set; }

    }
}