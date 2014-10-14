namespace WebServices.Models
{
    using System;
    using System.Linq;

    public class Notification
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType Type { get; set; }

        public int GameId { get; set; }
    }
}
