using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ApiCe.Core.Entites;

namespace ApiCe.Infra.Data
{
  public class AppDbContext(DbContextOptions<AppDbContext> options)
        : DbContext(options)
    {
        //DBset
        public DbSet<Course> Courses => Set<Course>();
        public DbSet<Student> Students => Set<Student>();
        public DbSet<Instructor> Instructors => Set<Instructor>();
        public DbSet<Enrollment> Enrollments => Set<Enrollment>();
        public DbSet<User> Users => Set<User>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(AppDbContext).Assembly
            );

            base.OnModelCreating(modelBuilder);
        }//عباره عن اني اعمل اي شي داخل الconfgrtion تلقايا من خلال هذا السطر من دون ما اضيف مرا اخرى هون 


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSeeding((context,_) =>
            {
                if(context.Set<Instructor>().Any())return; //هان اذاInstructor لا ترجع تضيف
               var Doha = new Instructor { FullName = "Doha Nasser", Title = "Dr." };
    var Sara = new Instructor { FullName = "Sara ALI", Title = "Prof." };
                context.Set<Course>().AddRange(
                    new Course {Title = "C# Fundamentals",Price=50,Instructor =Doha},
                  new Course {Title = "CSS Fundamentals",Price=40,Instructor =Sara}
                );
                context.SaveChanges();
                    
            }
            );
        }

    }
}