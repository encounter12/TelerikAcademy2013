
﻿namespace TeamKyanite.SchoolObjects
 {
     using System;
     using System.Data.Entity;

     public class SchoolDatabaseContext : DbContext
     {
         public SchoolDatabaseContext()
         {
             Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolDatabaseContext>());
         }

         public DbSet<School> Schools { get; set; }
         public DbSet<SchoolClass> SchoolClasses { get; set; }
         public DbSet<Student> Students { get; set; }
         public DbSet<Subject> Subjects { get; set; }
         public DbSet<Teacher> Teachers { get; set; }

         public DbSet<Account> Accounts { get; set; }
         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Configurations.Add(new Account.AccountConfiguration());

             modelBuilder.Entity<Account>().HasKey(t => t.AccountId);


             modelBuilder.Entity<Human>().HasRequired(t => t.Account)
                 .WithRequiredPrincipal(p => p.Holder).WillCascadeOnDelete(true);
             base.OnModelCreating(modelBuilder);
         }
     }
 }
