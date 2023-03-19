using System.Reflection;
using TruckManager.Application;
using TruckManager.Infrastrucure;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}


var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseExceptionHandler("/error");

app.MapControllers();

app.Run();
