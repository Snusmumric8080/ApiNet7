using ApiNet7.Repositories;

namespace ApiNet7.Extensions
{
    public static class StartupExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
