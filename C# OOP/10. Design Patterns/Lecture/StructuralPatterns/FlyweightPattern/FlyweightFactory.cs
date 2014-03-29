using System.Collections.Generic;

namespace FlyweightPattern
{
    public class FlyweightFactory
    {
        private IDictionary<string, ChatRoom> availableChatRooms;

        public FlyweightFactory()
        {
            this.availableChatRooms = new Dictionary<string, ChatRoom>();
        }

        public ChatRoom GetChatRoom(string chatRoomName, User currentUser)
        {
            ChatRoom requestedChatRoom;
            if (!availableChatRooms.ContainsKey(chatRoomName))
            {
                requestedChatRoom = new ChatRoom(chatRoomName, currentUser);
                availableChatRooms.Add(chatRoomName, requestedChatRoom);
            }
            else
            {
                requestedChatRoom = availableChatRooms[chatRoomName];
                requestedChatRoom.AddParticipants(currentUser);
            }

            return requestedChatRoom;
        }

        public IEnumerable<ChatRoom> GetAvailableChatRooms()
        {
            return this.availableChatRooms.Values;
        }
    }
}