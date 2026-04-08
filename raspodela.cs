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

namespace dnevnik410a
{
    public partial class raspodela : Form
    {
        public raspodela()
        {
            InitializeComponent();
        }

        private void raspodela_Load(object sender, EventArgs e)
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM raspodela", veza);
            DataTable raspodela = new DataTable();
            da.Fill(raspodela);

            da = new SqlDataAdapter("SELECT * FROM skolska_godina",veza);
            DataTable sk_godina = new DataTable();
            da.Fill(sk_godina);
            comboBox1.DataSource= sk_godina;
            comboBox1.ValueMember= "id";
            comboBox1.DisplayMember = "naziv";
            comboBox1.SelectedValue = raspodela.Rows[0]["godina_id"].ToString();

            da = new SqlDataAdapter("SELECT id, ime+' '+prezime as nastavnik FROM osoba", veza);
            DataTable osoba = new DataTable();
            da.Fill(osoba);
            comboBox2.DataSource = osoba;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "nastavnik";
            comboBox2.SelectedValue = raspodela.Rows[0]["nastavnik_id"].ToString();

            da = new SqlDataAdapter("SELECT * FROM predmet", veza);
            DataTable predmet = new DataTable();
            da.Fill(predmet);
            comboBox3.DataSource = predmet;
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "naziv";
            comboBox3.SelectedValue = raspodela.Rows[0]["predmet_id"].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
