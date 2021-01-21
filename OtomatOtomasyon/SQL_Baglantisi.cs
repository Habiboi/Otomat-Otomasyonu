using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomatOtomasyon
{
    public class SQL_Baglantisi
    {
        public int userIndex = -1;

        private static OracleConnection MyConnection()
        {
            return new OracleConnection("User Id=HABIBOI;Password=1234;Data Source=localhost:1521/XEPDB1");
        }

        public static bool LoginControl(int loginIndex, string username, string password)
        {
            string tableName;
            if (loginIndex == 1)
            {
                tableName = "YONETICI";
            }
            else
            {
                tableName = "CALISAN";
            }

            OracleConnection con = MyConnection();
            string query = "SELECT * FROM " + tableName + " WHERE KULLANICI_ADI='" + username + "' AND SIFRE='" + password + "'";
            OracleDataAdapter da = new OracleDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int i = dt.Rows.Count;

            con.Close();
            if (i == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void TabloListele(DataGridView dataGridView, string tablo)
        {
            OracleConnection con = MyConnection();
            con.Open();
            OracleDataAdapter da = new OracleDataAdapter("SELECT * FROM " + tablo, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView.DataSource = dt;
            con.Close();
        }

        public static void OtomatBakimGuncelle(int otomatNo,string metin)
        {
            OracleConnection con = MyConnection();
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE OTOMAT SET BAKIM = '" + metin + "' WHERE OTOMAT_NO='" + otomatNo + "'";
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void KayitSil(string tablo, string noQuery)
        {
            string query = "DELETE FROM " + tablo + " WHERE " + noQuery;
            OracleConnection con = MyConnection();
            con.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Connection = con;
            cmd.ExecuteNonQuery();
        }

        public static void OtomatEkle(string il, string ilce, string mahalle, string sokak)
        {
            OracleConnection con = MyConnection();
            OracleCommand cmd = new OracleCommand("OTOMAT_EKLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_IL", OracleDbType.Char).Value = il;
            cmd.Parameters.Add("P_ILCE", OracleDbType.Char).Value = ilce;
            cmd.Parameters.Add("P_MAHALLE", OracleDbType.Char).Value = mahalle;
            cmd.Parameters.Add("P_SOKAK", OracleDbType.Char).Value = sokak;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UrunEkle(string ad, string fiyat)
        {
            OracleConnection con = MyConnection();
            OracleCommand cmd = new OracleCommand("URUN_EKLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_AD", OracleDbType.Char).Value = ad;
            cmd.Parameters.Add("P_FIYAT", OracleDbType.Char).Value = fiyat;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void CalisanEkle(string ad,string kullanici,string ekip,string sifre)
        {
            OracleConnection con = MyConnection();
            OracleCommand cmd = new OracleCommand("CALISAN_EKLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_AD", OracleDbType.Char).Value = ad;
            cmd.Parameters.Add("P_KULLANICI", OracleDbType.Char).Value = kullanici;
            cmd.Parameters.Add("P_EKIP", OracleDbType.Char).Value = ekip;
            cmd.Parameters.Add("P_SIFRE", OracleDbType.Char).Value = sifre;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void YoneticiEkle(string ad,string kullanici,string sifre,string bolge)
        {
            OracleConnection con = MyConnection();
            OracleCommand cmd = new OracleCommand("OTOMAT_EKLE", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("P_AD", OracleDbType.Char).Value = ad;
            cmd.Parameters.Add("P_KULLANICI", OracleDbType.Char).Value = kullanici;
            cmd.Parameters.Add("P_SIFRE", OracleDbType.Char).Value = sifre;
            cmd.Parameters.Add("P_BOLGE", OracleDbType.Char).Value = bolge;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void OtomatGuncelle(string il, string ilce, string mahalle, string sokak, int no)
        {
            OracleConnection con = MyConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE OTOMAT SET IL='" + il + "', ILCE='" + ilce + "', MAHALLE='" + mahalle + "', SOKAK='" + sokak + "' WHERE OTOMAT_NO='" + no + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UrunGuncelle(string ad, string fiyat, int no)
        {
            OracleConnection con = MyConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE URUN SET URUN_AD='" + ad + "', FIYAT='" + fiyat + "' WHERE URUN_NO='" + no + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void CalisanGuncelle(string ad, string kullanici, int no)
        {
            OracleConnection con = MyConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE CALISAN SET AD='" + ad + "', KULLANICI_ADI='" + kullanici + "' WHERE CALISAN_NO='" + no + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void YoneticiGuncelle(string ad, string kullanici, int no)
        {
            OracleConnection con = MyConnection();
            con.Open();
            OracleCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "UPDATE YONETICI SET AD='" + ad + "', KULLANICI_ADI='" + kullanici + "' WHERE YONETICI_NO='" + no + "'";
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
