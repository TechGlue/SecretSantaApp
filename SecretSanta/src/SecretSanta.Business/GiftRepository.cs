using System;
using System.Collections.Generic;
using System.Linq;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class GiftRepository : IGiftRepository
    {
        private SecretSantaContext Context = new SecretSantaContext();

        public Gift Create(Gift item)
        {
            if(item is null)
            {
                throw new System.ArgumentException(nameof(item));
            }
            Context.Gifts.Add(item);
            Context.SaveChanges();
            return item;
        }

        public Gift? GetItem(int id)
            => List().FirstOrDefault<Gift>(i => i.Id == id);

        public ICollection<Gift> List()
            => Context.Gifts
                .ToList();

        public bool Remove(int id)
        {
            Gift item = Context.Gifts.Find(id);

            if(item is null)
            {
                return false;
            }

            Context.Gifts.Remove(item);
            Context.SaveChanges();
            return true;
        }

        public void Save(Gift item)
        {
            if(item is null)
            {
                throw new System.ArgumentNullException(nameof(item));
            }
            Context.Gifts.Update(item);
            Context.SaveChanges();
        }
    }
}
