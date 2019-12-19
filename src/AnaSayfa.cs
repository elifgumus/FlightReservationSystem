using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace rezervasyon
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {InitializeComponent();}
        private void btnRoundTrip_Click(object sender, EventArgs e)
        {
           CiftYon rt = new CiftYon();
           AnaSayfa.ActiveForm.Visible = false;
            rt.Show();  
        }
        private void btnOneWay_Click(object sender, EventArgs e)
        {
            TekYon ty = new TekYon();
            AnaSayfa.ActiveForm.Visible = false;
            ty.Show();
        }
        private void btnView_Click(object sender, EventArgs e)
        {
            RezervasyonGoruntule ty = new RezervasyonGoruntule();
            AnaSayfa.ActiveForm.Visible = false;
            ty.Show();
        }
        private void btnOperations_Click(object sender, EventArgs e)
        {
            Customer aa = new Customer();
            AnaSayfa.ActiveForm.Visible = false;
            aa.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Temsilci ty = new Temsilci();
            AnaSayfa.ActiveForm.Visible = false;
            ty.Show();
        }
    }
}
