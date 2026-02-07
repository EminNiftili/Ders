using AutoMapper;
using DataAccess.EfImplementations;
using DataAccess.EfImplementations.Contexts;
using DataAccess.UnitOfWorks;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Web;
using Web.AutoMapper;
using Web.Dtos;
using Web.Filters;
using Web.Middlewares;
using Web.Validations;

var builder = WebApplication.CreateBuilder(args);

//Dependency Injection
// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    //options.Filters.Add<PerformanceFilter>();
});

builder.Services.AddScoped<PerformanceFilter>();
builder.Services.AddScoped<AgeFilter>();

builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddSession();
builder.Services.AddAuthentication("Cookies")
    .AddCookie(options =>
    {
        options.LoginPath = "/Authetication/login";
    });

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ClockSkew = TimeSpan.Zero,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration.GetSection("Jwt:Issuer").Value,
            ValidAudience = builder.Configuration.GetSection("Jwt:Audience").Value,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("Jwt:SecretKey").Value))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddAutoMapper(x =>
{
    x.AddProfile<PersonProfile>();
});
builder.Services.AddValidatorsFromAssembly(typeof(AddPersonValidation).Assembly);
//builder.Services.AddCors(options =>
//{
//    //options.AddPolicy("AllowAll", policy =>
//    //{
//    //    policy.AllowAnyHeader();
//    //    policy.AllowAnyMethod();
//    //    policy.AllowAnyOrigin();
//    //});

//    options.AddPolicy("OnlyGoogle", policy =>
//    {
//        policy.WithMethods("GET");
//        policy.WithOrigins("https://www.google.com");
//    });

//});

builder.Services.AddDbContext<DersDb2Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DersDb"));
});

// Transient -> Her zaman yeni EfUnitOfWork yaradacaq
// Scoped -> Her sorgu uchun yalniz bir dene EfUnitOfWork yarat 
// Singleton -> Proqarm ucun yalniz bir dene EfUnitOfWork yarat

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<GlobalExceptionMiddleware>();
//app.UseMiddleware<CountryCheckMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();


app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseCors("OnlyGoogle");

app.Run();
