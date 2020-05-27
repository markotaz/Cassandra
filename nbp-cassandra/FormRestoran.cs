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
    public partial class FormRestoran : Form
    {
        public FormRestoran()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormRestoran_Load(object sender, EventArgs e)
        {

        }

        private void FormRestoran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.Instance.FormLogin.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String tip;
            if (radioButton1.Checked)
                tip = radioButton1.Text;
            else if (radioButton2.Checked)
                tip = radioButton2.Text;
            else
                tip = "";

            DataProvider.CreateProizvod(Singleton.Instance.Restoran.RestoranId,tip,Int32.Parse(textBoxCena.Text),textBoxMasa.Text,textBoxNaziv.Text,richTextBoxOpis.Text);
            MessageBox.Show("Uspesno ste dodali proizvod u vas restoran.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataProvider.UpdateProizvod(Singleton.Instance.Restoran.RestoranId, textBoxIzmeniNaziv.Text, textBoxIzmeniMasu.Text, Int32.Parse(textBoxIzmeniCenu.Text), textBoxIzmeniTip.Text);
            MessageBox.Show("Uspesno ste azurirali proizvod vaseg restorana.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataProvider.DeleteProizvod(Singleton.Instance.Restoran.RestoranId, textBoxObrisiNaziv.Text);
            MessageBox.Show("Uspesno ste obrisali proizvod vaseg restorana.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FormNarudzbineRestorana fnr = new FormNarudzbineRestorana();
            fnr.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataProvider.ObradiNarudzbinu(textBoxId.Text, Singleton.Instance.Restoran.RestoranId);
            MessageBox.Show("Uspesno ste obradili narudzbinu vaseg restorana.", "Obavestenje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
