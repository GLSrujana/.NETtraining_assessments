using Microsoft.EntityFrameworkCore;
using UserApi.Models;

namespace UserApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 1. Add CORS services
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngularDevClient",
                    policy =>
                    {
                        // Assuming your Angular app runs on port 4200
                        policy.WithOrigins("http://localhost:4200")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                    });
            });

            // 2. Add Database Context using SQL Server
            // IMPORTANT: This MUST be placed BEFORE builder.Build()
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // ====================================================
            // NOTHING related to builder.Services goes below this line!
            var app = builder.Build();
            // ====================================================

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // 3. Use the CORS policy configured above BEFORE Authorization
            app.UseCors("AllowAngularDevClient");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}