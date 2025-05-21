using Finance.Database.Context;
using Finance.Database.Factory;
using Finance.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Build.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<IDMContext>(options => options.UseSqlServer("Server=localhost;Database=IDM;Trusted_Connection=True;TrustServerCertificate=True"));
builder.Services.AddIdentity<AppUser, IdentityRole<Guid>>(options =>
{
    options.User.RequireUniqueEmail = true;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;  
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequiredLength = 1;
}).AddEntityFrameworkStores<IDMContext>()
  .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = "cookie";
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNgClient",
        builder => builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddScoped<AccountService>();

// Build App.
var app = builder.Build();

// Configure HTTP Pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Run App.
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseCors("AllowNgClient");
app.UseAuthorization();
app.MapControllers();  
app.Run();
