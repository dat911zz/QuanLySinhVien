using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace QuanLySinhVien
{
    public class ServicesInstaller : IWindsorInstaller
    {
        void IWindsorInstaller.Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(
                Component
                    .For<IDataBase>()
                    .ImplementedBy<SQLDataBase>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<IDataBase>()
                    .ImplementedBy<XMLDataBase>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<ITest>()
                    .ImplementedBy<Dependency1>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<ITest>()
                    .ImplementedBy<Dependency2>()
                    .LifestyleTransient());
            container.Register(
                Component
                    .For<QuanLy>()
                    .LifestyleTransient());
        }       
    }
}
