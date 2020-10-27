using ERP.Helpers;
using ERP.Model.Models;
using ERP.Repository;
using ERP.Repository.Statistic;
using ERP.ServiceExtensions;
using ERP.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace ERP
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy(MyAllowSpecificOrigins, builder =>
                {
                    builder.WithOrigins("http://localhost:3000");
                });
            });

           

            services.AddTokenAuthentication(Configuration);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRM API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "Oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });

            services.AddDbContext<SonTungContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IEntityCenterRepository, EntityCenterRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRoleGroupRepository, RoleGroupRepository>();
            services.AddTransient<IRoleGroupDetailRepository, RoleGroupDetailRepository>();
            services.AddTransient<INavigationRepository, NavigationRepository>();
            services.AddTransient<IEmployeeDayOffRepository, EmployeeDayOffRepository>();
            services.AddTransient<IEmployeeRelativeRepository, EmployeeRelativeRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<IEmployeeContractRepository, EmployeeContractRepository>();
            services.AddTransient<ICandidateRepository, CandidateRepository>();
            services.AddTransient<ICandidatePaperRepository, CandidatePaperRepository>();
            services.AddTransient<IShiftRepository, ShiftRepository>();
            services.AddTransient<IHolidayRepository, HolidayRepository>();
            services.AddTransient<ICheckInOutDeviceRepository, CheckInOutDeviceRepository>();
            services.AddTransient<IContractTypeRepository, ContractTypeRepository>();
            services.AddTransient<IRecruitmentPlanRepository, RecruitmentPlanRepository>();
            services.AddTransient<IShiftEmployeeRepository, ShiftEmployeeRepository>();
            services.AddTransient<ITrainingCourseRepository, TrainingCourseRepository>();
            services.AddTransient<ITrainingCourseEmployeeRepository, TrainingCourseEmployeeRepository>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EmployeeDayOffValidator>()).AddNewtonsoftJson();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "HRM API");
                c.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}