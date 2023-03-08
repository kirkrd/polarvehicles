using polarvehicles.Data;
using System.Data.SQLite;


//Your program starts here...
Console.WriteLine("Hello world!");
var builder = WebApplication.CreateBuilder(args);

AppDomain.CurrentDomain.ProcessExit += OnProcessExit;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// TODO: Use DB for dummy data
SQLiteConnection sqlite_conn;
sqlite_conn = SqlLiteConfig.CreateConnection();
SqlLiteConfig.CreateTable(sqlite_conn);
SqlLiteConfig.InsertData(sqlite_conn);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    // SqlLiteConfig.DropData(sqlite_conn);
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

static void OnProcessExit(object sender, EventArgs e)
{
    SQLiteConnection sqlite_conn;
    sqlite_conn = SqlLiteConfig.CreateConnection();
    SqlLiteConfig.DropData(sqlite_conn);
}

