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
    public partial class upisnica : Form
    {
        public upisnica()
        {
            InitializeComponent();
        }

        private void Combo1Populate()
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM skolska_godina", veza);
            DataTable godina = new DataTable();
            adapter.Fill(godina);
            comboBox1.DataSource=godina;
            comboBox1.ValueMember= "id";
            comboBox1.DisplayMember= "naziv";
        }
        private void Combo2Populate()
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, razred, indeks, godina_id, str(razred)+'-'+indeks as naziv FROM odeljenje", veza);
            DataTable odeljenje = new DataTable();
            adapter.Fill(odeljenje);
            comboBox2.DataSource = odeljenje;
            comboBox2.ValueMember = "id";
            comboBox2.DisplayMember = "naziv";
        }
        private void Combo3Populate()
        {
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT id, prezime+' '+ime as naziv FROM osoba", veza);
            DataTable ucenik = new DataTable();
            adapter.Fill(ucenik);
            comboBox3.DataSource = ucenik;
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "naziv";
        }
        private void DataGridPopulate()
        {
            SqlConnection veza = konekcija.povezi();
            string naredba = "SELECT upisnica.id, ime+' '+prezime as ucenik, str(razred)+'-'+indeks as odel, odeljenje.godina_id as god_id, odeljenje.id as odel_id, osoba.id as os_id from upisnica JOIN osoba ON osoba_id=osoba.id JOIN odeljenje ON odeljenje_id=odeljenje.id";
            SqlDataAdapter adapter = new SqlDataAdapter(naredba, veza);
            DataTable upisnica = new DataTable();
            adapter.Fill(upisnica);
            dataGridView1.DataSource = upisnica;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Columns["god_id"].Visible = false;
            dataGridView1.Columns["odel_id"].Visible = false;
            dataGridView1.Columns["os_id"].Visible = false;
        }
        private void upisnica_Load(object sender, EventArgs e)
        {
            Combo1Populate();
            Combo2Populate();
            Combo3Populate();
            DataGridPopulate();
            textBox1.Enabled=false;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow!=null)
            {
                int broj_sloga = dataGridView1.CurrentRow.Index;
                comboBox1.SelectedValue = dataGridView1.Rows[broj_sloga].Cells["god_id"].Value.ToString();
                comboBox2.SelectedValue = dataGridView1.Rows[broj_sloga].Cells["odel_id"].Value.ToString();
                comboBox3.SelectedValue = dataGridView1.Rows[broj_sloga].Cells["os_id"].Value.ToString();
                textBox1.Text = dataGridView1.Rows[broj_sloga].Cells["id"].Value.ToString();  
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string naredba = "INSERT INTO upisnica (odeljenje_id, osoba_id) VALUES(";
            naredba += comboBox2.SelectedValue.ToString() + ", ";
            naredba += comboBox3.SelectedValue.ToString() + ")";
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch(Exception greska)
            {
                MessageBox.Show(greska.Message);
            }

            DataGridPopulate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string naredba = "UPDATE upisnica SET osoba_id = " + comboBox3.SelectedValue.ToString();
            naredba += ", odeljenje_id=" + comboBox2.SelectedValue.ToString();
            naredba += " WHERE id=" + textBox1.Text;
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message);
            }
            DataGridPopulate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string naredba = "DELETE FROM upisnica WHERE id=" + textBox1.Text;
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message);
            }
            DataGridPopulate();
        }
    }
}
