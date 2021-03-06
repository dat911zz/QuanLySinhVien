using System;
using System.Text.Json;
using System.Drawing;
using Castle.Windsor;
using System.IO;
using System.Text;
using System.Reflection;

namespace QuanLySinhVien
{
    /// <summary>
    /// *Update: 
    /// Using Dapper and NHibernate library
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
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Graphic gp = new Graphic();
            
            do
            {
                Console.ResetColor();
                Console.Clear();
                gp.DrawForm();
                Console.ResetColor();
                menu();
                
                if (int.TryParse(Console.ReadLine(), out chon) == false)
                {
                    return;
                }
                Console.Clear();
                Console.ResetColor();
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
                    case 8:
                        string jsonString = JsonSerializer.Serialize(dssv.list_SV);
                        
                        //string[] arr = jsonString.Split("]}");
                        //foreach (var item in arr)
                        //{
                        //    Console.WriteLine("\n\n" + item);
                        //}
                        string fname = "../../../JSONs/Test01.json";
                        File.WriteAllText(fname, jsonString);
                        break;
                    default:
                        Console.WriteLine("EXIT!");
                        Console.WriteLine("Cleaning up...");
                        GC.Collect();
                        return;
                }
                Console.ReadLine();
                Console.Clear();              
            } while (chon > 0 && chon < 9);
        }
        static void menu()
        {
            int y = 7;
            Console.SetCursorPosition(25, y++);
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("========Chương trình quản lý sinh viên========");
            Console.ResetColor();
            y = 9;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(35, y++);

            Console.Write("1. Lay data tu CSDL");
            Console.SetCursorPosition(35, y++);

            Console.Write("2. Xuat danh sach sinh vien");
            Console.SetCursorPosition(35, y++);

            Console.Write("3. Xuat thong tin sinh vien");
            Console.SetCursorPosition(35, y++);

            Console.Write("4. Xem so mon hoc");
            Console.SetCursorPosition(35, y++);

            Console.Write("5. Xem so diem mon hoc");
            Console.SetCursorPosition(35, y++);

            Console.Write("6. Nhap diem sinh vien");
            Console.SetCursorPosition(35, y++);

            Console.Write("7. Xem ket qua hoc tap");
            Console.SetCursorPosition(42, y++);

            Console.Write("Chọn: ");
        }

        static void test()
        {
            string relative = @"C:\Users\Asus\source\repos\QuanLySinhVien\QuanLySinhVien";
            Console.WriteLine(Path.GetRelativePath(relative, @"C:\Users\Asus\source\repos\QuanLySinhVien\QuanLySinhVien\Files\dssv.txt"));
            string deskDir = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            StreamWriter wr = new StreamWriter(deskDir + "//test2.txt", true, Encoding.Unicode);
            string path = System.IO.Path.GetDirectoryName(
                      Environment.SpecialFolder.Programs.ToString());

            string folderName = AppDomain.CurrentDomain.BaseDirectory;
            
            string file = System.IO.Path.Combine(path, $@"..\..\..\Files\dssv.txt");
            Console.WriteLine(wr.GetHashCode());
        }
    }
    
}

