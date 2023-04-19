using Gaz.Data;
using Gaz.Domain;
using Gaz.Domain.Repositories.Abstract;
using Gaz.Domain.Repositories.Abstract.Auth;
using Gaz.Domain.Repositories.Abstract.SendMessage;
using Gaz.Domain.Repositories.EntityFramework;
using Gaz.Domain.Repositories.EntityFramework.Auth;
using Gaz.Domain.Repositories.EntityFramework.SendMessage;
using Gaz.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SerGaz.ApiControllers.Auth;
using System;
using System.Text.Json.Serialization;

namespace Gaz
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) =>
            Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
            services.AddControllersWithViews().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();

            services.AddScoped<DataManager>();

            services.AddTransient<IEditTimesRepository, EFEditTimesRepository>();
            services.AddTransient<IEstimationRepository, EFEstimationRepository>();
            services.AddTransient<IEstimationsMarkRepository, EFEstimationsMarkRepository>();
            services.AddTransient<IExplanationRepository, EFExplanationRepository>();
            services.AddTransient<IIndicatorRepository, EFIndicatorRepository>();
            services.AddTransient<ILawRepository, EFLawRepository>();
            services.AddTransient<IMarkRepositpry, EFMarkRepositpry>();
            services.AddTransient<IOnetypeRepository, EFOnetypeRepository>();
            services.AddTransient<IPollRepository, EFPollRepository>();
            services.AddTransient<IRoleRepository, EFRoleRepository>();
            services.AddTransient<IRolesLawRepository, EFRolesLawRepository>();
            services.AddTransient<IScoreRepository, EFScoreRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IUsersRoleRepository, EFUsersRoleRepository>();
            services.AddTransient<IAuthenticateRepository, EFAuthenticateRepository>();
            services.AddTransient<IChangePasswordRepository, EFChangePasswordRepository>();
            services.AddTransient<IRegisterRepository, EFRegisterRepository>();
            services.AddTransient<ISendExselRepository, EFSendExselRepository>();
            services.AddTransient<DataManager>();

            services.AddMvc();

            var c = services.AddControllers();

            c.AddJsonOptions(opt =>
            {
                opt.JsonSerializerOptions.
                    ReferenceHandler = ReferenceHandler.Preserve;
            });

            services.AddHttpContextAccessor();

            services.AddDbContext<freedb_testdbgazContext>();
            services.AddEndpointsApiExplorer();

            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Введите JWT токен авторизации."
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                        },
                        new string[]{}
                    }
                });
            });

            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = AuthOptions.Issuer,
                    ValidateAudience = true,
                    ValidAudience = AuthOptions.Audience,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
                };
            });

            services.AddCors(config =>
            {
                var policy = new CorsPolicy();
                policy.Headers.Add("*");
                policy.Methods.Add("*");
                policy.Origins.Add("*");
                policy.SupportsCredentials = true;
                config.AddPolicy("policy", policy);
            });

            services.AddDbContext<freedb_testdbgazContext>(x => x.UseSqlServer(Config.ConnectionString));

            services.AddDbContext<freedb_testdbgazContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<freedb_testdbgazContext>().AddDefaultTokenProviders();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.Cookie.Name = "myCompanyAuth";
            //    options.Cookie.HttpOnly = true;
            //    options.LoginPath = "/login";
            //    options.AccessDeniedPath = "/account/accessdenied";
            //    options.SlidingExpiration = true;
            //});

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                });
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute
                (
                    "default", 
                    "{controller=Home}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
