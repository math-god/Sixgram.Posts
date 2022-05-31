using System.Reflection;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Post.Core.ControllerServices;
using Post.Core.Interfaces.Commentary;
using Post.Core.Interfaces.Connection;
using Post.Core.Interfaces.File;
using Post.Core.Interfaces.Http;
using Post.Core.Interfaces.Like;
using Post.Core.Interfaces.Post;
using Post.Core.Interfaces.Subscription;
using Post.Core.Interfaces.User;
using Post.Core.Options;
using Post.Core.Profiles;
using Post.Core.Services;
using Post.Database;
using Post.Database.Repository.Commentary;
using Post.Database.Repository.Like;
using Post.Database.Repository.Post;
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
            services.AddCors();

            services.AddControllers();

            services.AddScoped<IFileStorageHttpService, FileStorageHttpService>();
            services.AddScoped<IUserHttpService, UserHttpService>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<ICommentaryRepository, CommentaryRepository>();
            services.AddScoped<ISubscriptionService, SubscriptionService>();
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<ICommentaryService, CommentaryService>();
            services.AddScoped<IUserIdentityService, UserIdentityService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<IConnectionService, ConnectionService>();
            services.AddScoped<ILikeRepository, LikeRepository>();
            services.AddScoped<ILikeService, LikeService>();

            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(connection,
                x => x.MigrationsAssembly("Post.Database")));

            services.Configure<BaseAddresses>(Configuration.GetSection(BaseAddresses.BaseAddress));
            var addressesOptions = Configuration.GetSection(BaseAddresses.BaseAddress).Get<BaseAddresses>();
            services.AddSingleton(addressesOptions);


            var mapperConfig = new MapperConfiguration
                (mc => { mc.AddProfile(new AppProfile()); });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            ConfigureAuthentication(services);

            ConfigureSwagger(services);

            services.AddRouting(options => options.LowercaseUrls = true);

            services.AddHttpContextAccessor();

            services.AddHttpClient("FileStorage",
                client => { client.BaseAddress = new Uri(Configuration["BaseAddress:FileStorage"]); });

            services.AddHttpClient("AuthService",
                client => { client.BaseAddress = new Uri(Configuration["BaseAddress:AuthService"]); });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sixgram.Post API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(b 
                => b.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

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
            services.AddApiVersioning(options =>
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
            });

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