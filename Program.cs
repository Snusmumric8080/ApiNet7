using ApiNet7.Extensions;
using ApiNet7.Repositories;
using Microsoft.EntityFrameworkCore;
using ApiNet7.Data;

namespace ApiNet7
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScopedServices();

            builder.Services.AddDbContext<AppDbContext>(options =>
             options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

            // «апуск инициализации базы данных (если ее нет)
            using (var scope = builder.Services.BuildServiceProvider().CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                dbContext.Database.EnsureCreated();
            }

            var app = builder.Build();

            // Configure the HTTP request pipeline.
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