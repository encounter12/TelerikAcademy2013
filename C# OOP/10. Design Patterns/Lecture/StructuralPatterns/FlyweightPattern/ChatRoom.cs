using System.Collections.Generic;
using System.Linq;

namespace FlyweightPattern
{
    public class ChatRoom
    {
        private ICollection<User> roomUsers;

        public string Name { get; protected set; }

        public ChatRoom(string roomName, User admin)
        {
            Name = roomName;

            roomUsers = new HashSet<User>();
            roomUsers.Add(admin);
        }

        public int UsersCount()
        {
            return this.roomUsers.Count();
        }

        public void AddParticipants(User currentUser)
        {
            if (!roomUsers.Contains(currentUser))
            {
                roomUsers.Add(currentUser);
            }
        }
    }
}