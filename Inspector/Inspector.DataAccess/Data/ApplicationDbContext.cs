using Inspector.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.DataAccess.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<Organization> Organization { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Responce> Responce { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
		public DbSet<Assignment> Assignment { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Assignment>()
				.HasOne(a => a.UserGive)
				.WithMany(u => u.AssignmentsGiven)
				.HasForeignKey(a => a.UserGiveId)
				.OnDelete(DeleteBehavior.Restrict); // Вимкнути каскадне видалення

			modelBuilder.Entity<Assignment>()
				.HasOne(a => a.UserTake)
				.WithMany(u => u.AssignmentsTaken)
				.HasForeignKey(a => a.UserTakeId)
				.OnDelete(DeleteBehavior.Restrict); // Вимкнути каскадне видалення

			modelBuilder.Entity<Complaint>()
				.HasOne(c => c.User)
				.WithMany(u => u.Complaints)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict); // Вим

            modelBuilder.Entity<Organization>()
				 .HasMany(o => o.ApplicationUsers) // Організація має багато користувачів
				 .WithOne(u => u.Organization) // Користувач має одну організацію
				 .HasForeignKey(u => u.OrganizationId) // Зовнішній ключ в користувачів
				 .OnDelete(DeleteBehavior.Restrict); // Визначте бажаний спосіб обробки видалення


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

			modelBuilder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Id = "1",
					FullName = "John Doe",
					Email = "john@example.com",
					Phone = "123-456-7890",
					OrganizationId = 1,
					IsManager = false,
					IsEmployee = true
				},
				new ApplicationUser
				{
					Id = "2",
					FullName = "Jane Smith",
					Email = "jane@example.com",
					Phone = "987-654-3210",
					OrganizationId = 1,
					IsManager = true,
					IsEmployee = false
				},
				new ApplicationUser
				{
					Id = "3",
					FullName = "Bob Smith",
					Email = "bob@example.com",
					Phone = "666-666-6666",
					IsManager = false,
					IsEmployee = false
				},
				new ApplicationUser
				{
					FullName = "none",
					Email = "-",
					Phone = "-",
					IsManager = false,
					IsEmployee = false
				}
				);

			modelBuilder.Entity<Complaint>().HasData(
                new Complaint { Id = 1, UserId = "1", OrganizationId = 1, Description = "There are problem with road", IsArchive = false},
                new Complaint { Id = 2, UserId = "2", OrganizationId = 2, Description = "There are problem with water", IsArchive = false },
                new Complaint { Id = 3, UserId = "3", OrganizationId = 3, Description = "There are problem with helth", IsArchive = false }
                );

            modelBuilder.Entity<Responce>().HasData(
                new Responce { Id = 1, Description = "Responce N1", ComplaintId = 1, CreatedDate = DateTime.Now},
                new Responce { Id = 2, Description = "Responce N2", ComplaintId = 2, CreatedDate = DateTime.Now},
                new Responce { Id = 3, Description = "Responce N2", ComplaintId = 3, CreatedDate = DateTime.Now}
                );

		}
    }
}
