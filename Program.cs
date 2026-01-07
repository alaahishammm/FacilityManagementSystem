using FacilityManagementSystem.Infrastructure.Data;
using FacilityManagementSystem.Application.Services;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Infrastructure.Implementation;
using FacilityManagementSystem.Application.Mapping;
using AutoMapper;
using FluentValidation.AspNetCore;
using FluentValidation;
using FacilityManagementSystem.Application.Validators.Asset;
using FacilityManagementSystem.Application.Validators.Facility;
using FacilityManagementSystem.Application.Validators.Request;
using FacilityManagementSystem.Application.Validators.WorkOrder;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FacilityManagementSystem.Application.Validators.User;
using FacilityManagementSystem.Application.Validators.Auth;

namespace FacilityManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")));

            // JWT 
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = builder.Configuration["Jwt:Issuer"],
                        ValidAudience = builder.Configuration["Jwt:Audience"],

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
                        )
                    };
                });

            builder.Services.AddAuthorization();

            //  FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddFluentValidationClientsideAdapters();

            builder.Services.AddValidatorsFromAssemblyContaining<AreaCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AreaUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AssetCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<AssetUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<FacilityCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<FacilityUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<RequestCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<RequestUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<WorkOrderCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<WorkOrderUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<UserUpdateDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<LoginDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<RegisterDtoValidator>();

            //  Repositories
            builder.Services.AddScoped<IAssetRepository, AssetRepository>();
            builder.Services.AddScoped<IAreaRepository, AreaRepository>();
            builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWorkOrderRepository, WorkOrderRepository>();
            builder.Services.AddScoped<IMaintenanceRequestRepository, MaintenanceRequestRepository>();

            //  Services
            builder.Services.AddScoped<IAssetService, AssetService>();
            builder.Services.AddScoped<IAreaService, AreaService>();
            builder.Services.AddScoped<IFacilityService, FacilityService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IWorkOrderService, WorkOrderService>();
            builder.Services.AddScoped<IMaintenanceRequestService, MaintenanceRequestService>();
            builder.Services.AddScoped<IAuthService, AuthService>();


            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

          
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();
            app.Run();
        }
    }
}
