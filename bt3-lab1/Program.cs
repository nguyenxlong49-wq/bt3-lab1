using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bt3_lab1
{
    struct MatHang
    {
        public int MaMH;
        public string TenMH;
        public int SoLuong;
        public double DonGia;

       
        public MatHang(int ma, string ten, int soLuong, double donGia)
        {
            MaMH = ma;
            TenMH = ten;
            SoLuong = soLuong;
            DonGia = donGia;
        }

        
        public double ThanhTien()
        {
            return SoLuong * DonGia;
        }
    }
    internal class Program
    {
        static void ThemMatHang(List<MatHang> ds, MatHang mh)
        {
            ds.Add(mh);
        }
        static bool TimMatHang(List<MatHang> ds, int ma)
        {
            foreach (MatHang mh in ds)
            {
                if (mh.MaMH == ma)
                    return true;
            }
            return false;
        }
        static void XuatDanhSach(List<MatHang> ds)
        {
            if (ds.Count == 0)
            {
                Console.WriteLine("Danh sách rỗng!");
                return;
            }

            Console.WriteLine("{0,-8}{1,-20}{2,-10}{3,-12}{4,-12}",
                              "Mã MH", "Tên MH", "Số lượng", "Đơn giá", "Thành tiền");
            foreach (MatHang mh in ds)
            {
                Console.WriteLine("{0,-8}{1,-20}{2,-10}{3,-12}{4,-12}",
                                  mh.MaMH, mh.TenMH, mh.SoLuong, mh.DonGia, mh.ThanhTien());
            }
        }
        static bool XoaMatHang(List<MatHang> ds, int ma)
        {
            for (int i = 0; i < ds.Count; i++)
            {
                if (ds[i].MaMH == ma)
                {
                    ds.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        static int NhapSoNguyen(string thongBao)
        {
            int kq;
            Console.Write(thongBao);
            while (!int.TryParse(Console.ReadLine(), out kq))
                Console.Write("Giá trị không hợp lệ! " + thongBao);
            return kq;
        }

        static double NhapSoThuc(string thongBao)
        {
            double kq;
            Console.Write(thongBao);
            while (!double.TryParse(Console.ReadLine(), out kq))
                Console.Write("Giá trị không hợp lệ! " + thongBao);
            return kq;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            List<MatHang> ds = new List<MatHang>();

            // 1. Nhập danh sách mặt hàng
            string tiepTuc = "c";
            do
            {
                Console.WriteLine("--- Nhập mặt hàng ---");
                int ma = NhapSoNguyen("Mã mặt hàng: ");

                if (TimMatHang(ds, ma))
                {
                    Console.WriteLine("Mã mặt hàng đã tồn tại, vui lòng nhập mã khác!");
                    continue;
                }

                Console.Write("Tên mặt hàng: ");
                string ten = Console.ReadLine();
                int soLuong = NhapSoNguyen("Số lượng: ");
                double donGia = NhapSoThuc("Đơn giá: ");

                ThemMatHang(ds, new MatHang(ma, ten, soLuong, donGia));

                Console.Write("Tiếp tục nhập? (c/k): ");
                tiepTuc = Console.ReadLine();
            } while (tiepTuc != null && tiepTuc.Trim().ToLower() == "c");

        }
    }
}
