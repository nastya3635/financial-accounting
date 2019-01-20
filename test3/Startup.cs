using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Entities;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using test3.Services;

namespace test3
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");
            // добавляем контекст CostsContext в качестве сервиса в приложение
            services.AddDbContext<CostsContext>(options => options.UseSqlServer(connection));
            services.AddOData();
            services.AddTransient<IGetCost, GetCost>();
            services.AddTransient<IGetCostWithId, GetCostWithId>();
            services.AddTransient<IPostCost, PostCost>();
            services.AddTransient<IPutCost, PutCost>();
            services.AddTransient<IDeleteCost, DeleteCost>();
            services.AddTransient<IGetCategory, GetCategory>();
            services.AddTransient<IGetCategoryWithId, GetCategoryWithId>();
            services.AddTransient<IPostCategory, PostCategory>();
            services.AddTransient<IPutCategory, PutCategory>();
            services.AddTransient<IDeleteCategory, DeleteCategory>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(b =>
            {
                b.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
        }

        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Cost>("Costs");
            builder.EntitySet<Category>("Categories");
            return builder.GetEdmModel();
        }
    }
}
