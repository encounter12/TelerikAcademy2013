namespace WebServicesExam.WebApi.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using WebServicesExam.Models;

    public class NotificationModel
    {
        public static Expression<Func<Notification, NotificationModel>> FromNotification
        {
            get
            {
                return notification => new NotificationModel
                {
                    Id = notification.Id,
                    Message = notification.Message,
                    DateCreated = notification.DateCreated,
                    Type = notification.Type,
                    State = notification.State,
                    GameId = notification.Game.Id,
                };
            }
        }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public NotificationState State { get; set; }

        [Required]
        public int GameId { get; set; }
    }
}