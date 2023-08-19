using Microsoft.EntityFrameworkCore;
using TodoApi.Context;
using TodoApi.Dto.Mapper;
using TodoApi.Dto;
using TodoApi.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt => opt.AddPolicy("corspolicy", builder =>
{
    builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));


// Add services to the container.
builder.Services.AddDbContext<TodoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("Todo")));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddAutoMapper(typeof(GeneralMapper));
builder.Services.AddTransient<ResponseDto>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("corspolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
