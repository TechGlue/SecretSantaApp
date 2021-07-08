using System.Collections.Generic;
using System.Linq;

namespace SecretSanta.Data
{
    public class DbInitializer
    {
        public static List<User> Users()
        {
            return new List<User>
            {
                new User() {Id = 1, FirstName = "Luis", LastName = "Garcia"},
                new User(){ Id = 2, FirstName = "Jeff", LastName = "Kapplan"},
                new User(){ Id = 3, FirstName = "Terry", LastName = "Crews"}
            };
        }

        public static List<Group> Groups()
        {
            return new List<Group>()
            {
                new Group() {Id = 1, Name = "Pedro's pizza"}, new Group() {Id = 2, Name = "Pedro's Diner"},
            };
        }
    }
}