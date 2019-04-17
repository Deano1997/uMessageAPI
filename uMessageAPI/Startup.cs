using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using uMessageAPI.Data;
using uMessageAPI.Extensions;
using uMessageAPI.Hub;

namespace uMessageAPI {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.ConfigureDbContext(Configuration);
            services.ConfigureIdentity(Configuration);
            services.ConfigureAuthentication(Configuration);
            services.ConfigureCors(Configuration);
            services.ConfigureOpenApiDocument(Configuration);
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {   
            // Apply required database changes before application startup.
            UpdateDatabase(app, env);
            // Configure web application server.
            ConfigureWebServer(app, env);
        }

        private static void UpdateDatabase(IApplicationBuilder app, IHostingEnvironment env) {
            // Only perform automatic database updates during development. In production mode this should
            // be part of the deployment process.
            if (env.IsDevelopment()) {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                    using (var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>()) {
                        context.Database.Migrate();
                    }
                }
            }
        }

        private static void ConfigureWebServer(IApplicationBuilder app, IHostingEnvironment env) {
            // Check whether development mode is currently active.
            if (env.IsDevelopment()) {
                // Allow developers to have a more detailed exception page.
                app.UseDeveloperExceptionPage();
            }
            else {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseForwardedHeaders(new ForwardedHeadersOptions {
                // Configure our web application to use all the available forwarded headers
                // in case we are behind a proxy.
                ForwardedHeaders = ForwardedHeaders.All
            });
            app.UseSignalR(configure => {
                // Configure our chat hub to be exposed on given route.
                configure.MapHub<ServiceHub>("/signal-r");
            });
            app.UseMvc();
        }

        private static void ConfigureSwagger(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseSwagger();
            app.UseSwaggerUi3();
        }

    }
}
