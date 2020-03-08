using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RaffleDrawing.Data;
using RaffleDrawing.Api.Repositories;
using RaffleDrawing.Api.GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace RaffleDrawing
{
    public class Startup
    {
        private IConfiguration Configuration;
        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<RaffleContext>(options => 
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<RaffleRepository>();
            services.AddScoped<RaffleDrawingSchema>();
            services.AddGraphQL(o=>{o.ExposeExceptions = true;}).AddGraphTypes(ServiceLifetime.Scoped);
            services.Configure<KestrelServerOptions>(options =>
                {
                    options.AllowSynchronousIO = true;
                });

// IIS
 services.Configure<IISServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseGraphQL<RaffleDrawingSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            // app.UseEndpoints(endpoints =>
            // {
            //     endpoints.MapGet("/", async context =>
            //     {
            //         var raffleContext = services.BuildServiceProvider().GetRequiredService<RaffleContext>();
            //         var donations = await raffleContext.Donations.ToListAsync();
            //         await context.Response.WriteAsync(donations.ToString());
            //     });
            // });
        }
    }
}
