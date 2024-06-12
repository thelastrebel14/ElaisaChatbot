using Microsoft.EntityFrameworkCore;
using ElaisaDB;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DB connection setup
builder.Services.AddDbContext<ElaisaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElaisaLocalConnection"));
});


var app = builder.Build();

// Deshabilitar una vez que haya datos en la db
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ElaisaContext>();
    context.Database.Migrate();
}

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
