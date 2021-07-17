using legendary_rotary_phone.domain.Orders;
using legendary_rotary_phone.infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using legendary_rotary_phone.infrastructure.Orders;
using legendary_rotary_phone_api.Filters;
using legendary_rotary_phone.infrastructure.ef;
using legendary_rotary_phone.infrastructure.ef.Orders;

namespace legendary_rotary_phone_api
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
                options.Filters.Add(new ExceptionFilter()); //filtr mapujacy bledy HttpResponseException w piekne odpowiedzi
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

            services.AddDbContext<RotaryDbContext>(options =>
            {
                options.UseSqlServer("");
            }, ServiceLifetime.Scoped);


            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment _)
        {
            app.UseRouting();
            app.UseEndpoints(builder =>
            {
                builder.MapControllers();
            });
        }
    }
}
