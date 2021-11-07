using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = "";
        [Required]
        public string LastName { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";

        public List<Group>? Groups { get; set; } = new();
    }
}
