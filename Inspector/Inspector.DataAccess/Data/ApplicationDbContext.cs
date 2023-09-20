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
        public DbSet<User> User { get; set; }

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

			modelBuilder.Entity<User>().HasData(
				new User
				{
					Id = 1,
					FullName = "John Doe",
					Email = "john@example.com",
					Phone = "123-456-7890",
					IsManager = false,
					IsEmployee = true
				},
				new User
				{
					Id = 2,
					FullName = "Jane Smith",
					Email = "jane@example.com",
					Phone = "987-654-3210",
					IsManager = true,
					IsEmployee = false
				},
				new User
				{
					Id = 3,
					FullName = "Bob Smith",
					Email = "bob@example.com",
					Phone = "666-666-6666",
					IsManager = false,
					IsEmployee = false
				},
				new User
				{
					Id = -1,
					FullName = "none",
					Email = "-",
					Phone = "-",
					IsManager = false,
					IsEmployee = false
				}
				);

			modelBuilder.Entity<Complaint>().HasData(
                new Complaint { Id = 1, UserId = 1, OrganizationId = 1, Description = "There are problem with road", IsArchive = false},
                new Complaint { Id = 2, UserId = 2, OrganizationId = 2, Description = "There are problem with water", IsArchive = false },
                new Complaint { Id = 3, UserId = 3, OrganizationId = 3, Description = "There are problem with helth", IsArchive = false }
                );

            modelBuilder.Entity<Responce>().HasData(
                new Responce { Id = 1, Description = "Responce N1", ComplaintId = 1, CreatedDate = DateTime.Now},
                new Responce { Id = 2, Description = "Responce N2", ComplaintId = 2, CreatedDate = DateTime.Now},
                new Responce { Id = 3, Description = "Responce N2", ComplaintId = 3, CreatedDate = DateTime.Now}
                );

            
        }
    }
}
