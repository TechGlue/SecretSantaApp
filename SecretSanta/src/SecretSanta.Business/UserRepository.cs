using System;
using System.Collections.Generic;
using System.Linq;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class UserRepository : IUserRepository
    {
        private SecretSantaContext Context = new SecretSantaContext();


        public User Create(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }

            Context.Users.Add(item);
            Context.SaveChanges();
            return item;
        }

        public User? GetItem(int id)
            => List().FirstOrDefault<User>(i => i.Id == id);

        public ICollection<User> List()
            => Context.Users
                .ToList();
        
        
        public bool Remove(int id)
        {
            User item = Context.Users.Find(id);
            
            if (item is null)
            {
                return false;
            }

            Context.Users.Remove(item);
            Context.SaveChanges();
            return true;
        }

        public void Save(User item)
        {
            if (item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }
            Context.Users.Update(item);
            Context.SaveChanges();
        }
    }
}
