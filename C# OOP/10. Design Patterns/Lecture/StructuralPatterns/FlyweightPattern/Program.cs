using System;
using System.Linq;

namespace FlyweightPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            FlyweightFactory factory = new FlyweightFactory();

            DisplayAvailableChatRooms(factory);

            User troty = new User()
            {
                Id = 1,
                Nickname = "aJekov",
                Username = "KOCTEHYPKATA"
            };

            ChatRoom room = factory.GetChatRoom("bazukite", troty);

            User kravata = new User()
            {
                Id = 2,
                Nickname = "KOBAPHATA KPABA",
                Username = "kravata1900"
            };

            ChatRoom roomForKravata = factory.GetChatRoom("bazukite", kravata);

            DisplayAvailableChatRooms(factory);
        }

        private static void DisplayAvailableChatRooms(FlyweightFactory factory)
        {
            var chatRooms = factory.GetAvailableChatRooms();

            if (!chatRooms.Any())
            {
                Console.WriteLine("\nThere are currently no chat rooms available...");
                Console.WriteLine("Man up and create one!");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("".PadLeft(30, '='));
                Console.WriteLine("Chat Rooms:");

                foreach (var roomName in chatRooms)
                {
                    Console.WriteLine("{0} - {1} participants", roomName.Name, roomName.UsersCount());
                }
            }
        }
    }
}