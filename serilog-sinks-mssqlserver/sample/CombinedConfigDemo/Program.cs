using System;
using System.Reflection.PortableExecutable;
using System.Threading;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;
using Serilog;
using Serilog.Context;
using SCUS.Serilog.Sinks.MSSqlServer;

namespace CombinedConfigDemo
{
    // This sample app reads connection string and column options from appsettings.json
    // while schema name, table name and autoCreateSqlTable are supplied programmatically
    // as parameters to the MSSqlServer() method.
    public static class Program
    {


        public static void Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            //var columnOptionsSection = configuration.GetSection("Serilog:ColumnOptions");
            //var sinkOptionsSection = configuration.GetSection("Serilog:SinkOptions");

            // Legacy interface - do not use this anymore
            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.MSSqlServer(
            //        connectionString: _connectionStringName,
            //        tableName: _tableName,
            //        appConfiguration: configuration,
            //        autoCreateSqlTable: true,
            //        columnOptionsSection: columnOptionsSection,
            //        schemaName: _schemaName)
            //    .CreateLogger();

            // New SinkOptions based interface
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext(
                )
                .Enrich.WithMachineName()
                .Enrich.WithProcessName()
                .Enrich.WithEnvironmentUserName()
                .WriteTo.MSSqlServer(
                    appConfiguration: configuration
                    )
                .CreateLogger();
          
            Log.Information("strange Hello {name} from thread {ThreadId}", Environment.GetEnvironmentVariable("USERNAME"), Environment.CurrentManagedThreadId);
            Log.Warning("No coins remain at position {@Position}", new { Lat = 25, Long = 134 });
            Log.CloseAndFlush();
            

        }
    }
}
