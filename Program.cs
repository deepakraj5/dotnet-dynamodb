using Amazon.DynamoDBv2;
using Amazon.Runtime;
using SampleDotNetDynamo.Repositories;
using SampleDotNetDynamo.Services;
using SampleDotNetDynamo.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddSingleton<IAmazonDynamoDB>(option =>
    {
        var config = new AmazonDynamoDBConfig
        {
            ServiceURL = builder.Configuration["AWS:ServiceURL"],
        };

        var credentials = new BasicAWSCredentials(
                "dfjnikmcv",
                "skfcbjkdsd"
            );

        return new AmazonDynamoDBClient(credentials, config);
    });
} else
{
    builder.Services.AddSingleton<IAmazonDynamoDB, AmazonDynamoDBClient>();
}

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();

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
