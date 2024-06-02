using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Windows.Forms;

namespace KütapaneÖDEVPROJE
{
    internal class Kütüphane
    {
        public static int KitapID = 0;
        public static int UserID = 0;

        public static bool serach = false;
        public static string constr = "Data Source=.\\SQLEXPRESS;Initial Catalog=BookSave;Integrated Security=True;";
        public static string constr2 = "Data Source=.\\SQLEXPRESS;Initial Catalog=UserSave;Integrated Security=True;";
        public static void BookSave(int ID, string KitapAdı, string BarkodNo, string Yazar, int SayfaNo, string Tür, string Dil, string YayınEvi, string Yıl, string KayıtTarihi)
        {
            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand(" if not exists  (select * from Book where ID = @ID) insert into Book (BarkodNo , KitapAdı , Yazar , SayfaNo , Tür , Dil , YayınEvi , Yıl , KayıtTarihi) values (@BarkodNo , @KitapAdı , @Yazar , @SayfaNo , @Tür , @Dil , @YayınEvi , @Yıl , @KayıtTarihi) else update Book set   BarkodNo= @BarkodNo , KitapAdı=@KitapAdı , Yazar=@Yazar , SayfaNo=@SayfaNo , Tür=@Tür , Dil=@Dil , YayınEvi=@YayınEvi , Yıl=@Yıl , KayıtTarihi= @KayıtTarihi where ID = @ID", con);
            com.Parameters.AddWithValue("@ID", KitapID);
            com.Parameters.AddWithValue("@KitapAdı", KitapAdı);
            com.Parameters.AddWithValue("@BarkodNo", BarkodNo);
            com.Parameters.AddWithValue("@Yazar", Yazar);
            com.Parameters.AddWithValue("@SayfaNo", SayfaNo);
            com.Parameters.AddWithValue("Tür", Tür);
            com.Parameters.AddWithValue("@Dil", Dil);
            com.Parameters.AddWithValue("@YayınEvi", YayınEvi);
            com.Parameters.AddWithValue("@Yıl", Yıl);
            com.Parameters.AddWithValue("@KayıtTarihi", DateTime.Now.ToString("dd - MM - yyyy"));
            con.Open();
            com.ExecuteNonQuery();
            con.Close();


        }
        public static void UserSave(int ID, String Adı, string Soyadı, string Meslek, string Şehir, string DoğumTarihi, string KullanıcıAdı, string Şifre, string şifreTekrar)
        {
            SqlConnection con = new SqlConnection(constr2);
            SqlCommand com = new SqlCommand("if not exists (select * from User1 where ID = @ID) insert into User1 (Adı , Soyadı , Meslek , Şehir , DoğumTarihi , KullanıcıAdı , Şifre , ŞifreTekrar) values ( @Adı ,@Soyadı ,@Meslek ,@Şehir , @DoğumTarihi , @KullanıcıAdı  , @Şifre , @ŞifreTekrar) else update User1 set   Adı=@Adı , Soyadı=@Soyadı , Meslek=@Meslek , Şehir=@Şehir , DoğumTarihi=@DoğumTarihi , KullanıcıAdı=@KullanıcıAdı  , Şifre=@Şifre , ŞifreTekrar=@ŞifreTekrar   where @ID =@ID", con);
            com.Parameters.AddWithValue("@ID", UserID);
            com.Parameters.AddWithValue("@Adı", Adı);
            com.Parameters.AddWithValue("@Soyadı", Soyadı);
            com.Parameters.AddWithValue("@Meslek", Meslek);
            com.Parameters.AddWithValue("@Şehir", Şehir);
            com.Parameters.AddWithValue("@DoğumTarihi", DoğumTarihi);
            com.Parameters.AddWithValue("@KullanıcıAdı", KullanıcıAdı);
            com.Parameters.AddWithValue("@Şifre", Şifre);
            com.Parameters.AddWithValue("@ŞifreTekrar", şifreTekrar);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();


        }
        public static DataSet GetBooks()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter("select ID as [ID] , KitapAdı as [Kitap Adı] , BarkodNo as [Barkod Numarası] , Yazar as [Yazar] , SayfaNo as [Sayfa Numarası] , Tür as [Tür] , Dil as [Dil] , YayınEvi  as [Yayın Evi] , Yıl as [Yıl] , KayıtTarihi  as [Arşive Kayıt Tarihi] from Book  ", con);
            da.Fill(ds);
            return ds;

        }
        public static DataSet GetUser()
        {
            DataSet ds = new DataSet();
            SqlConnection con = new SqlConnection(constr2);
            SqlDataAdapter da = new SqlDataAdapter("select ID as [ID] , Adı [Adı] , Soyadı as [Soyadı] , Meslek as [Meslek] , Şehir as [Şehir] , DoğumTarihi as [Doğum Tarihi] , KullanıcıAdı as [Kullanıcı Adı] , Şifre as [Şifre] from User1   ", con);
            da.Fill(ds);
            return ds;


        }
        public static void DeleteBook()
        {

            SqlConnection con = new SqlConnection(constr);
            SqlCommand com = new SqlCommand("Delete from Book where ID=@ID", con);
            com.Parameters.AddWithValue("ID", KitapID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        public static void DeleteUser()
        {

            SqlConnection con = new SqlConnection(constr2);
            SqlCommand com = new SqlCommand("Delete from User1 where ID=@ID", con);
            com.Parameters.AddWithValue("ID", UserID);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

        public static DataSet BookSource(string text, string radiobutton)
        {
            DataSet ds = new DataSet();
            using (SqlConnection con = new SqlConnection(constr))
            {
                string query = "";
                SqlCommand com = new SqlCommand();

                switch (radiobutton)
                {
                    case "BarkodNo":
                        query = "SELECT ID, KitapAdı, BarkodNo, Yazar, SayfaNo, Tür, Dil, YayınEvi, Yıl, KayıtTarihi FROM Book WHERE BarkodNo LIKE @text";
                        break;
                    case "KitapAdı":
                        query = "SELECT ID, KitapAdı, BarkodNo, Yazar, SayfaNo, Tür, Dil, YayınEvi, Yıl, KayıtTarihi FROM Book WHERE KitapAdı LIKE @text";
                        break;
                    case "Yazar":
                        query = "SELECT ID, KitapAdı, BarkodNo, Yazar, SayfaNo, Tür, Dil, YayınEvi, Yıl, KayıtTarihi FROM Book WHERE Yazar LIKE @text";
                        break;
                }

                com = new SqlCommand(query, con);
                com.Parameters.AddWithValue("@text", "%" + text + "%");

                SqlDataAdapter da = new SqlDataAdapter(com);
                da.Fill(ds);
            }
            return ds;
        }
        public static void UserUpdate(int ID, string adı, string soyadı, string Meslek, string Şehir, string DoğumTarihi, string KullanıcıAdı, string Şifre, string ŞifreTekrar)
        {
            using (SqlConnection con = new SqlConnection(constr2))
            {
                string query = @"
        IF EXISTS (SELECT * FROM User1 WHERE ID = @ID)
        BEGIN
            UPDATE User1 
            SET Adı=@Adı, Soyadı=@Soyadı, Meslek=@Meslek, Şehir=@Şehir, DoğumTarihi=@DoğumTarihi, KullanıcıAdı=@KullanıcıAdı, Şifre=@Şifre, ŞifreTekrar=@ŞifreTekrar 
            WHERE ID=@ID
        END
        ELSE
        BEGIN
            PRINT 'User not found';
        END";

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    // Parametreler ekleniyor
                    command.Parameters.AddWithValue("@ID", UserID);
                    command.Parameters.AddWithValue("@Adı", adı);
                    command.Parameters.AddWithValue("@Soyadı", soyadı);
                    command.Parameters.AddWithValue("@Meslek", Meslek);
                    command.Parameters.AddWithValue("@Şehir", Şehir);
                    command.Parameters.AddWithValue("@DoğumTarihi", DoğumTarihi);
                    command.Parameters.AddWithValue("@KullanıcıAdı", KullanıcıAdı);
                    command.Parameters.AddWithValue("@Şifre", Şifre);
                    command.Parameters.AddWithValue("@ŞifreTekrar", ŞifreTekrar);

                    // Bağlantı açılıyor ve komut çalıştırılıyor
                    con.Open();
                    command.ExecuteNonQuery();
                    con.Close();
                }
            }



        }

    }
}
    







