using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartFinances.Application.Factories;
using SmartFinances.Application.Interfaces.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartFinances.Application
{
    public static class ApplicationServicesConfiguration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountFactory, AccountFactory>();
            services.AddScoped<IExpenseFactory, ExpenseFactory>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
