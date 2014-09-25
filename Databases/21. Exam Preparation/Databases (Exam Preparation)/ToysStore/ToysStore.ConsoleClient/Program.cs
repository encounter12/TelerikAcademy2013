namespace ToysStore.ConsoleClient
{
    using System;
    using System.Linq;
    using ToysStore.Data;

    public class Program
    {
        public static void Main()
        {
            using (var db = new ToysStoreEntities())
            {
                db.SaveChanges();
            } 
        }
    }
}