using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace rezervasyon
{
    public partial class CiftYon : Form
    {
        public CiftYon()
        {InitializeComponent();}
        SqlConnection baglanti = new SqlConnection("Data Source = ServerName\\SQLEXPRESS; " +
            "Initial Catalog=rezervasyon; Integrated Security=True");
        private void button1_Click(object sender, EventArgs e)
        {
            Ekle();
            txtID.Clear();
            txtName.Clear();
            txtSurname.Clear();
            comboBoxG.ResetText();
            txtAge.Clear();
            txtEmail.Clear();
            txtMN.Clear();
            comboFrom.ResetText();
            comboTo.ResetText();
            comboCT.ResetText();
            comboSN.ResetText();
            comboDD1.ResetText();
            comboDD2.ResetText();
            comboRD1.ResetText();
            comboRD2.ResetText();
            comboDT.ResetText();
            comboRT.ResetText();
        }
        private void comboFrom_SelectedIndexChanged(object sender, EventArgs e)
        {}
        void Ekle()
        {
            baglanti.Open();
            String kayit = "insert into tblBook (ID,Name,Surname,Gender,Age,Email,MobileNumber,DepartureAirport," +
                "ArrivalAirport,CabinType,SeatNumber,DepartureDay,DepartureMonth,ArrivalDay,ArrivalMonth," +
                "DepartureTime,ArrivalTime) values('" + txtID.Text + "','" + txtName.Text + "'," +
                "'" + txtSurname.Text + "','" + comboBoxG.Text + "','" + txtAge.Text + "','" + txtEmail.Text + "'," +
                "'" + txtMN.Text + "','" + comboFrom.Text + "','" + comboTo.Text + "','" + comboCT.Text + "'," +
                "'" + comboSN.Text + "','" + comboDD1.Text + "','" + comboDD2.Text + "','" + comboRD1.Text + "'," +
                "'" + comboRD2.Text + "','" + comboDT.Text + "','" + comboRT.Text + "')";
            SqlCommand komut = new SqlCommand(kayit, baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            baglanti.Close();
            MessageBox.Show("Flight Added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa aa = new AnaSayfa();
            TekYon.ActiveForm.Visible = false;
            aa.Show();
        }
    }
}
