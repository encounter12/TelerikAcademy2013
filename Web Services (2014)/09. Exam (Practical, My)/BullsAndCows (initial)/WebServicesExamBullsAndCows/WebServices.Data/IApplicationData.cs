namespace WebServices.Data
{
    using System;
    using System.Linq;
    using WebServices.Data.Repositories;
    using WebServices.Models;

    public interface IApplicationData
    {
        IRepository<User> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }

        void SaveChanges();
    }
}
