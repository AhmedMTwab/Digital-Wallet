using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.CORE.Services;
using DigitalWallet.Domain.RepositoryInterfaces;
using DigitalWallet.Infrastrucutre.DIContainer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructureLayerServices(builder.Configuration);
builder.Services.AddControllers();

builder.Services.AddScoped<IBankParserFactory,BankParserFactory>();
builder.Services.AddScoped<ITransactionServices, TransactionServices>();
builder.Services.AddScoped<IClientService, ClientService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
 

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
