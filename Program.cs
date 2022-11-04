using blogAPI.Data;
using Microsoft.EntityFrameworkCore;
using blogAPI.Responsitories;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext <AppDBContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<UserRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var policyName = "myAPPPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName, p =>
    {
        p.WithOrigins("*").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();