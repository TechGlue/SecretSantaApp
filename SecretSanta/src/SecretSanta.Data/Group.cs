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

        [Required]
        public string Date { get; set; } = "";

        [Required]
        public string Time { get; set; } = "";

        [Required]
        public string Location { get; set; } = "";

        public List<User>? Users { get; set; } = new();
        public List<Assignment>? Assignments { get; set;} = new();
    }
}
