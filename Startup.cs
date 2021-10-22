using Lavoro.Data;
using Lavoro.Models;
using Lavoro.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lavoro
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

            services.AddControllers();

            //Seguendo il pattern Dependency Injection aggiungiamo le istanze(Cors,DbContext,Singleton o Scoped) che ci servono direttamente da qui

            //Aggiungiamo i Cors affinché lato front-end possano essere ricevuti/inoltrati i dati per le chiamate HTTP
            services.AddCors();

            //Definiamo una stringa con all'interno i parametri presi dalle variabili d'ambiente raccolte in appsettings.json
            string parametri = Configuration.GetConnectionString("Default");

            //Aggiungiamo il DBContext<DataContext>
            services.AddDbContext<DataContext>(opt => opt.UseMySQL(parametri));

            //Aggiungiamo le nostre istanze Scoped, le quali fungono come le Singleton ma per più richieste
            services.AddScoped<InterfaceService<Dipendente>, DipendenteService>();

            services.AddScoped<InterfaceService<Dirigente>, DirigenteService>();

            services.AddScoped<InterfaceService<Reparto>, RepartoService>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Lavoro", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Lavoro v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //Con UseCors il consenso all'applicazione(lato FrontEnd) di fare chiamate HTTP REST (GET, POST..) per prendere i dati dal server
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            //Per Creare la Migrazione, ossia per implementre la parte EntityFramework (MySQL) eseguire i seguenti comandi
            //nella PowerShell(terminale in basso) di questo progetto:

            /*
             * 1) dotnet tool install --global dotnet-ef (installiamo a livello globale lo strumento di dotnet-ef)
             * 
             * 
	         * 2) dotnet-ef migrations add Inizio (Aggiungiamo la Migrazione, verranno creati file .cs in un apposita cartella,)
	         *                                    (In caso di nuova migrazione eliminare la cartella relativa e tutti i suoi file interni)
	         *                                    
	         * 3) dotnet-ef database update (Creazione del database, delle relative Tabelle "DbSets" e delle relazioni gestite)
             * 
             * 
             * */



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
