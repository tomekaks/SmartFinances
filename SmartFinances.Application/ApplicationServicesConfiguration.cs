using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SmartFinances.Application.Factories;
using SmartFinances.Application.Interfaces.Factories;
using SmartFinances.Application.Interfaces.Services;
using SmartFinances.Application.Services;
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
            services.AddScoped<IRegularExpenseFactory, RegularExpenseFactory>();
            services.AddScoped<ITransferFactory, TransferFactory>();

            services.AddScoped<IAuthService, AuthService>();

            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
