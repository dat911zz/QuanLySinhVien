using System;
using Castle.Windsor;

namespace QuanLySinhVien
{
    /// <summary>
    /// *Update: 
    /// Using Dependency Injection Container for Database
    /// </summary>
    class Program
    {       
        static void Main(string[] args)
        {
            //NHibernateProfilerBootstrapper.PreStart();
            
            //Lúc chưa áp dụng DI container
            //QuanLy dssv = new QuanLy(new SQLDataBase());

            //==================================================
            //Áp dụng DI container bằng Windsor Castle framework

            //Bắt đầu chương trình
            WindsorContainer container = new WindsorContainer();
            //Thêm và cấu hình tất cả các thành phần bằng WindsorInstaller
            container.Install(new ServicesInstaller());
            //Khởi tạo và cấu hình thành phần gốc và tất cả các phụ thuộc liên quan đến nó
            QuanLy dssv = container.Resolve<QuanLy>();
            //Dọn dẹp
            container.Dispose();

            
            //==================================================
            int chon = 0;        
            do
            {
                Console.ResetColor();
                Console.Clear();
                menu();
                
                Console.Write("\nChon: ");
                if (int.TryParse(Console.ReadLine(), out chon) == false)
                {
                    return;
                }
                Console.Clear();
                switch (chon)
                {
                    case 1:
                        //dssv.GetDataWithNHibernate();
                        Console.WriteLine("\nPlease wait for few seconds!");
                        dssv.GetDataWithORM();
                        //dssv.GetDataBase();
                        dssv.AutoImportScore();
                        break;
                    case 2:
                        dssv.showList();
                        break;
                    case 3:                
                        dssv.SearchInfo();
                        break;
                    case 4:
                        dssv.SearchListMH();
                        break;
                    case 5:                       
                        dssv.ShowListScore();
                        break;
                    case 6:
                        dssv.ImportScore();
                        break;
                    case 7:
                        dssv.CheckPassedMH();
                        break;
                    default:
                        Console.WriteLine("EXIT!");
                        GC.Collect();
                        return;
                }
                Console.ReadLine();
                Console.Clear();              
            } while (chon > 0 && chon < 9);
        }
        static void menu()
        {
            Console.Write("\n     ========Chuong trinh quan ly sinh vien========");
            Console.Write("\n\t\t1. Lay data tu CSDL");
            Console.Write("\n\t\t2. Xuat danh sach sinh vien");
            Console.Write("\n\t\t3. Xuat thong tin sinh vien");
            Console.Write("\n\t\t4. Xem so mon hoc");
            Console.Write("\n\t\t5. Xem so diem mon hoc");
            Console.Write("\n\t\t6. Nhap diem sinh vien");
            Console.Write("\n\t\t7. Xem ket qua hoc tap\n");
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }
    }
    
}

