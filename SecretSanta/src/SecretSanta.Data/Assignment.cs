using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace SecretSanta.Data
{
    public class Assignment
    {
        [Key]
        public int id { get; set; }
        public User Giver { get; set; }
        public User Receiver { get; set; }
        public Group Group { get; set; }

        public Assignment(User giver, User recipient, Group group)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));
            Group = group ?? throw new ArgumentNullException(nameof(group));
        }

        public Assignment()
        {}
    }
}
