using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer;
using DataLayer.QueryEntities;

namespace NBP_Cassandra
{
    public partial class FormKorisnik : Form
    {
        public FormKorisnik()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Singleton.Instance.Korisnik.UserId != null)
            {
                DataProvider.UpdateKorisnik(Singleton.Instance.Korisnik.UserId, textBox1.Text, textBox2.Text, textBox3.Text);
                MessageBox.Show("Uspesno ste azurirali podatke.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Singleton.Instance.Korisnik.UserId != null)
            {
                DataProvider.DeleteKorisnik(Singleton.Instance.Korisnik.UserId);
                MessageBox.Show("Uspesno ste obrisali nalog.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void FormKorisnik_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.Instance.FormLogin.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormNarudzbina frmNar = new FormNarudzbina();
            frmNar.Show();
        }

        private void FormKorisnik_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNarudzbineKorisnika fnk = new FormNarudzbineKorisnika();
            fnk.Show();
            this.Hide();
        }
    }
}
