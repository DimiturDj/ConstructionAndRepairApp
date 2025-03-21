using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RepairAndConstructionService.Data;

var builder = WebApplication.CreateBuilder(args);

// Configure database connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity services with roles
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
})
.AddRoles<IdentityRole>()  // Enables role-based authentication
.AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); // Enable Authentication Middleware
app.UseAuthorization();

// Enable MVC routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Enable Identity Razor Pages (Login, Register, Logout)
app.MapRazorPages();

// Automatically Seed Worker Account
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    await SeedWorker(userManager, roleManager);
}

app.Run();

async Task SeedWorker(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    string workerEmail = "worker@service.com";
    string workerPassword = "Worker123!";

    // Ensure "Worker" role exists
    if (!await roleManager.RoleExistsAsync("Worker"))
    {
        await roleManager.CreateAsync(new IdentityRole("Worker"));
    }

    // Check if the worker user already exists
    if (await userManager.FindByEmailAsync(workerEmail) == null)
    {
        var worker = new IdentityUser { UserName = workerEmail, Email = workerEmail, EmailConfirmed = true };
        await userManager.CreateAsync(worker, workerPassword);
        await userManager.AddToRoleAsync(worker, "Worker");
    }
}
async Task SeedAdmin(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    string AdminEmail = "admin@service.com";
    string AdminPassword = "Admin123!";

    // Ensure "Worker" role exists
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
    }

    // Check if the worker user already exists
    if (await userManager.FindByEmailAsync(AdminEmail) == null)
    {
        var admin = new IdentityUser { UserName = AdminEmail, Email = AdminEmail, EmailConfirmed = true };
        await userManager.CreateAsync(admin, AdminPassword);
        await userManager.AddToRoleAsync(admin, "Admin");
    }
}

