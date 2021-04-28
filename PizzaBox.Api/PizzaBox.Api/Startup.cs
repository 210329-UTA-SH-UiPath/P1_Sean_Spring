using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PizzaBox.Storing.Entities;
using Microsoft.EntityFrameworkCore;
using PizzaBox.Storing.Repositories;

namespace PizzaBox.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var _connectionString = Configuration["PizzaBox.Api:connectionString"];
            services.AddControllers();
            services.AddDbContext<pizzaappContext>(optionsBuilder => optionsBuilder.UseSqlServer(_connectionString));
            services.AddScoped<CustomerRepository>();
            services.AddScoped<CrustRepository>();
            services.AddScoped<OrderPizzaRepository>();
            services.AddScoped<OrderRepository>();
            services.AddScoped<PizzaRepository>();
            services.AddScoped<PizzaToppingRepository>();
            services.AddScoped<SizeRepository>();
            services.AddScoped<StoreRepository>();
            services.AddScoped<ToppingRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PizzaBox.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PizzaBox.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
