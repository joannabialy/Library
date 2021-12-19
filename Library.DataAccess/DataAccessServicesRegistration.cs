using Library.Application.Contracts.Repositories;
using Library.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.DataAccess
{
    public static class DataAccessServicesRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryIdentityContextConnection")));

            services.AddDbContext<LibraryDomainDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LibraryDomainContextConnection")));

            services.AddScoped(typeof(IAsyncDomainRepository<>), typeof(DomainBaseRepository<>));

            services.AddScoped(typeof(IAudiobooksRepository), typeof(AudiobooksRepository));
            services.AddScoped(typeof(IMagazinesRepository), typeof(MagazinesRepository));
            services.AddScoped(typeof(IBooksRepository), typeof(BooksRepository));
            services.AddScoped(typeof(IFilmsRepository), typeof(FilmsRepository));

            services.AddScoped(typeof(IPersonsRepository), typeof(PersonsRepository));
            services.AddScoped(typeof(ICompaniesRepository), typeof(CompaniesRepository));
            services.AddScoped(typeof(ITagsRepository), typeof(TagsRepository));

            return services;
        }
    }
}
