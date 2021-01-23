using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;
using System;

namespace Blog.API.ExtensionMethods
{
    public static class Extensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            var applicationServicesAssembly = Assembly.Load("Blog.Application");
            var applicationInterfaces = applicationServicesAssembly
                .GetTypes()
                .Where(x => 
                    x.IsInterface && 
                    x.Name.EndsWith("Service"))
                .ToList();

            foreach(var intrface in applicationInterfaces)
            {
                AddImplementations(services, applicationServicesAssembly, intrface);
            }

            var persistenceServicesAssembly = Assembly.Load("Blog.Persistence");
            var persistenceServicesInterfaces = persistenceServicesAssembly
                .GetTypes()
                .Where(x =>
                    x.IsInterface &&
                    x.Name.EndsWith("Persistence"))
                .ToList();

            foreach (var intrface in persistenceServicesInterfaces)
            {
                AddImplementations(services, persistenceServicesAssembly, intrface);
            }
        }

        private static void AddImplementations(IServiceCollection services, Assembly assembly, Type intrface)
        {
            var implementingClasses = assembly
                .GetTypes()
                .Where(x => x.Name != intrface.Name && intrface.IsAssignableFrom(x))
                .ToList();

            if(implementingClasses.Count == 1)
            {
                services.AddTransient(intrface, implementingClasses.FirstOrDefault());
            }
            else
            {
                throw new System.Exception($"interface {intrface.Name} should have only single concrete implementation");
            }
        }
    }
}
