
using LogisticsManagement.DataAccess.Models;
using LogisticsManagement.DataAccess.Repository;
using LogisticsManagement.DataAccess.Repository.IRepository;
using LogisticsManagement.Service.Convertors;
using LogisticsManagement.Service.Services;
using LogisticsManagement.Service.Services.IServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LogisticsManagement.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<LogisticsManagementContext>(option => option.UseSqlServer(builder.Configuration.GetConnectionString("localConnectionString")));
           
            builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

            
            builder.Services.AddScoped<IAuthService,AuthService>();
            builder.Services.AddScoped<IAuthRepository, AuthRepository>();


            //JWT Configuration
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata=false;
                options.SaveToken=true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecret"))),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
