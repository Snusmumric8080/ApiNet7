using ApiNet7.Repositories;
using ApiNet7.Service;
using AutoMapper;
using static ApiNet7.Service.IBookService;

namespace ApiNet7.Extensions
{
    public static class StartupExtensions
    {
        public static void AddScopedServices(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddAutoMapper(typeof(Program));
        }
    }
}