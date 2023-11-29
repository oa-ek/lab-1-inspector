using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Inspector.Utility;
using Inspector.Domain.Entities;

namespace Inspector.Domain.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
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
        public DbSet<ComplaintFile> ComplaintFiles { get; set; }
        public DbSet<Employment> Employments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.UserGive)
                .WithMany(u => u.AssignmentsGiven)
                .HasForeignKey(a => a.UserGiveId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Assignment>()
                .HasOne(a => a.UserTake)
                .WithMany(u => u.AssignmentsTaken)
                .HasForeignKey(a => a.UserTakeId)
                .OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Complaint>()
				.HasOne(c => c.Organization)
				.WithMany()
				.HasForeignKey(c => c.OrganizationId);


		/*modelBuilder.Entity<Complaint>()
			.HasOne(c => c.User)
			.WithMany(u => u.Complaints)
			.HasForeignKey(c => c.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Organization>()
			 .HasMany(o => o.ApplicationUsers) 
			 .WithOne(u => u.Organization) 
			 .HasForeignKey(u => u.OrganizationId) 
			 .OnDelete(DeleteBehavior.Restrict); 

		modelBuilder.Entity<Complaint>()
		   .HasMany(c => c.ComplaintFiles)
		   .WithOne(cf => cf.Complaint)
		   .HasForeignKey(cf => cf.ComplaintId);*/

		modelBuilder.Entity<Complaint>().HasData(
				new Complaint { Id = Guid.NewGuid(), Description = "There are problem with road", IsArchive = false, OrganizationId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"), UserId="1" },
				new Complaint { Id = Guid.NewGuid(), Description = "There are problem with water", IsArchive = false, OrganizationId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"), UserId = "1" },
				new Complaint { Id = Guid.NewGuid(), Description = "There are problem with helth", IsArchive = false, OrganizationId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"), UserId = "1" }
				);

			modelBuilder.Entity<IdentityRole>().HasData(
				 new IdentityRole
				 {
					 Id = "1",
					 Name = SD.Role_Admin,
					 NormalizedName = SD.Role_Admin.ToUpper(),
					 ConcurrencyStamp = Guid.NewGuid().ToString()
				 },
				 new IdentityRole
				 {
					 Id = "2",
					 Name = SD.Role_Cust,
					 NormalizedName = SD.Role_Cust.ToUpper(),
					 ConcurrencyStamp = Guid.NewGuid().ToString()
				 },
				 new IdentityRole
				 {
					 Id = "3",
					 Name = SD.Role_Comp,
					 NormalizedName = SD.Role_Comp.ToUpper(),
					 ConcurrencyStamp = Guid.NewGuid().ToString()
				 },
				 new IdentityRole
				 {
					 Id = "4",
					 Name = SD.Role_Empl,
					 NormalizedName = SD.Role_Empl.ToUpper(),
					 ConcurrencyStamp = Guid.NewGuid().ToString()
				 });


			modelBuilder.Entity<IdentityUserRole<string>>().HasData(
				new IdentityUserRole<string> { UserId = "1", RoleId = "1" });

			modelBuilder.Entity<Organization>().HasData(
				  new Organization { Id = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"), Name = "Road Organization", Description = "Solves problems related to the road surface" }
				  );

			modelBuilder.Entity<ApplicationUser>().HasData(
				new ApplicationUser
				{
					Id = "1",
					FullName = "Jane Smith",
					Email = "admin@gmail.com",
					PhoneNumber = "123-456-7890",
					OrganizationId = new Guid("6F9619FF-8B86-D011-B42D-00CF4FC964FF"),
					UserName = "admin@gmail.com",
					NormalizedUserName = "ADMIN@GMAIL.COM",
					NormalizedEmail = "ADMIN@GMAIL.COM",
					EmailConfirmed = true,
					PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123!")
				});

			/*  modelBuilder.Entity<Organization>().HasData(
				  new Organization { Id = 1, Name = "Road Organization", Description = "Solves problems related to the road surface" },
				  new Organization { Id = 2, Name = "Water Organization", Description = "Solves problems related to water supply" },
				  new Organization { Id = 3, Name = "Health Organization", Description = "Solves problems related to the violation of health care rights" }
				  );

			  modelBuilder.Entity<Category>().HasData(
				  new Category { Id = 1, Name = "A hole in the road", Description = "A hole in the road", OrganizationId = 1 },
				  new Category { Id = 2, Name = "Broke the pipe", Description = "broke the pipe", OrganizationId = 2 },
				  new Category { Id = 3, Name = "Smoking", Description = "Smoking", OrganizationId = 3 }
				  );

			  modelBuilder.Entity<ApplicationUser>().HasData(
				  new ApplicationUser
				  {
					  Id = "1",
					  FullName = "Jane Smith",
					  Email = "admin@gmail.com",
					  PhoneNumber = "123-456-7890",
					  OrganizationId = 1,
					  UserName = "admin@gmail.com",
					  NormalizedUserName = "ADMIN@GMAIL.COM",
					  NormalizedEmail = "ADMIN@GMAIL.COM",
					  EmailConfirmed = true,
					  PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Admin123!")
				  },
				  new ApplicationUser
				  {
					  Id = "2",
					  FullName = "John Doe",
					  Email = "user@gmail.com",
					  PhoneNumber = "123-456-7890",
					  OrganizationId = null,
					  UserName = "user@gmail.com",
					  NormalizedUserName = "USER@GMAIL.COM",
					  NormalizedEmail = "USER@GMAIL.COM",
					  EmailConfirmed = true,
					  PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "User123!")
				  },
				  new ApplicationUser
				  {
					  Id = "3",
					  FullName = "Road Organization",
					  Email = "roadorg@gmail.com",
					  PhoneNumber = "123-456-7890",
					  OrganizationId = 1,
					  UserName = "roadorg@gmail.com",
					  NormalizedUserName = "ROADORG@GMAIL.COM",
					  NormalizedEmail = "ROADORG@GMAIL.COM",
					  EmailConfirmed = true,
					  PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Roadorg123!")
				  },
				  new ApplicationUser
				  {
					  Id = "4",
					  FullName = "Bob Smith",
					  Email = "employee@gmail.com",
					  PhoneNumber = "123-456-7890",
					  OrganizationId = 1,
					  UserName = "employee@gmail.com",
					  NormalizedUserName = "EMPLOYEE@GMAIL.COM",
					  NormalizedEmail = "EMPLOYEE@GMAIL.COM",
					  EmailConfirmed = true,
					  PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null, "Employee123!")
				  },
				  new ApplicationUser
				  {
					  Id = "5",
					  FullName = "none",
					  OrganizationId = null,
					  Email = "-",
					  PhoneNumber = "-"
				  });

			  modelBuilder.Entity<IdentityRole>().HasData(
				  new IdentityRole
				  {
					  Id = "1",
					  Name = SD.Role_Admin,
					  NormalizedName = SD.Role_Admin.ToUpper(),
					  ConcurrencyStamp = Guid.NewGuid().ToString()
				  },
				  new IdentityRole
				  {
					  Id = "2",
					  Name = SD.Role_Cust,
					  NormalizedName = SD.Role_Cust.ToUpper(),
					  ConcurrencyStamp = Guid.NewGuid().ToString()
				  },
				  new IdentityRole
				  {
					  Id = "3",
					  Name = SD.Role_Comp,
					  NormalizedName = SD.Role_Comp.ToUpper(),
					  ConcurrencyStamp = Guid.NewGuid().ToString()
				  },
				  new IdentityRole
				  {
					  Id = "4",
					  Name = SD.Role_Empl,
					  NormalizedName = SD.Role_Empl.ToUpper(),
					  ConcurrencyStamp = Guid.NewGuid().ToString()
				  });


			  modelBuilder.Entity<IdentityUserRole<string>>().HasData(
				  new IdentityUserRole<string> { UserId = "1", RoleId = "1" },
				  new IdentityUserRole<string> { UserId = "2", RoleId = "2" },
				  new IdentityUserRole<string> { UserId = "3", RoleId = "3" },
				  new IdentityUserRole<string> { UserId = "4", RoleId = "4" });


			  modelBuilder.Entity<Complaint>().HasData(
				  new Complaint { Id = 1, UserId = "4", OrganizationId = 1, Description = "There are problem with road", IsArchive = false },
				  new Complaint { Id = 2, UserId = "4", OrganizationId = 2, Description = "There are problem with water", IsArchive = false },
				  new Complaint { Id = 3, UserId = "4", OrganizationId = 3, Description = "There are problem with helth", IsArchive = false }
				  );

			  modelBuilder.Entity<Responce>().HasData(
				  new Responce { Id = 1, Description = "Responce N1", ComplaintId = 1, CreatedDate = DateTime.Now },
				  new Responce { Id = 2, Description = "Responce N2", ComplaintId = 2, CreatedDate = DateTime.Now },
				  new Responce { Id = 3, Description = "Responce N2", ComplaintId = 3, CreatedDate = DateTime.Now }
				  );*/

		}
    }
}
