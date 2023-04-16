using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RoomNumberTask;
using RoomNumberTask.BusinessLogic;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch(ArgumentOutOfRangeException ex)
{
    Console.WriteLine("The entered value needs to be between 1 and 1,000,000, inclusive.");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
               .ConfigureServices((_, services) =>
               {
                   services.AddSingleton<App>();
                   services.AddSingleton<IRoomNumber, RoomNumber>();
               });

}