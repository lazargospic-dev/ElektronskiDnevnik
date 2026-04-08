using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dnevnik410a
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }

        private void osobaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 nova = new Form1();
            nova.ShowDialog();
        }

        private void upisnicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            upisnica nova = new upisnica();
            nova.ShowDialog();
        }

        private void Glavna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void skolskaGodinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("skolska_godina");
            nova.ShowDialog();
        }

        private void predmetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("predmet");
            nova.ShowDialog();
        }

        private void smerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sifarnik nova = new sifarnik("smer");
            nova.ShowDialog();
        }
    }
}
