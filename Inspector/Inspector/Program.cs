using Inspector.DataAccess.Data;
using Inspector.DataAccess.Repository;
using Inspector.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Inspector.Utility;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();


builder.Services.ConfigureApplicationCookie(option =>
{
    option.LoginPath = $"/Identity/Account/Login";
    option.LogoutPath = $"/Identity/Account/Logout";
    option.AccessDeniedPath = $"/Identity/Account/AccessDenied";
});

builder.Services.AddControllersWithViews()
	.AddNewtonsoftJson(options =>
	options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.AddRazorPages();
builder.Services.AddScoped<IComplaintRepository, ComplaintRepository>();
builder.Services.AddScoped<IOrganizationRepository, OrganizationRepository>();
builder.Services.AddScoped<IResponceRepository, ResponceRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IComplaintFileRepository, ComplaintFileRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Complaint/Error"); //was home/
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();

app.Use(async (context, next) =>
{
    if (context.User.IsInRole(SD.Role_Comp))
    {
        // Встановити маршрут для компаній
        context.GetRouteData().Values["area"] = "Organization";/*
        context.GetRouteData().Values["controller"] = "Complaint";*/
    }
    else if (context.User.IsInRole(SD.Role_Cust))
    {
        // Встановити маршрут для інших користувачів
        context.GetRouteData().Values["area"] = "Customer";/*
        context.GetRouteData().Values["controller"] = "Complaint";*/
    }

    else if (context.User.IsInRole(SD.Role_Empl))
    {
        context.GetRouteData().Values["area"] = "Employee";
    }

	else if (context.User.IsInRole(SD.Role_Admin))
	{
		context.GetRouteData().Values["area"] = "Admin";
	}

	await next();
});

app.MapControllerRoute(
	name: "default",
	pattern: "{area=User}/{controller=Complaint}/{action=Index}/{id?}");

app.Run();
