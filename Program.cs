using FacilityManagementSystem.Infrastructure.Data;
using FacilityManagementSystem.Application.Services;
using FacilityManagementSystem.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FacilityManagementSystem.Application.Interfaces;
using FacilityManagementSystem.Infrastructure.Implementation;
using FacilityManagementSystem.Application.Mapping;
using AutoMapper;

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

            // 🔹 Repositories
            builder.Services.AddScoped<IAssetRepository, AssetRepository>();

            // 🔹 Services
            builder.Services.AddScoped<IAssetService, AssetService>();
            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            // Controllers
            builder.Services.AddControllers();

            // Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();//System.TypeLoadException: 'Could not load type 'AutoMapper.Configuration.MapperConfigurationExpression' from assembly 'AutoMapper, Version=16.0.0.0, Culture=neutral, PublicKeyToken=be96cd2c38ef1005'.'


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
