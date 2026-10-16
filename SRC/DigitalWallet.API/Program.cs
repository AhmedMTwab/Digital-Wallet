using DigitalWallet.CORE.ServiceInterfaces;
using DigitalWallet.CORE.Services;
using DigitalWallet.Domain.RepositoryInterfaces;
using DigitalWallet.Infrastrucutre.DIContainer;
using Hangfire;
using Hangfire.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddInfrastructureLayerServices(builder.Configuration);
builder.Services.AddControllers();
var hangfireConnectionString = builder.Configuration.GetConnectionString("ApplicationDb")
                               ?? throw new InvalidOperationException("Connection string 'ApplicationDb' is not configured.");

builder.Services.AddHangfire(configuration => configuration
    .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
    .UseSimpleAssemblyNameTypeSerializer()
    .UseRecommendedSerializerSettings()
    .UseSqlServerStorage(hangfireConnectionString, new SqlServerStorageOptions
    {
        SchemaName = builder.Configuration["Hangfire:Storage:SchemaName"] ?? "HangFire",
        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
        QueuePollInterval = TimeSpan.Zero,
        UseRecommendedIsolationLevel = true,
        DisableGlobalLocks = true
    }));

builder.Services.AddHangfireServer(options =>
{
    options.WorkerCount = builder.Configuration.GetValue<int?>("Hangfire:WorkerCount")
                          ?? Math.Max(1, Environment.ProcessorCount * 5);
    options.Queues = builder.Configuration.GetSection("Hangfire:Queues").Get<string[]>()
                     ?? new[] { "default" };
});

builder.Services.AddScoped<IBankParserFactory,BankParserFactory>();
builder.Services.AddScoped<ITransactionServices, TransactionServices>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IHandleTransactionRequest, HandleTransactionRequest>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseHangfireDashboard(
    builder.Configuration["Hangfire:DashboardPath"] ?? "/hangfire");

app.UseHttpsRedirection();
app.MapControllers();


app.Run();
