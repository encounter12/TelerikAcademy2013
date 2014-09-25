namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class ApplicationData : IBullsAndCowsData
    {
        private IBullsAndCowsDbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData()
            : this(new BullsAndCowsDbContext())
        {
        }

        public ApplicationData(IBullsAndCowsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                return this.GetRepository<Game>();
            }
        }

        public IRepository<Guess> Guesses
        {
            get
            {
                return this.GetRepository<Guess>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}
