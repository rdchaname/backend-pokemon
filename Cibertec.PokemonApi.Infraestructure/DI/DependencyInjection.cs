﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Cibertec.PokemonApi.Infraestructure.DI
{
    public static class DependencyInjection
    {

        public static void AddLogger(this IServiceCollection services, IConfiguration config)
        {

            var serilogLogger = new LoggerConfiguration()
                    .MinimumLevel.Information()
                    .Enrich.FromLogContext()
                    .WriteTo.File(config.GetSection("LogSettings:FileName").Value, rollingInterval: RollingInterval.Day).CreateLogger();
            var serilog2 = new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger();

            services.AddLogging(x =>
            {
                x.AddSerilog(logger: serilog2, dispose: true);

            });



        }

    }
}
