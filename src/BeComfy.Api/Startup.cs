using System;
using System.Reflection;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using BeComfy.Api.Services;
using BeComfy.Common.Authentication;
using BeComfy.Common.CqrsFlow;
using BeComfy.Common.Jaeger;
using BeComfy.Common.RabbitMq;
using BeComfy.Common.RestEase;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BeComfy.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; } 
        public IContainer Container { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Instead of AddMvc/Core()
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddJaeger();
            services.AddOpenTracing();
            services.AddJwt();
            services.AddAuthorization(x => x.AddPolicy("admin", p => p.RequireRole("admin")));
            
            services.RegisterRestClientFor<IFlightsService>("becomfy-services-flights");
            services.RegisterRestClientFor<IAirplanesService>("becomfy-services-airplanes");
            services.RegisterRestClientFor<ICustomersService>("becomfy-services-customers");
            services.RegisterRestClientFor<ITicketsService>("becomfy-services-tickets");

            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();
            builder.Populate(services);
            builder.AddRabbitMq();
            builder.AddDispatcher();
            builder.AddHandlers();

            Container = builder.Build();
            return new AutofacServiceProvider(Container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        { 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
