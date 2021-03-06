using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SecretSanta.Data;

namespace SecretSanta.Business
{
    public class GroupRepository : IGroupRepository
    {
        //Instance of our context 
        private SecretSantaContext Context = new SecretSantaContext();
        public Group Create(Group item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Context.Groups.Add(item);
            Context.SaveChanges();
            return item;
        }

        public Group? GetItem(int id)
            => List().FirstOrDefault<Group>(i => i.Id == id);

        public ICollection<Group> List()
            => Context.Groups
                .Include(group => group.Users)
                .Include(group => group.Assignments)
                .ToList();

        public bool Remove(int id)
        {
            Group item = Context.Groups.Find(id);
            if (item is null)
                return false;
            
            Context.Groups.Remove(item);
            Context.SaveChanges();
            return true;
        }

        public void Save(Group? item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            Context.Groups.Update(item);
            Context.SaveChanges();
        }

        public AssignmentResult GenerateAssignments(int groupId)
        {
            Group? @group = GetItem(groupId);

            if (group is null)
            {
                return AssignmentResult.Error("Group not found");
            }

            Random random = new();
            var groupUsers = new List<User>(group.Users.ToList());

            if (groupUsers.Count < 3)
            {
                return AssignmentResult.Error($"Group {group.Name} must have at least three users");
            }

            var users = new List<User>();

            while (groupUsers.Count > 0)
            {
                int index = random.Next(groupUsers.Count);
                users.Add(groupUsers[index]);
                groupUsers.RemoveAt(index);
            }

            group.Assignments.Clear();

            for (int i = 0; i < users.Count; i++)
            {
                int endIndex = (i + 1) % users.Count;
                User Giver = Context.Users.Find(users[i].Id);
                User Receiver = Context.Users.Find(users[endIndex].Id);

                Assignment newAssignment = new Assignment(Giver, Receiver, group);
                group.Assignments.Add(newAssignment);
            }

            Save(@group);
            return AssignmentResult.Success();
        }
    }
}
