using Microsoft.Practices.Unity;
using Infrastructure.Interfaces;
using InfrastructureServices.Repositories;
using InfrastructureServices.Contexts;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

namespace DependencyInjection.Modules
{
    public class InfrastructureModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyContext>();

            optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MyContext"].ConnectionString);

            //var context = new MyContext(optionsBuilder.Options);
            //context.Database.EnsureCreated();

            using (var context = new MyContext(optionsBuilder.Options)) context.Database.EnsureCreated();

            container.RegisterType<MyContext>(
                //new HierarchicalLifetimeManager(),        
                //если раскомментировать, то будет singletone
                new InjectionConstructor(optionsBuilder.Options));

            container.RegisterType<IClientRepository, ClientRepository>(new ContainerControlledLifetimeManager());
            container.RegisterType<IAccountRepository, AccountRepository>(new ContainerControlledLifetimeManager());

            //container.RegisterType<IClientRepository, FakeRepository>(new HierarchicalLifetimeManager());
            //container.RegisterType<IAccountRepository, FakeRepository>(new HierarchicalLifetimeManager());

        }
    }
}
