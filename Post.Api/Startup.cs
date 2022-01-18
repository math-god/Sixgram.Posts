using System;
using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Post.Core;
using Post.Core.Http;
using Post.Core.Membership;
using Post.Core.Options;
using Post.Core.Post;
using Post.Core.Profiles;
using Post.Core.Services;
using Post.Core.Token;
using Post.Database;
using Post.Database.Repository.Subscription;

namespace Post
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

            services.AddScoped<IHttpService, HttpService>();
            services.AddScoped<IMembershipRepository, MembershipRepository>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ITokenService, TokenService>();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection,
                x => x.MigrationsAssembly("Post.Database")));

            //Configure AutoMapper Profile
            var mapperConfig = new MapperConfiguration
                (mc =>
                {
                    mc.AddProfile(new AppProfile()); 
                    
                });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            ConfigureAuthentication(services);

            ConfigureSwagger(services);

            services.AddHttpContextAccessor();

            //Configure HttpClient
            services.AddHttpClient("auth", p => { p.BaseAddress = new Uri("http://localhost:5000/"); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test v1"));
                app.UseCors(builder => builder.AllowAnyOrigin());
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void ConfigureAuthentication(IServiceCollection services)
        {
            var key = Encoding.ASCII.GetBytes(Configuration["AppOptions:SecretKey"]);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(x =>
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateLifetime = false,
                        ValidateIssuer = false,
                        RequireExpirationTime = false,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };
                    x.SaveToken = true;
                });
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            /*services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ReportApiVersions = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });*/

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    BearerFormat = "Bearer {authToken}",
                    Description = "JSON Web Token to access resources. Example: Bearer {token}",
                    Type = SecuritySchemeType.ApiKey
                });
                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme, Id = "Bearer"
                                }
                            },
                            Array.Empty<string>()
                        }
                    });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                options.IncludeXmlComments(xmlPath);
            });
        }
    }
}