 using BlogAPI;
using BlogData;
using BlogData.Repository;
using BlogData.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using ServiceStack.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBlogsRepository,BlogsRepository > ();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
  b => b.MigrationsAssembly("BlogData")));

builder.Services.AddAutoMapper(typeof(MappingConfig));
builder.Services.AddScoped<IBlogsRepository, BlogsRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
