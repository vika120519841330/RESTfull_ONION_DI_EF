using Microsoft.Practices.Unity;
using Domain.Interfaces;
using DomainServices.Services;

namespace DependencyInjection.Modules
{
    public class DomainModule : IModule
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IAccount, AccountService>(new HierarchicalLifetimeManager());
            container.RegisterType<IClient, ClientService>(new HierarchicalLifetimeManager());
        }
    }
}
