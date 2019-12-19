using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace rezervasyon
{ public partial class Customer : Form
    { public Customer(){InitializeComponent();}
        int id = 0;
        SqlConnection baglan = new SqlConnection("Data Source = ServerName\\SQLEXPRESS; " +
            "Initial Catalog=rezervasyon; Integrated Security=True");
        private void Bul()
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select *from tblBook where ID like '%" + textBox1.Text + "%'", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["ID"].ToString();
                ekle.SubItems.Add(oku["Name"].ToString());
                ekle.SubItems.Add(oku["Surname"].ToString());
                ekle.SubItems.Add(oku["Gender"].ToString());
                ekle.SubItems.Add(oku["Age"].ToString());
                ekle.SubItems.Add(oku["Email"].ToString());
                ekle.SubItems.Add(oku["MobileNumber"].ToString());
                ekle.SubItems.Add(oku["DepartureAirport"].ToString());
                ekle.SubItems.Add(oku["ArrivalAirport"].ToString());
                ekle.SubItems.Add(oku["CabinType"].ToString());
                ekle.SubItems.Add(oku["SeatNumber"].ToString());
                ekle.SubItems.Add(oku["DepartureDay"].ToString());
                ekle.SubItems.Add(oku["DepartureMonth"].ToString());
                ekle.SubItems.Add(oku["ArrivalDay"].ToString());
                ekle.SubItems.Add(oku["ArrivalMonth"].ToString());
                ekle.SubItems.Add(oku["DepartureTime"].ToString());
                ekle.SubItems.Add(oku["ArrivalTime"].ToString());
                listView1.Items.Add(ekle);
            }
            baglan.Close();
        }
        private void Customer_MouseDoubleClick(object sender, MouseEventArgs e){}
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);
            txtID.Text=listView1.SelectedItems[0].SubItems[0].Text;
            txtName.Text = listView1.SelectedItems[0].SubItems[1].Text;
            txtSurname.Text = listView1.SelectedItems[0].SubItems[2].Text;
            comboBoxG.Text = listView1.SelectedItems[0].SubItems[3].Text;
            txtAge.Text = listView1.SelectedItems[0].SubItems[4].Text;
            txtEmail.Text = listView1.SelectedItems[0].SubItems[5].Text;
            txtMN.Text = listView1.SelectedItems[0].SubItems[6].Text;
            comboFrom.Text = listView1.SelectedItems[0].SubItems[7].Text;
            comboTo.Text = listView1.SelectedItems[0].SubItems[8].Text;
            comboCT.Text = listView1.SelectedItems[0].SubItems[9].Text;
            comboSN.Text = listView1.SelectedItems[0].SubItems[10].Text;
            comboDD1.Text = listView1.SelectedItems[0].SubItems[11].Text;
            comboDD2.Text=listView1.SelectedItems[0].SubItems[12].Text;
            comboRD1.Text = listView1.SelectedItems[0].SubItems[13].Text;
            comboRD2.Text = listView1.SelectedItems[0].SubItems[14].Text;
            comboDT.Text = listView1.SelectedItems[0].SubItems[15].Text;
            comboRT.Text = listView1.SelectedItems[0].SubItems[16].Text;
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e){}
        private void radioButton2_CheckedChanged(object sender, EventArgs e){}
        private void buttonSearch_Click(object sender, EventArgs e){Bul();}
        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Delete from tblBook where ID =("+ textBox1.Text + ")" , baglan);
            komut.ExecuteNonQuery();
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
            MessageBox.Show("Flight Deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglan.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglan.Open();
            SqlCommand komut = new SqlCommand("Update tblBook set Email ='"+ txtEmail.Text.ToString()+ "'," +
                "MobileNumber ='" + txtMN.Text.ToString() + "',ArrivalAirport ='" + comboTo.Text.ToString() + "'," +
                "CabinType ='" + comboCT.Text.ToString() + "',SeatNumber ='" + comboSN.Text.ToString() + "'," +
                "DepartureDay ='" + comboDD1.Text.ToString() + "',DepartureMonth ='" + comboDD2.Text.ToString() + "'," +
                "ArrivalDay ='" + comboRD1.Text.ToString() + "',ArrivalMonth ='" + comboRD2.Text.ToString() + "'," +
                "DepartureTime ='" + comboDT.Text.ToString() + "',ArrivalTime='" + comboRT.Text.ToString() + "'where ID="+ id+ "", 
                baglan);
            komut.ExecuteNonQuery();
            MessageBox.Show("Flight Updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            baglan.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AnaSayfa aa = new AnaSayfa();
            Customer.ActiveForm.Visible = false;
            aa.Show();
        }
    }
}
