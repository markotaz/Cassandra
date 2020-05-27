using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataLayer.QueryEntities;
using DataLayer;

namespace NBP_Cassandra
{
    public partial class FormNarudzbineKorisnika : Form
    {
        public FormNarudzbineKorisnika()
        {
            InitializeComponent();
        }

        private void FormNarudzbineKorisnika_Load(object sender, EventArgs e)
        {
            List<Narudzbina> narudzbine = DataProvider.GetNarudzbineKorisnika(Singleton.Instance.Korisnik.UserId);

            foreach (Narudzbina nar in narudzbine)
                bindingSource1.Add(nar);
        }

        private void FormNarudzbineKorisnika_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.Instance.FormLogin.Close();
        }
    }
}
