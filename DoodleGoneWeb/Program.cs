using DoodleGoneWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => {
    options.SignIn.RequireConfirmedAccount = false; options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    try
    {
        await SeedRolesAndUsers(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error seeding users: {ex.Message}");
    }
}

async Task SeedRolesAndUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
{
    Console.WriteLine("Starting user and role seeding..."); // Add this line

    if (!await roleManager.RoleExistsAsync("Administrator"))
        await roleManager.CreateAsync(new IdentityRole("Administrator"));

    if (!await roleManager.RoleExistsAsync("User"))
        await roleManager.CreateAsync(new IdentityRole("User"));

    string adminEmail = "eric@doodlegone.ca";
    string adminPassword = "Admin@1234";
    if (await userManager.FindByEmailAsync(adminEmail) == null)
    {
        var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
        var result = await userManager.CreateAsync(admin, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(admin, "Administrator");
            Console.WriteLine("Admin Created Successfully!!");
        }
        else
        {
            Console.WriteLine($"Error While Creating Admin {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    string user1Email = "bhumi@doodlegone.ca";
    string user1Password = "User@0709";
    if (await userManager.FindByEmailAsync(user1Email) == null)
    {
        var user1 = new IdentityUser { UserName = user1Email, Email = user1Email };
        var result = await userManager.CreateAsync(user1, user1Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user1, "User");
            Console.WriteLine("First User Created Successfully");
        }
        else
        {
            Console.WriteLine($"Error While Creating User 1: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }

    string user2Email = "vikas@doodlegone.ca";
    string user2Password = "Vika@4554";
    if (await userManager.FindByEmailAsync(user2Email) == null)
    {
        var user2 = new IdentityUser { UserName = user2Email, Email = user2Email };
        var result = await userManager.CreateAsync(user2, user2Password);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user2, "User");
            Console.WriteLine("Second User Created Successfully");
        }
        else
        {
            Console.WriteLine($"Error While Creating User 2: {string.Join(", ", result.Errors.Select(e => e.Description))}");
        }
    }
}


app.Run();
