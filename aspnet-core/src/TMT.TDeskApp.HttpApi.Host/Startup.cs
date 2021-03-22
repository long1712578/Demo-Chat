using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TMT.TDeskApp.Messages;
using TMT.TDeskApp.Services;

namespace TMT.TDeskApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplication<TDeskAppHttpApiHostModule>();
            services.AddScoped<IKafkaService, KafkaService>();
           // services.AddScoped<IWidgetService, WidgetService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            app.InitializeApplication();
        }
    }
}
