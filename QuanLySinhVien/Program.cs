using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace QuanLySinhVien
{
    /// <summary>
    /// Using Dependency Injection for DataBase
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            QuanLy dssv = new QuanLy(new SQLDataBase());
            int chon = 0;        
            do
            {
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
                        dssv.database.ExtractDB(ref dssv.list_SV, ref dssv.list_MH);
                        dssv.AutoImportScoreSV();
                        break;
                    case 2:
                        dssv.showListSV();
                        break;
                    case 3:                
                        dssv.SearchInfoSV();
                        break;
                    case 4:
                        dssv.SearchListMHSV();
                        break;
                    case 5:                       
                        dssv.ShowListScoreSV();
                        break;
                    case 6:
                        dssv.ImportScoreSV();
                        break;
                    case 7:
                        dssv.CheckPassedMH();
                        break;
                    default:
                        Console.WriteLine("EXIT!");
                        break;
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
