using Blog.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;

namespace Blog.API.ExtensionMethods
{
    public static class Extensions
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            var applicationServicesAssembly = Assembly.Load(nameof(Blog.Application));
            var applicationInterfaces = applicationServicesAssembly
                .GetTypes()
                .Where(x => 
                    x.IsInterface && 
                    x.Name.EndsWith("Service") && 
                    x.Namespace.Contains("Blog.Application"))
                .ToList();

            foreach(var intrface in applicationInterfaces)
            {
                AddImplementations(services, applicationServicesAssembly, intrface);
            }

            var persistenceServicesAssembly = Assembly.Load(nameof(Blog.Persistence));
            var persistenceServicesInterfaces = applicationServicesAssembly
                .GetTypes()
                .Where(x =>
                    x.IsInterface &&
                    x.Name.EndsWith("Persistence") &&
                    x.Namespace.Contains("Blog.Persistence"))
                .ToList();

            foreach (var intrface in persistenceServicesInterfaces)
            {
                AddImplementations(services, persistenceServicesAssembly, intrface);
            }
        }

        private static void AddImplementations(IServiceCollection services, Assembly assembly, System.Type intrface)
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
