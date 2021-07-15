using legendary_rotary_phone.Architecture;
using legendary_rotary_phone.Architecture.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace legendary_rotary_phone
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(new HttpResponseExceptionFilter()); //filtr mapujacy bledy HttpResponseException w piekne odpowiedzi
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    return new ObjectResult(new {
                        Status = 400,
                        Message = "Validation error",
                        Details = $"{string.Join(" ", context.ModelState.Select(pair => $"{string.Join(", ", pair.Value.Errors.Select(error => error.ErrorMessage))}"))}",
                    })
                    {
                        StatusCode = 400
                    };
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
            });
        }
    }
}
