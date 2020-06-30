using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ispit_zadaca1.Models
{
    public class MVCFacultyContext : DbContext
    {
        public MVCFacultyContext(DbContextOptions<MVCFacultyContext> options) : base(options)
        {

        }

        public DbSet<Student> students { get; set; }

        public DbSet<Labvezba> vezbi { get; set; }

        public DbSet<Studentlab> studentlabs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Studentlab>().HasOne<Student>(p => p.student)
                 .WithMany(p => p.vezbi).HasForeignKey(p => p.studentId);

            modelBuilder.Entity<Studentlab>().HasOne<Labvezba>(p => p.vezba)
                .WithMany(p => p.studenti).HasForeignKey(p => p.labvezbaId);
        }
    }
}
