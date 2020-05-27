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
    public partial class FormNarudzbineRestorana : Form
    {
        public FormNarudzbineRestorana()
        {
            InitializeComponent();
        }

        private void FormNarudzbineRestorana_Load(object sender, EventArgs e)
        {
            List<Narudzbina> narudzbine = DataProvider.GetNarudzbineRestorana(Singleton.Instance.Restoran.RestoranId);

            foreach (Narudzbina nar in narudzbine)
                bindingSource1.Add(nar);
        }

        private void FormNarudzbineRestorana_FormClosed(object sender, FormClosedEventArgs e)
        {
            Singleton.Instance.FormLogin.Close();
        }
    }
}
