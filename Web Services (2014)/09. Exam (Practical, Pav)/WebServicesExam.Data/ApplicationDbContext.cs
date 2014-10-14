namespace WebServicesExam.Data
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using WebServicesExam.Models;
    using WebServicesExam.Data.Migrations;
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("ApplicationConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public IDbSet<Game> Games { get; set; }

        public IDbSet<Guess> Guesses { get; set; }

        public IDbSet<Notification> Notifications { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            
            modelBuilder.Entity<Game>()
                        .HasRequired(g => g.BluePlayerGuesses)
                        .WithMany()
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Game>()
                        .HasRequired(g => g.RedPlayerGuesses)
                        .WithMany()
                        .WillCascadeOnDelete(false);
        }
        */
    }
}
