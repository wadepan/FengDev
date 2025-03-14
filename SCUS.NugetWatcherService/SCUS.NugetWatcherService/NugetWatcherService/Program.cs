using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using System;

var builder = Host.CreateDefaultBuilder(args)
                .UseWindowsService()
                .UseSerilog((context,config) =>
                {
                    config
                    .WriteTo.Console()
                    .WriteTo.File("D:\\Logs\\NugetWatcherLog.log");
                })
                .ConfigureServices(services =>
                 {
                     services.AddHostedService<NugetWatcherService>();
                 });


var host = builder.Build();
host.Run();






