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
    public partial class FormNarudzbina : Form
    {
        private List<String> proizvodi;
        public FormNarudzbina()
        {
            InitializeComponent();
            List<Restoran> rests = new List<Restoran>();
            rests = DataProvider.GetSviRestorani();
            for (int i = 0; i < rests.Count; i++)
                comboBox1.Items.Add(rests[i].Naziv);


            proizvodi = new List<String>();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            proizvodi.Add(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Restoran res = new Restoran();
            String nazivRes;
            nazivRes = comboBox1.SelectedItem.ToString();
            List<Restoran> rests = new List<Restoran>();
            rests = DataProvider.GetSviRestorani();
            //rests.Find((r) => r.Naziv == nazivRes);
            foreach(Restoran restoran in rests)
            {
                if (restoran.Naziv == nazivRes)
                    res = restoran;
            }

            DataProvider.CreateNarudzbina(DateTimeOffset.Now, textBoxAdresa.Text, proizvodi, Singleton.Instance.Korisnik.UserId, res.RestoranId);
        }

        private void FormNarudzbina_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.Instance.FormLogin.Close();
        }
    }
}
