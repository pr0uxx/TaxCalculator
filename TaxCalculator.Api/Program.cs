using Microsoft.EntityFrameworkCore;
using TaxCalculator.EfCore;
using TaxCalculator.Models.ConfigurationOptions;
using TaxCalculator.Models.Data;
using TaxCalculator.Repository;
using TaxCalculator.Repository.Interface;
using TaxCalculator.Services.SalaryCalculator.NetSalaryCalculator;
using TaxCalculator.Services.SalaryCalculator.YearlyToMonthlyCalculator;
using TaxCalculator.Services.TaxCalculator.Interface;
using TaxCalculator.Services.TaxCalculator.UKIncomeTax;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Localhost", policy =>
    {
        policy.WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddResponseCaching();

builder.Services.AddDbContext<TaxCalculatorContext>((sp, options) =>
{
    //options.UseSqlServer(builder.Configuration.GetConnectionString("TaxCalculatorDatabase"));
    sp.GetRequiredService<RepositoryImplementationFactory>().CreateDatabase(options, builder.Configuration.GetConnectionString("TaxCalculatorDatabase"));
});

builder.Services.AddScoped<RepositoryImplementationFactory>();

//leaving argument specifications in so people know what interface to use when injecting services
builder.Services.AddScoped<IRepository<TaxYear>>(
    sp => sp.GetRequiredService<RepositoryImplementationFactory>().CreateInstance<TaxYear>());
builder.Services.AddScoped<IRepository<TaxBand>>(
    sp => sp.GetRequiredService<RepositoryImplementationFactory>().CreateInstance<TaxBand>());

builder.Services.AddSingleton<INetSalaryCalculatorService, NetSalaryCalculator>();
builder.Services.AddSingleton<IYearlyToMonthlyCalculatorService, YearlyToMonthlyCalculatorService>();

builder.Services.AddScoped<IIncomeTaxCalculatorService, UkIncomeTaxCalculatorService>();

builder.Services.AddOptions<RepositoryOptions>("RepositoryOptions");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Localhost");
}

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
