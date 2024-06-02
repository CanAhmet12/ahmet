using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KütapaneÖDEVPROJE
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e )
        {
            this.Text = "Kütüphane Uygulaması Versiyon " + Assembly.GetExecutingAssembly().GetName().Version;
            Options();
            GetAllBooks();
            dataGridView1.Columns["ID"].Visible = false;

            if (Kütüphane.UserID == null || Kütüphane.UserID <= 0)
            {
                MessageBox.Show("Geçersiz Kullanıcı ID'si.");
                return;
            }

            string connectionString = Kütüphane.constr2;
            string query = "SELECT ID, Adı, Soyadı, Meslek, Şehir, DoğumTarihi FROM User1 WHERE ID = @ID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                // Kullanıcı ID'sini parametre olarak ekleyin
                command.Parameters.AddWithValue("@ID", Kütüphane.UserID);

                try
                {
                    connection.Open();
                 
                   

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        label6.Text = reader["Adı"].ToString();
                        label7.Text = reader["Soyadı"].ToString();
                        label8.Text = reader["Meslek"].ToString();
                        label9.Text = reader["Şehir"].ToString();
                        label10.Text = reader["DoğumTarihi"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı bulunamadı.");
                    }
                    reader.Close();
                }
                catch (SqlException sqlEx)
                {
                    MessageBox.Show("SQL Hatası: " + sqlEx.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                }

            }
          






        }

        private void GetAllBooks()
        {
          
           dataGridView1.DataSource = Kütüphane.GetBooks().Tables[0];

        }

        private void Options()
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Giriş sayfanınsa yönlendirileceksiniz \nDevam etmek isitoyrmuusnuz?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Form1 yeni = new Form1();
                yeni.Show();
                this.Hide();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form6 yeni = new Form6();
            yeni.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            
        }
        public static void UserData()
        {





        }

        private void BİLGİLERİM_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
