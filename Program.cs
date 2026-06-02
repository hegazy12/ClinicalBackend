using Microsoft.EntityFrameworkCore;
using ElearingEnglis.DataCon;


var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllers();
builder.Services.AddOpenApi(); 

builder.Services.AddDbContext<DBCon>(options =>
    options.UseMySql(connectionString, 
        ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();

app.MapOpenApi();


app.UseHttpsRedirection();
app.UseAuthorization();


app.MapControllers();

app.Run();