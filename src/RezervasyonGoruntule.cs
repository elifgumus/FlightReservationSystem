using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace rezervasyon
{  public partial class RezervasyonGoruntule : Form
    {public RezervasyonGoruntule()
        {InitializeComponent();}
        SqlConnection baglan = new SqlConnection("Data Source = ServerName\\SQLEXPRESS; " +
            "Initial Catalog=rezervasyon; Integrated Security=True");
        void goster()
        {
            if (comboBox2.Text == "Female")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("spGetGender", baglan);
                komut.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(komut.ExecuteReader());
                dada.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox2.Text == "Male")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("spGetNameSurnameandGender", baglan);
                komut.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(komut.ExecuteReader());
                dada.DataSource = dt;
                baglan.Close();
            }
        }
        void sırala()
        {
            if (comboBox1.Text == "Child (0-12)")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("spGetBaby", baglan);
                komut.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(komut.ExecuteReader());
                dataGridView2.DataSource = dt;
                baglan.Close();
            }
            else if (comboBox1.Text == "Adult (12+)")
            {
                baglan.Open();
                SqlCommand komut = new SqlCommand("spGetAdult", baglan);
                komut.CommandType = CommandType.StoredProcedure;
                DataTable dt = new DataTable();
                dt.Load(komut.ExecuteReader());
                dataGridView2.DataSource = dt;
                baglan.Close();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa ty = new AnaSayfa();
            RezervasyonGoruntule.ActiveForm.Visible = false;
            ty.Show();
        }
        private void buttonSearch_Click(object sender, EventArgs e){}
        private void RezervasyonGoruntule_TextChanged(object sender, EventArgs e){}
        private void txtId_TextChanged(object sender, EventArgs e){}
        private void label1_Click(object sender, EventArgs e){}
        private void button1_Click(object sender, EventArgs e){}
        private void button1_Click_1(object sender, EventArgs e){}
        private void RezervasyonGoruntule_Load(object sender, EventArgs e)
        {
            this.tblBookTableAdapter.Fill(this.rezervasyonDataSet.tblBook);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            AnaSayfa aa = new AnaSayfa();
            RezervasyonGoruntule.ActiveForm.Visible = false;
            aa.Show();
        }
        private void label2_Click(object sender, EventArgs e){}
        private void button4_Click(object sender, EventArgs e)
        {
            sırala();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            goster();
        }
    }
}
