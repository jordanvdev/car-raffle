using car_raffle_datalayer.Repository;
using car_raffle_datalayer.Repository.Interfaces;
using car_raffle_services.Services;
using car_raffle_services.Services.Interfaces;
using car_raffle_services.Validators;
using car_raffle.SignalR.Hub;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Tarkov_Info_DataLayer;
using Tarkov_Info_DataLayer.Repository;
using Tarkov_Info_DataLayer.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
builder.Services.AddSignalR();

builder.Services.AddDbContext<RaffleContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaffleDatabase"));
});

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ListingRequestValidator>());


builder.Services.AddScoped<IListingService, ListingService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.MapHub<ListingHub>("/listingHub");

app.Run();


