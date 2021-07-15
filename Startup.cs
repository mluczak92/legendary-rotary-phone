using legendary_rotary_phone.Architecture;
using legendary_rotary_phone.Architecture.ExceptionHandling;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
                options.Filters.Add(new ModelValidateFilter()); //dodajemy filtr walidujacy inputy
                options.Filters.Add(new HttpResponseExceptionFilter()); //filtr mapujacy bledy HttpResponseException w piekne odpowiedzi
            }).ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //wylaczamy automatyczna obsluge bledow walidacji modelu, chcemy to robic po swojemu
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
