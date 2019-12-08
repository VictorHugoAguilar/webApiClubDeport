using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using AutoMapper;
using System.Text;
using webApiClubDeport.Context;
using webApiClubDeport.Models;
using webApiClubDeport.Services;
using webApiClubDeport.Entities;
using webApiClubDeport.Models.Deportes;
using webApiClubDeport.Models.PistaModel;
using webApiClubDeport.Models.SocioModel;
using webApiClubDeport.Models.ReservaModel;
using Microsoft.OpenApi.Models;

[assembly: ApiConventionType(typeof(DefaultApiConventions))]

namespace webApiClubDeport
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
            /**
             * Añadimos el servicio de hash para encriptar password
             */
            services.AddScoped<HashService>();

            /**
             * Añadimos los CORS para permitir acceso desde un origen determinado
             * */
            services.AddCors(options =>
            {
                options.AddPolicy("PermitirApiRequest",
                        builder => builder.WithOrigins("https://www.apirequest.io").WithMethods("GET"));
            });


            services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("defaultConnection")));

            /**
             * Configuramos Mapper
             */
            services.AddAutoMapper(configuration =>
            {
                configuration.CreateMap<Deporte, DeporteDto>().ReverseMap();
                configuration.CreateMap<Deporte, DeporteViewModel>();
                configuration.CreateMap<Pista, PistaDto>().ReverseMap();
                configuration.CreateMap<Pista, PistaViewModel>();
                configuration.CreateMap<Socio, SocioDto>().ReverseMap();
                configuration.CreateMap<Socio, SocioViewModel>();
                configuration.CreateMap<Reserva, ReservaDto>().ReverseMap();
                configuration.CreateMap<Reserva, ReservaViewModel>();
            }, typeof(Startup));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = false,
                     ValidateAudience = false,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                     ClockSkew = TimeSpan.Zero
                 });

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "V1",
                    Title = "Gestión de Reservas Pistas para Club polideportivo",
                    Description = "EndPoints para consultas webApi de reservas para club polideportivo",
                    License = new OpenApiLicense()
                    {
                        Name = "MIT",
                    },
                    Contact = new OpenApiContact()
                    {
                        Name = "Victor Hugo Aguilar Aguilar",
                        Email = "victorhugoaguilar@aol.com",
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.SwaggerEndpoint("/swagger/v1/swagger.json", "Mi API v1");
            });


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseCors();
     
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
