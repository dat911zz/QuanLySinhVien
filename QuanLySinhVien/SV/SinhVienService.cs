using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.SV
{
    public class SinhVienService
    {
        //private Viewer view = new Viewer();
        private SinhVien sv { get; set; }
        private Viewer view { get; set; }
        public SinhVienService(SinhVien sv)
        {
            this.sv = sv;
            this.view = new Viewer();
        }

        /// <summary>
        /// Get info of SinhVien
        /// </summary>

        //Nhập thông tin sinh viên (thủ công)
        public SinhVien Input()
        {
            
            Console.WriteLine("-Nhap thong tin cua sinh vien-");
            Console.Write("\nMa sinh vien: ");
            sv.MaSV = Convert.ToString(Console.ReadLine());
            Console.Write("\nHo ten: ");
            sv.TenSV = Convert.ToString(Console.ReadLine());
            Console.Write("\nGioi tinh: ");
            sv.GioiTinh = Convert.ToString(Console.ReadLine());

            DateTime date = new DateTime();
            bool flag;
            do
            {
                Console.Write("\nNhap ngay sinh(mm/dd/yy) :");//theo thứ tự tháng/ngày/năm
                flag = DateTime.TryParse(Console.ReadLine(), out date);
                if (flag == false)
                {
                    Console.WriteLine("KHONG DUNG DINH DANG, VUI LONG NHAP LAI!");
                }

            } while (flag == false);
            sv.NgaySinh = date;
            Console.Write("\nLop: ");
            sv.Lop = Convert.ToString(Console.ReadLine());
            Console.Write("\nKhoa: ");
            sv.Khoa = Convert.ToString(Console.ReadLine());
            return sv;
        }
        
        //Trả về tên sinh viên
        public string getTenSV()
        {
            return sv.TenSV;
            int n;
            string s;
            List<int> ds = new List<int>();
            ds.Reverse();
            ds.BinarySearch(2);
            int[,] mt = new int[2, 2];
        }
        //Xuất thông tin sinh viên
        public void getInfo()
        {
            Console.Write($"\nMSSV: {sv.MaSV}\nHo ten: {sv.TenSV}\nGioi tinh: {sv.GioiTinh}\nNgay sinh: {sv.NgaySinh.ToShortDateString()}\nLop: {sv.Lop}\nKhoa: {sv.Khoa}\n");
        }
        //Đăng ký môn học
        public virtual void dangKyMonHoc(List<MonHoc> list_MH)
        {

            string pick;
            view.showCurrentListMH(list_MH);
            Console.WriteLine();
            view.DuongKe();
            Console.Write("\n-Dang Ky Mon Hoc-");
            foreach (var item in list_MH)
            {
                item.showInfo_DK();
                Console.Write("\nDang ky? (Y/N): ");
                pick = Console.ReadLine();
                if (pick == "Y" || pick == "y")
                {
                    sv.MHDK.Add(item);
                }
            }
            showMonHocDaDK();

        }
        //Xuất danh sách môn học sinh viên đã đăng ký
        public virtual void showMonHocDaDK()
        {
            Console.Write("\n\t---Cac mon hoc da dang ky---\n");
            Console.Write($"\nSo luong: {sv.MHDK.Count}\n");
            view.DuongKe();
            view.showCurrentListMH(sv.MHDK);
        }
        //Tìm môn học trong danh sách đã đăng ký
        public virtual MonHoc searchMonHocDaDK(string name)
        {
            foreach (var item in sv.MHDK)
            {
                if (string.Equals(item.tenMH, name) == true)
                {
                    return item;
                }
            }
            return null;
        }
        //Nhập điểm cho sinh viên
        public virtual void inputScore()
        {
            MonHoc x;
            string name, flag;
        retype:
            Console.Clear();
            showMonHocDaDK();
            Console.Write("\nVui long nhap ten mon hoc can nhap diem: ");
            name = Console.ReadLine();
            x = searchMonHocDaDK(name);
            if (x == null)
            {
                Console.Write("\nVui long nhap lai!");
                goto retype;
            }
            Console.Write("\n\t-=Thong tin cua sinh vien=-");
            x.inputScore();
            Console.Write("\nBan co muon nhap diem mon khac (Y/N): ");
            flag = Console.ReadLine();
            if (flag == "Y" || flag == "y")
            {
                goto retype;
            }
        }
        //Xuất thông tin sinh viên (theo hàng ngang)
        public void showData()
        {
            Console.Write("\n{0,-11}\t{1,-18}\t{2,-3}\t{3}/{4}/{5}\t{6,-11}\t{7}", sv.MaSV, sv.TenSV, sv.GioiTinh, sv.NgaySinh.Day, sv.NgaySinh.Month, sv.NgaySinh.Year, sv.Lop, sv.Khoa);
        }
    }
}
