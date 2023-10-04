using DrakeCodingExamJeffreyKolawoleMonteagudo.Interfaces;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Models;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Repositories;
using DrakeCodingExamJeffreyKolawoleMonteagudo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IStudentService, StudentService>();
builder.Services.AddTransient<IStudentRepository, StudentRepository>();
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddDbContext<DrakeCodingExamDbContext>();

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
