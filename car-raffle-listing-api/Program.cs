using car_raffle_listing_data.Context;
using car_raffle_listing_data.Repository;
using car_raffle_listing_data.Repository.Interfaces;
using car_raffle_listings_services.Services.Interfaces;
using car_raffle_listings_services.Validators;
using car_raffle_services.Services;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

builder.Services.AddDbContext<ListingContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RaffleDatabase"));
});

builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<ListingRequestValidator>());

builder.Services.AddScoped<IListingService, ListingService>();
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

app.Run();