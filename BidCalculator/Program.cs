using BidCalculatorApi.Interfaces;
using BidCalculatorApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Adding the scope 
builder.Services.AddScoped<IPriceCalculatorService, PriceCalculatorService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configure CORS to allow requests from your Vue.js app
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "VueAppPolicy",
        policy =>
        {
            //TODO: change the origin to  WithOrigins("http://localhost:5298") while deploying at production
            policy.AllowAnyOrigin() // For development only. 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseCors("VueAppPolicy");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();
app.MapControllers(); // Map controller routes
app.Run();

