using polarvehicles.Data;
using System.Data.SQLite;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Build up some example data
SQLiteConnection sqlite_conn;
sqlite_conn = SqlLiteConfig.CreateConnection();
SqlLiteConfig.CreateTable(sqlite_conn);
SqlLiteConfig.InsertData(sqlite_conn);
sqlite_conn.Close();


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