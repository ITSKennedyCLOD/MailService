using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using MailService.Interfaces;
using MailService.Services;

namespace MailService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    // services.AddHostedService<Worker>();


                    services.AddMassTransit(
                        x=>
                        {
                            x.UsingRabbitMq((context, config) =>
                            {
                                config.Host(
                                    "roedeer.rmq.cloudamqp.com",
                                    "vpeeygzh",
                                    credential =>
                                    {
                                        credential.Username("vpeeygzh");
                                        credential.Password("t0mDd3KRsJkXRV3DXzmCUfRWmDFbFu42");
                                    }
                                );

                                config.ConfigureEndpoints(context);


                            });
                        });

                    services.AddScoped<IMailSenderService, MailSenderService>();
                });
    }
}
