using Microsoft.Extensions.DependencyInjection;
using Person.Repository;
using Person.Repository.Implementation;

namespace Person.Mediator
{
    public static class PersonMediatorDI
    {
        public static IServiceCollection AddPersonMediator(this IServiceCollection services)
        {
            services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(PersonMediatorDI).Assembly));
            return services;
        }
        public static IServiceCollection AddPersonRepository(this IServiceCollection services)
        {
            services.AddScoped<IPersonRepository,PersonRepositoryRelImp>();
            return services;
        }
    }
}
