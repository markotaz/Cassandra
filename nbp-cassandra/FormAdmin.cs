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
    public partial class FormAdmin : Form
    {
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataProvider.CreateRestoran(textBoxAdresa.Text, textBoxEmail.Text, textBoxGrad.Text, textBoxOpstina.Text, textBoxNaziv.Text, textBoxPassword.Text);
            MessageBox.Show("Uspesno ste kreirali restoran.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Restoran res = new Restoran();
            res = DataProvider.GetRestoranPoMailu(textBoxObrisiEmail.Text);
            DataProvider.DeleteRestoran(res.RestoranId);
            MessageBox.Show("Uspesno ste obrisali restoran.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.Instance.FormLogin.Close();
        }
    }
}
