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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Korisnik user = DataProvider.GetKorisnikPoMailu(textBox1.Text);
            Restoran res = DataProvider.GetRestoranPoMailu(textBox1.Text);
            if (user != null && textBox2.Text.Equals(DataProvider.GetKorisnikPassword(textBox1.Text)))
            {
                Singleton.Instance.Korisnik = user;
                Singleton.Instance.Role = Role.Korisnik;
                FormKorisnik userFrm = new FormKorisnik();
                userFrm.Show();
                this.Hide();
            }
            else if (res != null && textBox2.Text.Equals(DataProvider.GetRestoranPassword(textBox1.Text)))
            {
                Singleton.Instance.Restoran = res;
                Singleton.Instance.Role = Role.Restoran;
                FormRestoran resFrm = new FormRestoran();
                resFrm.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Uneli ste pogresne podatke.", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            Singleton.Instance.FormLogin = this;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (DataProvider.GetKorisnikPoMailu(textEmail.Text) == null)
            {
                if (textPassword.Text == textBoxRepeatPassword.Text)
                {
                    DataProvider.CreateKorisnik(textIme.Text, textPrezime.Text, textEmail.Text, textPassword.Text, textBrTel.Text);
                    Singleton.Instance.Korisnik = DataProvider.GetKorisnikPoMailu(textEmail.Text);
                    Singleton.Instance.Role = Role.Korisnik;
                    FormKorisnik userFrm = new FormKorisnik();
                    userFrm.Show();
                    this.Hide();
                }else
                    MessageBox.Show("Sifre se ne poklapaju. Pokusajte opet.", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Korisnik vec postoji.", "Greska!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FormAdmin frmAdmin = new FormAdmin();
            frmAdmin.Show();
            this.Hide();
        }
    }
}
