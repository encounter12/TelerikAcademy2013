namespace WebServicesExam.Data
{
    using WebServicesExam.Data.Repositories;
    using WebServicesExam.Models;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> Users { get; }

        IRepository<Game> Games { get; }

        IRepository<Guess> Guesses { get; }

        IRepository<Notification> Notifications { get; }

        int SaveChanges();
    }
}
