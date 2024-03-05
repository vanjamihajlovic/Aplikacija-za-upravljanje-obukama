using CourseManagementApp.Middleware;
using CourseManagementApp.Model;
using CourseManagementApp.Options;
using CourseManagementApp.Persistence;
using CourseManagementApp.Service.Implementation;
using CourseManagementApp.Service.Inteface;
using CourseManagementApp.Util;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Configure swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Book Store API",
        Version = "v1",

    });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme."
    });

/*    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));*/
});

//  Configure database
IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
builder.Services.AddDbContext<CourseManagementDbContext>((sp, options) =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnectionString"));
});

// Configure dependency injection
builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddTransient<ExceptionMiddleware>();

// Configure identity
builder.Services.AddIdentity<User, IdentityRole>(o =>
{
    o.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<CourseManagementDbContext>()
.AddDefaultTokenProviders();

// Configure JWT
var jwtConfig = configuration.GetSection("JwtConfig");
var secretKey = jwtConfig["SecretKey"];
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtConfig["ValidIssuer"],
        ValidAudience = jwtConfig["ValidAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
    };
});

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
      .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
      .RequireAuthenticatedUser()
      .Build();
});

// Jwt Options
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(JwtOptions.JwtSection));
builder.Services.ConfigureOptions<JwtOptionsSetup>();

var app = builder.Build();

app.UseCors(builder => builder
        .WithOrigins("http://localhost:4200") // Replace with your Angular client app's URL
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());

app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
