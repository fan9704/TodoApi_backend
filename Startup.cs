using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TodoApi_backend.Data;
using TodoApi_backend.Models;
namespace TodoApi_backend
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      /*builder.WithOrigins(
                                                          "http://localhost:8080",
                                                          "http://127.0.0.1:8080");*/
                                      builder.AllowAnyOrigin()
                                      .AllowAnyMethod()
                                      .AllowAnyHeader();

                                  });
            });
            services.AddControllers();
            string mySqlConnectionStr = Configuration.GetConnectionString("MySQL");
            services.AddDbContext<ProductContext>(options => options.UseMySql(mySqlConnectionStr, MySqlServerVersion.AutoDetect(mySqlConnectionStr), x => x.MigrationsAssembly("TodoApi_backend")));
           services.AddDbContext<TodoContext>(options => options.UseMySql(mySqlConnectionStr, MySqlServerVersion.AutoDetect(mySqlConnectionStr), x => x.MigrationsAssembly("TodoApi_backend")));
           services.AddDbContext<SellRecordContext>(options => options.UseMySql(mySqlConnectionStr, MySqlServerVersion.AutoDetect(mySqlConnectionStr), x => x.MigrationsAssembly("TodoApi_backend")));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodoApi_backend", Version = "v1" });
            });
        /*    services.AddDbContext<ProductContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("ProductContext")));
            services.AddDbContext<TodoContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("TodoContext")));
            services.AddDbContext<SellRecordContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SellRecordContext")));*/


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodoApi_backend v1"));
            }
            app.UseCors(MyAllowSpecificOrigins);
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
