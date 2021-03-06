using API_CRUD.Infrastructure.AutoMapper;
using API_CRUD.Infrastructure.Context;
using API_CRUD.Infrastructure.Repositories.Concrete;
using API_CRUD.Infrastructure.Repositories.Interfaces;
using API_CRUD.Infrastructure.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace API_CRUD
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

            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionString"));
            });

            services.AddAutoMapper(typeof(Mapper));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("RestfulAPI", new OpenApiInfo()
                {
                    Title = "Restful API",
                    Version = "v1.1",
                    Description = "Emreksbyn Restful API",
                    Contact = new OpenApiContact()
                    {
                        Email = "emreksbyn@gmail.com",
                        Name = "Emre K?saboyun",
                        Url = new Uri("https://github.com/emreksbyn")
                    },
                    License = new OpenApiLicense()
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
                // API'ye request atacak kullan?c?lar? ne t?r bir security yap?s? kulland???m?z ile ilgili bilgilendiriyoruz.
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Autherization header using Baerer scheme",
                    Name = "Autherication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Baerer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Baerer"
                            },
                            Scheme = "Baerer",
                            Name = "Baerer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = true;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateAudience = false,
                    ValidateIssuer = false
                };
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/RestfulAPI/swagger.json", "Restful API");
                options.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}