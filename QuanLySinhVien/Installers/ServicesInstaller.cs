using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using QuanLySinhVien.ORM;

namespace QuanLySinhVien
{
    public class ServicesInstaller : IWindsorInstaller
    {
        /// <summary>
        /// Hàm thiết lập tùy chỉnh để đăng ký các Components vào DI container
        /// </summary>
        void IWindsorInstaller.Install(IWindsorContainer container, IConfigurationStore store)
        {
            //QuanLy class registered
            container.Register(
                Component
                    .For<QuanLy>()
                    .LifestyleTransient());
            //IDataBase implementation registered
            container.Register(
                Component
                    .For<IDataBase>()
                    .ImplementedBy<SQLDataBase>()
                    .LifestyleTransient());
            //IDataBase implementation registered
            container.Register(
                Component
                    .For<IDataBase>()
                    .ImplementedBy<XMLDataBase>()//Để test
                    .LifestyleTransient());
            //IORM implementation registered
            container.Register(
                Component
                    .For<IORM>()
                    .ImplementedBy<DB_NHibernate>()
                    .LifestyleTransient());
            //IORM implementation registered
            container.Register(
                Component
                    .For<IORM>()
                    .ImplementedBy<DB_Dapper>()//Để test
                    .LifestyleTransient());
            
        }       
    }
}
