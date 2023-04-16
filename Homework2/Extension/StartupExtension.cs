using AutoMapper;
using Homework2.Data.Model;
using Homework2.Data.Repository.Abstract;
using Homework2.Data.Repository.Concrete;
using Homework2.Data.UnitOfWork.Abstract;
using Homework2.Data.UnitOfWork.Concrete;
using Homework2.Service.Abstract;
using Homework2.Service.Concrete;
using Homework2.Service.Mapper;

namespace Homework2.Extension
{
    public static class StartUpExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();
        }

        public static void AddMapperService(this IServiceCollection services)
        {
            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }

        public static void AddBussinesServices(this IServiceCollection services)
        {
            services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
            services.AddScoped<IGenericRepository<Person>, GenericRepository<Person>>();

            // services
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenManagementService, TokenManagementService>();
        }
    }
}
