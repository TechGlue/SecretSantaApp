using System;
using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Data
{
    public class Assignment
    {
        [Key]
        public int id { get; set; }
        public User Giver { get; }
        public User Receiver { get; }
        public String Giver_Receiver { get; set; }

        public Assignment(User giver, User recipient)
        {
            Giver = giver ?? throw new ArgumentNullException(nameof(giver));
            Receiver = recipient ?? throw new ArgumentNullException(nameof(recipient));

            Giver_Receiver = giver.FirstName + " " + recipient.LastName;
        }

        public Assignment()
        {
            Giver = new User();
            Receiver = new User();
        }
        
        
    }
}
