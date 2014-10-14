namespace WebServicesExam.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public Notification()
        {
            this.State = NotificationState.Unread; 
        }

        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public int GameId { get; set; }

        public virtual Game Game { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public NotificationType Type { get; set; }

        [Required]
        public NotificationState State { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }
    }
}
