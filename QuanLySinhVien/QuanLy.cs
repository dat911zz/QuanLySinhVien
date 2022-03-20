using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
namespace QuanLySinhVien
{
    /// <summary>
    /// Class for Quan Ly Sinh Vien
    /// </summary>
    public class QuanLy : Viewer
    {
        //==================================================================
        //Contructor & Destructor
        public QuanLy() { }
        ~QuanLy() { }
        //==================================================================
        //Properties

        public List<SinhVien> list_SV = new List<SinhVien>();
        public List<MonHoc> list_MH = new List<MonHoc>();
        public IDataBase database;

        /// <summary>
        /// Using Constructor Injection
        /// </summary>
        /// <param name="database">Inject module DB into QuanLy</param>
        public QuanLy(IDataBase database)
        {
            this.database = database;
        }
        //==================================================================
        //Method      
        //----------------------------------------------------------
        /// <summary>
        /// Import data from file
        /// </summary>
        /// <param name="list"></param>

        //Đọc file sinh viên
        public void ReadFile_SV(string fname)
        {
            string[] line;
            //Đọc giá trị từ file
            try
            {
                line = File.ReadAllLines($"../../../{fname}.txt");
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t_[Doc file khong thanh cong!]_\t");
                Console.ResetColor();
                return;
            }
            try
            {
                for (int i = 0; i < line.Length; ++i)
                {
                    SinhVien x = new SinhVien();
                    string[] data = line[i].Split(' ');
                    //-------------INPUT DATA----------------
                    x.setData(data[0], data[1], data[2], DateTime.Parse(data[3]), data[4], data[5]);
                    //---------------------------------------
                    //Thêm phần tử vào cuối DSLK
                    list_SV.Add(x);
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\t_[Doc file thanh cong!]_\t");
                Console.ResetColor();
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
                return;
            }
        }
        //Đọc file môn học
        public void ReadFile_MH(string fname)
        {
            string[] line;
            //Đọc giá trị từ file
            try
            {
                line = File.ReadAllLines($"../../../{fname}.txt");
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\t_[Doc file khong thanh cong!]_\t");
                Console.ResetColor();
                return;
            }
            try
            {

                for (int i = 0; i < line.Length; ++i)
                {
                    MonHoc x = new MonHoc();
                    string[] data = line[i].Split(' ');
                    //-------------INPUT DATA----------------
                    x.setData(data[0], int.Parse(data[1]));
                    //---------------------------------------
                    //Thêm phần tử vào cuối DSLK
                    list_MH.Add(x);
                }
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\t_[Doc file thanh cong!]_\t");
                Console.ResetColor();
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
                return;
            }
        }
        //Auto đăng ký học phần
        public void AutoDKMH_SV(string fname)
        {
            string[] line;
            //Đọc giá trị từ file
            try
            {
                line = File.ReadAllLines($"../../../{fname}.txt");
            }
            catch (IOException e)
            {
                Console.Write(e.Message);
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\t_[Doc file khong thanh cong!]_\t");
                Console.ResetColor();
                return;
            }
            try
            {

                for (int i = 0; i < line.Length; ++i)
                {
                    string[] data = line[i].Split(' ');
                    List<MonHoc> tmp = new List<MonHoc>(list_MH.ToArray());
                    //-------------INPUT DATA----------------
                    //SinhVien x = new SinhVien();
                    for (int mh_i = 0; mh_i < data.Length; mh_i++)
                    {


                        if (data[mh_i].ToString() == "1")
                        {
                            //========Deep copy========= 
                            var c = tmp[mh_i].Clone();
                            list_SV[i].MonHocDK.Add((MonHoc)c);
                        }
                    }
                    Thread.Sleep(50);
                    Console.BackgroundColor = ConsoleColor.DarkGreen;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\tStaged {0}: passed", i);
                    Console.ResetColor();
                    Console.WriteLine();
                }

            }
            catch (IOException e)
            {
                Console.Write(e.Message);
                return;
            }
        }
        //Auto nhập điểm sinh viên
        public void AutoImportScore()
        {
            Random score1 = new Random();
            Random score2 = new Random();

            for (int i = 0; i < list_SV.Count; i++)
            {
                for (int j = 0; j < list_SV[i].MonHocDK.Count; j++)
                {
                    list_SV[i].MonHocDK[j].setDiem(score1.Next(1, 10), score2.Next(2, 10));
                }
            }
        }
        //----------------------------------------------------------
        /// <summary>
        /// Import data from Database
        /// </summary>
        public void GetDataBase()
        {
            database.Extract(ref list_SV, ref list_MH);
        }

        //----------------------------------------------------------
        /// <summary>
        /// Functions
        /// </summary>

        //Hiện danh sách sinh viên
        public void showList()
        {
            Console.WriteLine("\n\t\t\t-Danh sach sinh vien-");
            Khuon_SV();
            Console.ResetColor();
            if (list_SV.Count < 1)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\t  [EMPTY LIST!]");
                Console.ResetColor();
                return;
            }
            for (int i = 0; i < list_SV.Count; i++)
            {
                list_SV[i].showData();
            }
        }
        //Hiện danh sách tên sinh viên
        public void showListName()
        {
            Console.Write("\n-Danh sach ten SV hien co: ");
            foreach (var item in list_SV)
            {
                Console.Write($"\n\t{item.getTenSV()}");
            }
        }
        //Module tìm tên sinh viên
        public SinhVien searchName(string name)
        {
            foreach (var item in list_SV)
            {
                if (string.Equals(item.getTenSV(), name) == true)
                {
                    return item;
                }
            }
            return null;
        }
        //Tìm thông tin sinh viên
        public void SearchInfo()
        {

            SinhVien x;
            string name, flag;
        retype:
            Console.Clear();
            showListName();
            Console.Write("\nVui long nhap ten sinh vien can tim: ");
            name = Console.ReadLine();
            x = searchName(name);
            if (x == null)
            {
                Console.Write("\nVui long nhap lai!");
                goto retype;
            }
            Console.Write("\n\t-=Thong tin cua sinh vien=-");
            x.getInfo();
            Console.Write("\nBan co muon tim tiep (Y/N): ");
            flag = Console.ReadLine();
            if (flag == "Y" || flag == "y")
            {
                goto retype;
            }
            return;
        }
        //Tìm thông tin các môn học của sinh viên
        public void SearchListMH()
        {

            SinhVien x;
            string name, flag;
        retype:
            Console.Clear();
            showListName();
            Console.Write("\nVui long nhap ten sinh vien can tim: ");
            name = Console.ReadLine();
            x = searchName(name);
            if (x == null)
            {
                Console.Write("\nVui long nhap lai!");
                goto retype;
            }
            Console.Write("\n\t-=Thong tin cac mon hoc cua sinh vien=-");
            x.showMonHocDaDK();
            Console.Write("\nBan co muon tim tiep (Y/N): ");
            flag = Console.ReadLine();
            if (flag == "Y" || flag == "y")
            {
                goto retype;
            }
            return;
        }
        //Xuất danh sách điểm của toàn bộ sinh viên
        public void ShowListScore()
        {
            Console.Write("\n\t\t\t-=Danh sach diem cua SV=-");
            for (int i = 0; i < list_SV.Count; i++)
            {
                Console.Write($"\n\n\t\t\t   -Sinh vien: {list_SV[i].getTenSV()}-\n\n");
                Khuon_MH_Full();
                for (int j = 0; j < list_SV[i].MonHocDK.Count; j++)
                {
                    if (list_SV[i].MonHocDK[j].isPass() == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    list_SV[i].MonHocDK[j].showInfo_SV();
                    Console.ResetColor();
                    Console.WriteLine();
                }
            }
        }
        //Nhập điểm cho sinh viên
        public void ImportScore()
        {
            SinhVien x;
            string name, flag;
        retype:
            Console.Clear();
            showListName();
            Console.Write("\nVui long nhap ten sinh vien can nhap diem: ");
            name = Console.ReadLine();
            x = searchName(name);
            if (x == null)
            {
                Console.Write("\nVui long nhap lai!");
                goto retype;
            }
            x.inputScore();
            Console.Write("\nBan co muon nhap diem cho sinh vien khac (Y/N): ");
            flag = Console.ReadLine();
            if (flag == "Y" || flag == "y")
            {
                goto retype;
            }
            return;
        }
        //Xem kết quả trượt/đỗ của sinh viên
        public void CheckPassedMH()
        {
            SinhVien x;
            string name, flag;
        retype:
            Console.Clear();
            showListName();
            Console.Write("\nVui long nhap ten sinh vien can kiem tra: ");
            name = Console.ReadLine();
            x = searchName(name);
            if (x == null)
            {
                Console.Write("\nVui long nhap lai!");
                goto retype;
            }

            Console.Write($"\n\n\t\t\t   -Sinh vien: {x.getTenSV()}-\n\n");
            Khuon_MH_Full();
            for (int i = 0; i < x.MonHocDK.Count; i++)
            {
                if (x.MonHocDK[i].isPass() == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                x.MonHocDK[i].showInfo_SV();
                Console.ResetColor();
                Console.WriteLine();
            }

            Console.Write("\nBan co muon coi ket qua cua sinh vien khac (Y/N): ");
            flag = Console.ReadLine();
            if (flag == "Y" || flag == "y")
            {
                goto retype;
            }
            return;
        }
    }
    /// <summary>
    /// Class phụ 
    /// </summary>
    public class Viewer
    {
        public void DuongKe()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.Write("-");
            }
        }
        public void Khuon_SV()
        {
            Console.WriteLine("Ma SV\t\tTen SV\t\t   Gioi Tinh\tNgay Sinh\tLop\t\tKhoa");
            DuongKe();
        }
        public void Khuon_MH()
        {
            Console.Write("Ten MH\t\t\tSo tiet\n");
            DuongKe();
        }
        public void Khuon_MH_Full()
        {
            Console.Write("\tTen MH\t\t\tSo tiet\t  Diem: TP\tQT\tTK\tKet qua\n");
            DuongKe();
            Console.WriteLine();
        }
        public void showCurrentListMH(List<MonHoc> list_MH)
        {
            Console.WriteLine("\nDanh sach mon hoc hien co trong CSDL: \n");
            Khuon_MH();
            foreach (var item in list_MH)
            {
                item.showInfo();
            }
        }
    }
}