using System;

class NhanVien
{
    // Field
    private string _maNV;
    private string _hoTen;
    private decimal _luongCoBan;
    private int _soNgayLam;
    private int _soNgayNghiPhep;

    // Constructor không tham số
    public NhanVien()
    {
        _maNV = "";
        _hoTen = "";
        _luongCoBan = 0;
        _soNgayLam = 0;
        _soNgayNghiPhep = 0;
    }

    // Constructor có mã NV và họ tên
    public NhanVien(string maNV, string hoTen)
    {
        _maNV = maNV;
        _hoTen = hoTen;
        _luongCoBan = 5_000_000;
        _soNgayLam = 26;
        _soNgayNghiPhep = 0;
    }

    // Constructor đầy đủ tham số
    public NhanVien(string maNV, string hoTen, decimal luongCoBan,
                    int soNgayLam, int soNgayNghiPhep)
    {
        _maNV = maNV;
        _hoTen = hoTen;
        LuongCoBan = luongCoBan;
        SoNgayLam = soNgayLam;
        _soNgayNghiPhep = soNgayNghiPhep;
    }

    // Constructor có Optional Parameters
    public NhanVien(string maNV, string hoTen,
                    decimal luong = 5_000_000, int soNgayLam = 26)
    {
        _maNV = maNV;
        _hoTen = hoTen;
        LuongCoBan = luong;
        SoNgayLam = soNgayLam;
        _soNgayNghiPhep = 0;
    }

    // Property HoTen
    public string HoTen
    {
        get { return _hoTen; }
        set { _hoTen = value; }
    }

    // Property LuongCoBan
    public decimal LuongCoBan
    {
        get { return _luongCoBan; }
        set
        {
            if (value >= 0)
                _luongCoBan = value;
        }
    }

    // Property SoNgayLam
    public int SoNgayLam
    {
        get { return _soNgayLam; }
        set
        {
            if (value >= 0 && value <= 31)
                _soNgayLam = value;
        }
    }

    // Lương thực nhận
    public decimal LuongThucNhan
    {
        get
        {
            decimal khauTruBHXH = _luongCoBan * 0.08m;
            return _luongCoBan / 26 * _soNgayLam - khauTruBHXH;
        }
    }

    // TinhThuong()
    public decimal TinhThuong()
    {
        return 0;
    }

    // TinhThuong(decimal heSo)
    public decimal TinhThuong(decimal heSo)
    {
        return _luongCoBan * heSo;
    }

    // TinhThuong(decimal heSo, bool coPhucLoi)
    public decimal TinhThuong(decimal heSo, bool coPhucLoi)
    {
        decimal thuong = _luongCoBan * heSo;

        if (coPhucLoi)
            thuong += 500_000;

        return thuong;
    }
}

class Program
{
    static void Main()
    {
        // Nhân viên 1: constructor không tham số
        NhanVien nv1 = new NhanVien();
        nv1.HoTen = "An";
        nv1.LuongCoBan = 6_000_000;
        nv1.SoNgayLam = 25;

        // Nhân viên 2: constructor mã NV + họ tên
        NhanVien nv2 = new NhanVien("NV002", "Binh");

        // Nhân viên 3: Optional Parameters + Named Arguments
        NhanVien nv3 = new NhanVien(
            maNV: "NV003",
            hoTen: "Chi",
            soNgayLam: 20
        );
        Console.WriteLine("       MSSV: 6551071011");
        // In lương
        Console.WriteLine("=== LUONG THUC NHAN ===");
        Console.WriteLine(nv1.HoTen + ": " + nv1.LuongThucNhan);
        Console.WriteLine(nv2.HoTen + ": " + nv2.LuongThucNhan);
        Console.WriteLine(nv3.HoTen + ": " + nv3.LuongThucNhan);

        // Gọi 3 overload TinhThuong
        Console.WriteLine("\n=== TINH THUONG ===");

        Console.WriteLine("TinhThuong(): "
            + nv3.TinhThuong());

        Console.WriteLine("TinhThuong(0.1): "
            + nv3.TinhThuong(0.1m));

        Console.WriteLine("TinhThuong(0.1, true): "
            + nv3.TinhThuong(0.1m, true));

        // So sánh
        Console.WriteLine("\n=== SO SANH ===");

        decimal thuong1 = nv3.TinhThuong();
        decimal thuong2 = nv3.TinhThuong(0.1m);
        decimal thuong3 = nv3.TinhThuong(0.1m, true);

        if (thuong1 > thuong2 && thuong1 > thuong3)
            Console.WriteLine("Thuong 1 cao nhat.");
        else if (thuong2 > thuong3)
            Console.WriteLine("Thuong 2 cao nhat.");
        else
            Console.WriteLine("Thuong 3 cao nhat.");

        Console.ReadLine();
    }
}
