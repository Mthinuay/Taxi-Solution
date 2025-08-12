using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Adingisa.Data;
using Adingisa.Services;
using Adingisa.Repositories;
using Adingisa.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Adingisa.Services.Interfaces;
using Adingisa.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IJwtService, JwtService>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IReplyService, ReplyService>();
builder.Services.AddScoped<IReplyRepository, ReplyRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
//builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<ITaxiRouteRepository, TaxiRouteRepository>();
builder.Services.AddScoped<ITaxiRouteService, TaxiRouteService>();
builder.Services.AddHttpClient<GoogleMapsService>();
builder.Services.AddScoped<ITaxiLocationRepository, TaxiLocationRepository>();
builder.Services.AddScoped<ITaxiLocationService, TaxiLocationService>();
builder.Services.AddScoped<GoogleMapsService>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        var key = builder.Configuration["JwtSettings:SecretKey"];
        if (string.IsNullOrEmpty(key))
        {
            throw new InvalidOperationException("JWT SecretKey is not configured.");
        }
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Taxi Info API",
        Version = "v1",
        Description = "API for accessing taxi location and route information",
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Taxi Info API v1");
    });
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    await dbContext.Database.MigrateAsync();
    await SeedTaxiRoutesFromCsv(dbContext);
}

async Task SeedTaxiRoutesFromCsv(AppDbContext dbContext)
{
    var csvFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "taxi_rank_price_list.csv");
    await TaxiRouteSeeder.SeedFromCsvAsync(dbContext, csvFilePath);
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.RunAsync();