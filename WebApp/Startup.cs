using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.App;
using BLL.App.Helpers;
using ee.itcollege.anmeze.Contract.BLL.Base.Helpers;
using Contracts.BLL.App;
using Contracts.DAL.App;
using Contracts.DAL.App.Repositories;
using ee.itcollege.anmeze.Contracts.DAL.Base;
using ee.itcollege.anmeze.Contracts.DAL.Base.Helpers;
using DAL.App;
using DAL.App.EF;
using DAL.App.EF.Helpers;
using DAL.App.EF.Repositories;
using Domain.Identity;
using ee.itcollege.anmeze.DAL.Base.EF.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerGen;
using WebApp.Helpers;

namespace WebApp
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //set up DB with pomelo
            services.AddDbContext<AppDbContext>(options =>
                options.UseMySql(
                    Configuration.GetConnectionString("MysqlConnection")));

            /*
            services.AddScoped<IAnsweredQuestionsRepository, AnsweredQuestionRepository>();
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IEquipmentRepository, EquipmentRepository>();
            services.AddScoped<IEquipmentTypeRepository, EquipmentTypeRepository>();
            services.AddScoped<IFarmerRepository, FarmerRepository>();
            services.AddScoped<IFarmRepository, FarmRepository>();
            services.AddScoped<IFishTypeRepository, FishTypeRepository>();
            services.AddScoped<IPersonQuestionRepository, PersonQuestionRepository>();
            services.AddScoped<ISolutionRepository, SolutionRepository>();
            services.AddScoped<ITankRepository, TankRepository>();*/

           /* services.AddScoped<IDataContext, AppDbContext>();
            services.AddScoped<IBaseRepositoryProvider, BaseRepositoryProvider>();
            services.AddSingleton<IBaseRepositoryFactory, AppRepositoryFactory>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();*/
            
            services.AddScoped<IBaseRepositoryProvider, BaseRepositoryProvider<AppDbContext>>();
            services.AddSingleton<IBaseRepositoryFactory<AppDbContext>, AppRepositoryFactory>();
            services.AddScoped<IAppUnitOfWork, AppUnitOfWork>();

            
            //services.AddSingleton<IBaseServiceFactory, AppServiceFactory>();
            //services.AddScoped<IBaseServiceProvider, AppServiceProvider>();
            
            services.AddSingleton<IBaseServiceFactory<IAppUnitOfWork>, AppServiceFactory>();
            services.AddScoped<IBaseServiceProvider, BaseServiceProvider<IAppUnitOfWork>>();
            services.AddScoped<IAppBLL, AppBLL>();

            
            /*
            services.AddDefaultIdentity<AppUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddEntityFrameworkStores<AppDbContext>();
            */

            services
                .AddIdentity<AppUser, AppRole>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();
            
            //weak password for testing 
            // TODO: change in production
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
            });

            // webclient and backend
            services.AddCors(options =>
            {
                options.AddPolicy("CorsAllowAll", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });

            services
                .AddMvc(options => options.EnableEndpointRouting = true)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                }).AddJsonOptions(options =>
                {
                    //options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
                    options.SerializerSettings.Formatting = Formatting.Indented;
                });
            
            services.AddApiVersioning(options => { options.ReportApiVersions = true; });
            
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddSingleton<IEmailSender, EmailSender>();
            
            // =============== JWT support ===============
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // => remove default claims
            services
                .AddAuthentication()
                .AddCookie(options => { options.SlidingExpiration = true; })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JWT:Issuer"],
                        ValidAudience = Configuration["JWT:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero // remove delay of token when expire
                    };
                });
            
            
            // Api explorer + OpenAPI/Swagger
            services.AddVersionedApiExplorer( options => options.GroupNameFormat = "'v'VVV" );
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(i => i.FullName);
            });




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env , IApiVersionDescriptionProvider provider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("CorsAllowAll");
            app.UseCookiePolicy();

            app.UseAuthentication();

            
            
            
            app.UseSwagger();
            app.UseSwaggerUI(
                options =>
                {
                    foreach ( var description in provider.ApiVersionDescriptions )
                    {
                        options.SwaggerEndpoint(
                            $"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant() );
                    }
                } );
            
            app.UseMvc(routes =>
            {
                
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
               
            });
            
            
            
            
            

        }
    }
}