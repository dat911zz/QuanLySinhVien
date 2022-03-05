using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace QuanLySinhVien
{
    class Program
    {
        static void Main(string[] args)
        {
            QuanLy dssv = new QuanLy();
            string fname;
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
                        Console.Write("\nNhap ten file can lay thong tin: ");
                        fname = Console.ReadLine();
                        dssv.ReadFile_SV(fname);
                        dssv.ReadFile_MH("MonHoc");
                        dssv.AutoDKMH_SV("DKHP");
                        dssv.AutoImportScoreSV();
                        break;
                    case 2:
                        dssv.showListSV();
                        break;
                    case 3:
                        //dssv.showCurrentListMH(dssv.list_MH);
                        //dssv.list_SV[2].dangKyMonHoc(dssv.list_MH);                      
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
                    case 8:
                        DataBase test = new DataBase();
                        test.ExtractDB(ref dssv.list_SV, ref dssv.list_MH);
                        dssv.AutoImportScoreSV();
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
            Console.Write("\n\t\t1. Doc File");
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
