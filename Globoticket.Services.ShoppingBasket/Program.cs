using Globoticket.Integration.MessagingBus;
using Globoticket.Services.ShoppingBasket.DbContexts;
using Globoticket.Services.ShoppingBasket.Repositories;
using Globoticket.Services.ShoppingBasket.Services;
using Microsoft.EntityFrameworkCore;
using Polly.Extensions.Http;
using Polly;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ShoppingBasketDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddScoped<IBasketLinesRepository, BasketLinesRepository>();
builder.Services.AddScoped<IBasketChangeEventRepository, BasketChangeEventRepository>();
builder.Services.AddSingleton<IMessageBus, AzServiceBusMessageBus>();

builder.Services.AddHttpClient<IEventCatalogService, EventCatalogService>(c => { 
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:EventCatalog:Uri"]);
});

builder.Services.AddHttpClient<IDiscountService, DiscountService>(c =>
                c.BaseAddress = new Uri(builder.Configuration["ApiSettings:Discount:Uri"]))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());



builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
{
    return HttpPolicyExtensions
        .HandleTransientHttpError()
        .CircuitBreakerAsync(3, TimeSpan.FromSeconds(15));
}

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
{
    return HttpPolicyExtensions.HandleTransientHttpError()
        .WaitAndRetryAsync(5,
            retryAttempt => TimeSpan.FromMilliseconds(Math.Pow(1.5, retryAttempt) * 1000),
            (_, waitingTime) =>
            {
                Console.WriteLine("Retrying due to Polly retry policy");
            });
}
