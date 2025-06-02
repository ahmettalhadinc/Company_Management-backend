using Autofac;
using Company_Management.Core.Repository;
using Company_Management.Core.Services;
using Company_Management.Core.UnitOfWorks;
using Company_Management.Repository;
using Company_Management.Repository.Repositories;
using Company_Management.Repository.UnitOfWorks;
using Company_Management.Service.Mappings;
using Company_Management.Service.Services;
using System.Reflection;
using Module=Autofac.Module

namespace Company_Management.API.Modules
{
    public class RepoServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>)).
                InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>))
                .As(typeof(IService<>)).
                InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWorks>().As<IUnitOfWorks>();

            var apiAssembly= Assembly.GetExecutingAssembly();
            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            var serviceAssembly= Assembly.GetAssembly(typeof(MapProfile));

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x=>x.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(apiAssembly, repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service"))
               .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}
