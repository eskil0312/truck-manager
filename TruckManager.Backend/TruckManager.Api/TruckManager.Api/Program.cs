using TruckManager.Api;
using TruckManager.Application;
using TruckManager.Infrastrucure;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}


var app = builder.Build();

app.UseHttpsRedirection();

app.UseExceptionHandler("/error");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
