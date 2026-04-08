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
using System.Reflection.Emit;

namespace dnevnik410a
{
    public partial class Form1 : Form
    {
        int br_sloga;
        DataTable tabela;
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        public void prikazi()
        {
            if (tabela.Rows.Count == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
            }
            else
            {
                textBox1.Text = tabela.Rows[br_sloga][0].ToString();
                textBox2.Text = tabela.Rows[br_sloga][1].ToString();
                textBox3.Text = tabela.Rows[br_sloga][2].ToString();
                textBox4.Text = tabela.Rows[br_sloga][3].ToString();
                textBox5.Text = tabela.Rows[br_sloga][4].ToString();
                textBox6.Text = tabela.Rows[br_sloga][5].ToString();
                textBox7.Text = tabela.Rows[br_sloga][6].ToString();
            }
            if (br_sloga == tabela.Rows.Count-1)
               button6.Enabled = false;
            else button6.Enabled = true;
            if (br_sloga == 0)
                button2.Enabled = false;
            else button2.Enabled = true;

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            br_sloga = 0;
            SqlConnection veza = konekcija.povezi();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            da.Fill(tabela);
            prikazi();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            br_sloga++;
            prikazi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            br_sloga = 0;
            prikazi();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            br_sloga--; 
            prikazi();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            br_sloga = tabela.Rows.Count- 1;
            prikazi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // DODAJ
            // INSERT INTO osoba 
            // VALUES('Jana', 'Karenjina',
            // 'Glavna', '123123', 'aaa@bbb', '123', 1)
            string naredba = "INSERT INTO osoba VALUES('";
            naredba = naredba + textBox2.Text + "','";
            naredba = naredba + textBox3.Text + "','";
            naredba = naredba + textBox4.Text + "','";
            naredba = naredba + textBox5.Text + "','";
            naredba = naredba + textBox6.Text + "','";
            naredba = naredba + textBox7.Text + "',1)";
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            da.Fill(tabela);
            br_sloga = tabela.Rows.Count- 1;
            prikazi();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (br_sloga == tabela.Rows.Count - 1)
            {
                br_sloga--;
            }
            string naredba = "DELETE FROM osoba WHERE id=" + textBox1.Text;
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            try
            {
                veza.Open();
                komanda.ExecuteNonQuery();
                veza.Close();
            }
            catch (Exception greska) {
                MessageBox.Show(greska.GetType().ToString());
            }
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            da.Fill(tabela);
            prikazi();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            // PROMENI
            // UPDATE osoba
            // SET ime = 'first', prezime = 'last'
            // WHERE id = 12
            string naredba = "UPDATE osoba SET ";
            naredba += "ime='" + textBox2.Text+"',";
            naredba += "prezime='" + textBox3.Text + "',";
            naredba += "adresa='" + textBox4.Text + "',";
            naredba += "jmbg='" + textBox5.Text + "'";
            naredba += "WHERE id = " + textBox1.Text;
            SqlConnection veza = konekcija.povezi();
            SqlCommand komanda = new SqlCommand(naredba, veza);
            veza.Open();
            komanda.ExecuteNonQuery();
            veza.Close();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM osoba", veza);
            tabela = new DataTable();
            da.Fill(tabela);
            prikazi();
        }
    }
}
