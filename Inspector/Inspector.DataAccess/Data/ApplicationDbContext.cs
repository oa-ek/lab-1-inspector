using Inspector.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Responce> Responce { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organization>().HasData(
                new Organization { Id = 1, Name = "Road Organization", Description = "Solves problems related to the road surface" },
                new Organization { Id = 2, Name = "Water Organization", Description = "Solves problems related to water supply" },
                new Organization { Id = 3, Name = "Health Organization", Description = "Solves problems related to the violation of health care rights" }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "A hole in the road", Description = "A hole in the road", OrganizationId = 1 },
                new Category { Id = 2, Name = "Broke the pipe", Description = "broke the pipe", OrganizationId = 2},
                new Category { Id = 3, Name = "Smoking", Description = "Smoking", OrganizationId = 3 }
                );

            modelBuilder.Entity<Complaint>().HasData(
                new Complaint { Id = 1, UserName = "Oksana", OrganizationId = 1, Description = "There are problem with road"},
                new Complaint { Id = 2, UserName = "Anna", OrganizationId = 2, Description = "There are problem with water" },
                new Complaint { Id = 3, UserName = "Alex", OrganizationId = 3, Description = "There are problem with helth" }
                );

            modelBuilder.Entity<Responce>().HasData(
                new Responce { Id = 1, Name = "N1", Description = "Responce N1", ComplaintId = 1, CreatedDate = DateTime.Now},
                new Responce { Id = 2, Name = "N2", Description = "Responce N2", ComplaintId = 2, CreatedDate = DateTime.Now},
                new Responce { Id = 3, Name = "N3", Description = "Responce N2", ComplaintId = 3, CreatedDate = DateTime.Now}
                );
        }
    }
}
