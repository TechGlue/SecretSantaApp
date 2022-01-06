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
                new User() {Id = 99999, FirstName = "Luis", LastName = "Garcia", Email = "123@gmail.com"},
                new User(){ Id = 99998, FirstName = "Jeff", LastName = "Kapplan", Email = "123@gmail.com"},
                new User(){ Id = 99997, FirstName = "Terry", LastName = "Crews",  Email = "123@gmail.com"}
            };
        }

        public static List<Group> Groups()
        {
            return new List<Group>()
            {
                new Group() {Id = 1, Name = "Luis's pizza"}, new Group() {Id = 2, Name = "Luis's Diner"},
            };
        }

        public static List<Gift> Gifts()
        {
            return new List<Gift>()
            {
            };
        }
    }
}