using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace hosting
{
    public class Startup
    {
        private IConfigurationRoot _configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public void Configure(IApplicationBuilder app){

            app.UseMiddleware<MyMiddleware>();

            var applicationName = _configuration.GetValue<string>("ApplicationName");

            app.Run(context => context.Response.WriteAsync($"Ola Mundo 2 | {applicationName}"));
        }
    }
}