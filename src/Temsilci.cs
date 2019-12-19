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
{
    public partial class Temsilci : Form
    {
        public Temsilci()
        {InitializeComponent();}
        SqlConnection cn = new SqlConnection("Data Source = ServerName\\SQLEXPRESS; " +
            "Initial Catalog=rezervasyon; Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        private void label2_Click(object sender, EventArgs e){ }
        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("InsertCustome", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@Name", SqlDbType.NVarChar,(50));
            param[0].Value = textBox1.Text;
            param[1] = new SqlParameter("@Surname", SqlDbType.NVarChar, (50));
            param[1].Value = textBox2.Text;
            param[2] = new SqlParameter("@MobileNumber", SqlDbType.NVarChar, (50));
            param[2].Value = textBox3.Text;
            param[3] = new SqlParameter("@Email", SqlDbType.NVarChar, (50));
            param[3].Value = textBox4.Text;
            cn.Open();
            cmd.Parameters.AddRange(param);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Information Added.I'll get back to you as soon as possible	.", 
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        private void button2_Click(object sender, EventArgs e)
        { AnaSayfa aa = new AnaSayfa();
            Temsilci.ActiveForm.Visible = false;
            aa.Show();}
    }
}
