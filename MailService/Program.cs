using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    services.AddMassTransit(x =>
                    {
                        //x.AddConsumer<>();

                        //RabbitMQ
                        x.UsingRabbitMq((context, cfg) =>
                        {
                            cfg.Host(
                                Environment.GetEnvironmentVariable("HOST_RABBIT"),
                                Environment.GetEnvironmentVariable("VHOST_RABBIT"),
                                hst => {
                                    hst.Username(Environment.GetEnvironmentVariable("USERNAME_RABBIT"));
                                    hst.Password(Environment.GetEnvironmentVariable("PASSWORD_RABBIT"));
                                });
                            //create
                            cfg.ReceiveEndpoint("Microservice-SendMailUser", e =>
                            {
                                //e.ConfigureConsumer<CreateOrderConsumer>(context);
                            });
                        });
                    });
                    //services.AddMassTransitHostedService(true);
                });
    }
}
