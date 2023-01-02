using LandingPageAPI.Mappings;
using LandingPageCore;
using LandingPageDB.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddDefaultPolicy(builder =>
	{
		builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LandingPageDBContext>(options =>
{
	options.UseMySql(builder.Configuration.GetConnectionString(AppConsts.LandingPageDBConnection), Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"));
});

builder.Services.AddAutoMapper(typeof(PageProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();
app.MapControllers();

app.Run();
