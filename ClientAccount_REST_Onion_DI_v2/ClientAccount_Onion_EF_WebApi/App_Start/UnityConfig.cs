using DependencyInjection;
using DependencyInjection.Modules;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ClientAccount_Onion_EF_WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // ������������ ������ � ������ ���������� container

            Registre<DomainModule>(container);
            Registre<InfrastructureModule>(container);


            // ������������� dependency-resolver ��� ������ ����������, ������� ����� �������������� ���
            // ���������� ������������ ��������� container

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        // �������������� ��������� ������ � �������� ����� Register, ��������� ������� container 
        // ��� ����������� ������������
        private static void Registre<T>(IUnityContainer container) where T : IModule, new()
        {
            new T().Register(container);
        }
    }
}