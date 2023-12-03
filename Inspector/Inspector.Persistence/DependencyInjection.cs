using Inspector.Application.Repositories;
using Inspector.Domain.Data;
using Inspector.Domain.Entities;
using Inspector.Persistence.Repositories;
using Inspector.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Persistence
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            /*builder.Services.AddDbContext<ApplicationDbContext>(option =>
            option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));*/

            var connectionString = configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string is null or empty.");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IComplaintRepository, ComplaintRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IOrganizationRepository, OrganizationRepository>();
			services.AddScoped<IFileRepository, FileRepository>();
			services.AddIdentity<IdentityUser, IdentityRole>()
	            .AddEntityFrameworkStores<ApplicationDbContext>()
	            .AddDefaultTokenProviders();
            services.AddTransient<IEmailSender, EmailSender>();

        }
	}
}
