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
        public List<Group>? Groups { get; } = new();
    }
}
