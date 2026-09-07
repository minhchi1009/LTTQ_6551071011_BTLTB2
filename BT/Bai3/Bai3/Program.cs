using System;
using System.Collections.Generic;

// ==================== LỚP CHA ====================
class SanPham
{
    private string _maSP;
    private string _tenSP;
    private decimal _gia;
    private int _soLuongTon;

    // Property
    public string MaSP
    {
        get { return _maSP; }
        set { _maSP = value; }
    }

    public string TenSP
    {
        get { return _tenSP; }
        set { _tenSP = value; }
    }

    public decimal Gia
    {
        get { return _gia; }
        set { _gia = value; }
    }

    public int SoLuongTon
    {
        get { return _soLuongTon; }
        set { _soLuongTon = value; }
    }

    // Constructor đầy đủ
    public SanPham(string maSP, string tenSP, decimal gia, int soLuongTon)
    {
        _maSP = maSP;
        _tenSP = tenSP;
        _gia = gia;
        _soLuongTon = soLuongTon;
    }

    // Phương thức virtual
    public virtual decimal TinhGiaBan()
    {
        return _gia;
    }

    public virtual string MoTa()
    {
        return "Mã SP: " + _maSP +
               " | Tên: " + _tenSP +
               " | Giá: " + _gia +
               " | Tồn: " + _soLuongTon;
    }
}


// ==================== THỰC PHẨM ====================
class SanPhamThucPham : SanPham
{
    private DateTime _ngayHetHan;
    private int _nhietDoBaoQuan;

    public DateTime NgayHetHan
    {
        get { return _ngayHetHan; }
        set { _ngayHetHan = value; }
    }

    public int NhietDoBaoQuan
    {
        get { return _nhietDoBaoQuan; }
        set { _nhietDoBaoQuan = value; }
    }

    // Constructor gọi base
    public SanPhamThucPham(
        string maSP,
        string tenSP,
        decimal gia,
        int soLuongTon,
        DateTime ngayHetHan,
        int nhietDoBaoQuan)
        : base(maSP, tenSP, gia, soLuongTon)
    {
        _ngayHetHan = ngayHetHan;
        _nhietDoBaoQuan = nhietDoBaoQuan;
    }

    // Nếu còn 3 ngày thì giảm 30%
    public override decimal TinhGiaBan()
    {
        double soNgayConLai = (_ngayHetHan - DateTime.Now).TotalDays;

        if (soNgayConLai <= 3 && soNgayConLai >= 0)
        {
            return Gia * 0.7m;
        }

        return Gia;
    }

    public override string MoTa()
    {
        return base.MoTa() +
               " | Hạn: " + _ngayHetHan.ToString("dd/MM/yyyy") +
               " | Bảo quản: " + _nhietDoBaoQuan + "°C";
    }
}


// ==================== ĐIỆN TỬ ====================
class SanPhamDienTu : SanPham
{
    private int _baoHanhThang;
    private string _hangSanXuat;

    public int BaoHanhThang
    {
        get { return _baoHanhThang; }
        set { _baoHanhThang = value; }
    }

    public string HangSanXuat
    {
        get { return _hangSanXuat; }
        set { _hangSanXuat = value; }
    }

    public SanPhamDienTu(
        string maSP,
        string tenSP,
        decimal gia,
        int soLuongTon,
        int baoHanhThang,
        string hangSanXuat)
        : base(maSP, tenSP, gia, soLuongTon)
    {
        _baoHanhThang = baoHanhThang;
        _hangSanXuat = hangSanXuat;
    }

    // Bảo hành > 12 tháng thì cộng 10%
    public override decimal TinhGiaBan()
    {
        if (_baoHanhThang > 12)
        {
            return Gia * 1.1m;
        }

        return Gia;
    }

    public override string MoTa()
    {
        return base.MoTa() +
               " | Bảo hành: " + _baoHanhThang + " tháng" +
               " | Hãng: " + _hangSanXuat;
    }
}


// ==================== MAIN ====================
class Program
{
    static void Main()
    {
        // Hiển thị tiếng Việt
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("==========================================");
        Console.WriteLine("       QUẢN LÝ SẢN PHẨM CỬA HÀNG");
        Console.WriteLine("       MSSV: 6551071011");
        Console.WriteLine("==========================================");
        Console.WriteLine();

        // Tạo danh sách chứa cả 3 loại sản phẩm
        List<SanPham> danhSach = new List<SanPham>();

        // Object Initializer
        SanPham sp1 = new SanPham(
            "SP001",
            "Nước ngọt",
            10000,
            50)
        {
            TenSP = "Coca Cola"
        };

        SanPhamThucPham sp2 = new SanPhamThucPham(
            "TP001",
            "Sữa tươi",
            30000,
            20,
            DateTime.Now.AddDays(2),
            5)
        {
            TenSP = "Sữa tươi Vinamilk"
        };

        SanPhamDienTu sp3 = new SanPhamDienTu(
            "DT001",
            "Điện thoại",
            8000000,
            10,
            24,
            "Samsung")
        {
            TenSP = "Samsung Galaxy"
        };

        // Thêm vào danh sách
        danhSach.Add(sp1);
        danhSach.Add(sp2);
        danhSach.Add(sp3);

        // Tính tổng giá trị kho
        decimal tongGiaTriKho = 0;

        Console.WriteLine("DANH SÁCH SẢN PHẨM");
        Console.WriteLine("------------------------------------------");

        // foreach gọi phương thức của từng lớp
        // Đây chính là đa hình tại runtime
        foreach (SanPham sp in danhSach)
        {
            Console.WriteLine(sp.MoTa());

            decimal giaBan = sp.TinhGiaBan();

            Console.WriteLine("Giá bán: " + giaBan + " VNĐ");

            tongGiaTriKho += giaBan * sp.SoLuongTon;

            Console.WriteLine("------------------------------------------");
        }

        Console.WriteLine();
        Console.WriteLine("==========================================");
        Console.WriteLine("TỔNG GIÁ TRỊ KHO: " + tongGiaTriKho + " VNĐ");
        Console.WriteLine("MSSV: 6551071011");
        Console.WriteLine("==========================================");

        Console.WriteLine();
        Console.WriteLine("Nhấn Enter để kết thúc...");
        Console.ReadLine();
    }
}