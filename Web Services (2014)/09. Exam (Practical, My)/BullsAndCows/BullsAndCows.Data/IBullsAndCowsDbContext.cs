namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using BullsAndCows.Models;

    public interface IBullsAndCowsDbContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Game> Games { get; set; }

        IDbSet<Notification> Notifications { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
