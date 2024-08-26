using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generic.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infrastructure
{
    public static class AppDbContextConfig
    {
        public static IServiceCollection AddDIDbContextAndUnityOfWork(this IServiceCollection services)
        {
            services.AddScoped<AppDbContext>();
            services.AddScoped<IUnityOfWork,UnityOfWork>();
            return services;
        }
    }
}
