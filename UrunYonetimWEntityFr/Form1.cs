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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DBUrunYonetimEntities db = new DBUrunYonetimEntities();
        private void Form1_Load(object sender, EventArgs e)
        {
            var kategoriler = db.TBL_KATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            TBL_KATEGORI t = new TBL_KATEGORI();
        }
    }
}
