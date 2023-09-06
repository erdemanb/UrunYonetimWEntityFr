using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunYonetimWEntityFr
{
    public partial class FrmAnaFrom : Form
    {
        public FrmAnaFrom()
        {
            InitializeComponent();
        }

        private void btnKategoriIslemleri_Click(object sender, EventArgs e)
        {
            Form1 fr = new Form1();
            fr.ShowDialog();
        }
    }
}
