using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApp.Backend.User.Domain.Models
{
    internal class User
    {
        [Key]
        [Column("user_id")]
        public Guid UserId { get; private set; }
        [Required]
        [MaxLength(50)]
        [Column("first_name")]
        public string FirstName { get; private set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        [Column("last_name")]
        public string LastName { get; private set; } = string.Empty;
        [Required, MaxLength(50)]
        [DataType(DataType.EmailAddress)]
        [Column("email")]
        public string Email { get; private set; } = string.Empty;
        [Required, MinLength(6)]
        [DataType(DataType.Password)]
        [Column("password")]
        public string Password { get; private set; } = string.Empty;

    }
}
