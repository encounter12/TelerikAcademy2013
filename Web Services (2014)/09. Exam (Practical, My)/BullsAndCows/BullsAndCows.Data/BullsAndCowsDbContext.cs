namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using BullsAndCows.Data.Migrations;
    using BullsAndCows.Models;

    public class BullsAndCowsDbContext : IdentityDbContext<User>, IBullsAndCowsDbContext
    {
        public BullsAndCowsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }
        public IDbSet<Guess> Guesses { get; set; }
        public IDbSet<Notification> Notifications { get; set; }


        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }


        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
