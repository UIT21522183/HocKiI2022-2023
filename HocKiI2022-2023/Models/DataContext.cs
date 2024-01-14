using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Cryptography;

namespace HocKiI2022_2023.Models
{
    public class DataContext : DbContext
    {
        public string ConnectString { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectString);
        }

        public int SqlInsertHK(HANHKHACH hk)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=quanlychuyenbay;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "INSERT INTO HANHKHACH (MAHK, HOTEN, DIACHI, SDT) VALUES (@MAHK, @HOTEN, @DIACHI, @SDT);";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHK", hk.MaHK);
                cmd.Parameters.AddWithValue("@HOTEN", hk.HoTen);
                cmd.Parameters.AddWithValue("@DIACHI", hk.DiaChi);
                cmd.Parameters.AddWithValue("@SDT", hk.DienThoai);
                return cmd.ExecuteNonQuery();
            }
        }
        //SqlGetChuyenBay
        public CHUYENBAY SqlGetChuyenBay(string MaChuyenbay)
        {
            CHUYENBAY cn = new CHUYENBAY();
            string connection = "server=localhost;user id=root;password=;port=3306;database=quanlychuyenbay;";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "SELECT * FROM CHUYENBAY WHERE MACH=@MACHUYENBAY;";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("@MACHUYENBAY", MaChuyenbay);
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    cn.MaCH = reader["MACH"].ToString();
                    cn.GBay = reader["GBAY"].ToString();
                    cn.GDen = reader["GDEN"].ToString();
                    cn.MaMB = reader["MAMB"].ToString();
                    cn.Thuong = Convert.ToInt32(reader["THUONG"].ToString());
                    cn.Vip = Convert.ToInt32(reader["VIP"].ToString());
                    cn.Chuyen = reader["CHUYEN"].ToString();
                    cn.DDi = reader["DDI"].ToString();
                    cn.DDen = reader["DDEN"].ToString();
                    cn.Ngay = reader["NGAY"].ToString();
                    reader.Close();
                }
                return cn;
            }
        }

        public List<object> SqlGetHKChuyenBay(string MaChuyenbay)
        {
            List<object> list = new List<object>();
            string connection = "server=localhost;user id=root;password=;port=3306;database=quanlychuyenbay;";

            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string str = "SELECT ct.MAHK,HOTEN,SOGHE,LOAIGHE,SDT FROM HANHKHACH hk JOIN CT_CB ct ON ct.MAHK = hk.MAHK WHERE ct.MACH =@MACHUYENBAY";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("MACHUYENBAY", MaChuyenbay);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            MaHK = reader["MAHK"].ToString(),
                            HoTen = reader["HOTEN"].ToString(),
                            SoGhe = reader["SOGHE"].ToString(),
                            LoaiGhe = Convert.ToBoolean(reader["LOAIGHE"]),
                            DienThoai = reader["SDT"].ToString()
                        };
                        list.Add(ob);
                    }
                    reader.Close();
                }
                return list;
            }
        }
        //SqlInsertHKChuyenBay
        public int SqlInsertHKChuyenBay(CT_CB cb,string HoTen)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=quanlychuyenbay;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "INSERT INTO CT_CB  VALUES (@MACH, @MAHK, @SOGHE, @LOAIGHE);";
                string query2 = "INSERT INTO HANHKHACH VALUES(@MAHK,@TENHK,'','');";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@MAHK", cb.MaHK);
                cmd2.Parameters.AddWithValue("@TENHK", HoTen);
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHK", cb.MaHK);
                cmd.Parameters.AddWithValue("@MACH", cb.MaCH);
                cmd.Parameters.AddWithValue("@SOGHE", cb.SoGhe);
                cmd.Parameters.AddWithValue("@LOAIGHE", cb.LoaiGhe);
                return cmd.ExecuteNonQuery(); 
            }
        }

        //SqlUpdateHanhKhachTrongChuyen
        public int SqlUpdateHanhKhachTrongChuyen(CT_CB cb, string HoTen,string maHKCu)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=quanlychuyenbay;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "UPDATE CT_CB SET LOAIGHE=@LOAIGHE,SOGHE=@SOGHE WHERE MAHK=@MAHKCU AND MACH=@MACH;";
                string query2 = "UPDATE HANHKHACH SET HOTEN=@HOTEN WHERE MAHK=@MAHKCU;";
                MySqlCommand cmd2 = new MySqlCommand(query2, conn);
                cmd2.Parameters.AddWithValue("@HOTEN", HoTen);
                cmd2.Parameters.AddWithValue("@MAHKCU", maHKCu);
                cmd2.ExecuteNonQuery();

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHK", cb.MaHK);
                cmd.Parameters.AddWithValue("@MACH", cb.MaCH);
                cmd.Parameters.AddWithValue("@SOGHE", cb.SoGhe);
                cmd.Parameters.AddWithValue("@LOAIGHE", cb.LoaiGhe);
                cmd.Parameters.AddWithValue("@MAHKCU", maHKCu);
                return cmd.ExecuteNonQuery();
            }
        }
        //SqlDeleteHanhKhachTrongChuyen
        public int SqlDeleteHanhKhachTrongChuyen(string maHK,string maCH)
        {
            string connection = "server=localhost;user id=root;password=;port=3306;database=quanlychuyenbay;";
            using (MySqlConnection conn = new MySqlConnection(connection))
            {
                conn.Open();
                string query = "DELETE FROM CT_CB  WHERE MAHK=@MAHK AND MACH=@MACH;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MAHK", maHK);
                cmd.Parameters.AddWithValue("@MACH", maCH);
                return cmd.ExecuteNonQuery();
            }
        }

    }
}
