using AutoMapper;
using Financeiro.Common.ConfiguracaoAutoMapper;
using Financeiro.Dao;
using Financeiro.Dao.Interface;
using Financeiro.Dao.Repositorio;
using Financeiro.Services;
using Financeiro.Services.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;

namespace Financeiro.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private MapperConfiguration MapperConfiguration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperModelToService());
                cfg.AddProfile(new AutoMapperServiceToModel());
            });

            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkSqlServer()
                .AddDbContext<FinanceiroContext>(o => o.UseSqlServer(connectionString));

            services.AddScoped<ILancamentoServices, LancamentoServices>();
            services.AddScoped<ILancamentoRepositorio, LancamentoRepositorio>();
            services.AddScoped<IBalancoServices, BalancoServices>();
            services.AddScoped<IBalancoRepositorio, BalancoRepositorio>();
            services.AddSingleton(sp => MapperConfiguration.CreateMapper());

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Sistema Financeiro",
                        Version = "",
                        Description = "",
                    });

                string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");
                c.IncludeXmlComments(caminhoXmlDoc);
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            RunSwagger(app);

            app.UseMvc();
        }

        private void RunSwagger(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sistema Financeiro");
            });
        }

    }
}
