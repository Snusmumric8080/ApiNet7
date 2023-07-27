using ApiNet7.Repositories;
using AutoMapper;
namespace ApiNet7.Extensions
{
    public static class StartupExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddAutoMapper(typeof(Program));
        }
    }
}
