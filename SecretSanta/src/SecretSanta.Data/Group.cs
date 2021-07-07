using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Data
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required] 
        public string Name { get; set; } = "";
        public List<User> Users { get; } = new();
        public List<Assignment> Assignments { get;} = new();
    }
}
