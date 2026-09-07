using System;

namespace QuanLySachCoBan
{
    class Sach
    {
        private string _maSach;
        private string _tenSach;
        private string _tacGia;
        private int _namXuatBan;
        private double _giaBan;

        // Constructor đầy đủ
        public Sach(string ma, string ten, string tacGia, int nam, double gia)
        {
            _maSach = ma;
            TenSach = ten;
            _tacGia = tacGia;
            NamXuatBan = nam;
            _giaBan = gia;
        }

        // Constructor mặc định
        public Sach()
        {
            _maSach = "S000";
            _tenSach = "Chưa có tên";
            _tacGia = "Chưa có tác giả";
            _namXuatBan = 2026;
            _giaBan = 0;
        }

        // Property
        public string MaSach
        {
            get { return _maSach; }
        }

        public string TenSach
        {
            get { return _tenSach; }
            set
            {
                if (value == "")
                    throw new Exception("Tên sách không được rỗng!");
                _tenSach = value;
            }
        }

        public string TacGia
        {
            get { return _tacGia; }
            set { _tacGia = value; }
        }

        public int NamXuatBan
        {
            get { return _namXuatBan; }
            set
            {
                if (value < 1900 || value > DateTime.Now.Year)
                    throw new Exception("Năm xuất bản không hợp lệ!");

                _namXuatBan = value;
            }
        }

        public double GiaBan
        {
            get { return _giaBan; }
        }

        // Hiển thị thông tin
        public void HienThiThongTin()
        {
            Console.WriteLine("Mã sách: " + MaSach);
            Console.WriteLine("Tên sách: " + TenSach);
            Console.WriteLine("Tác giả: " + TacGia);
            Console.WriteLine("Năm xuất bản: " + NamXuatBan);
            Console.WriteLine("Giá bán: " + GiaBan);
            Console.WriteLine();
        }

        // ToString
        public override string ToString()
        {
            return MaSach + " - " + TenSach + " - " + TacGia;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // Cách 1: Constructor đầy đủ
            Sach sach1 = new Sach(
                "S01",
                "Lập trình C#",
                "Nguyen Van A",
                2023,
                100000
            );

            // Cách 2: Constructor mặc định rồi gán
            Sach sach2 = new Sach();
            sach2.TenSach = "Cơ sở dữ liệu";
            sach2.TacGia = "Nguyen Van B";
            sach2.NamXuatBan = 2022;

            // Cách 3: Object Initializer
            Sach sach3 = new Sach
            {
                TenSach = "Lập trình hướng đối tượng",
                TacGia = "Nguyen Van C",
                NamXuatBan = 2024
            };
            Console.WriteLine("       MSSV: 6551071011");
            // Hiển thị
            sach1.HienThiThongTin();
            sach2.HienThiThongTin();
            sach3.HienThiThongTin();

            // Thử nhập năm sai
            try
            {
                sach1.NamXuatBan = 1800;
            }
            catch (Exception e)
            {
                Console.WriteLine("Lỗi: " + e.Message);
            }

            Console.ReadKey();
        }
    }
}
