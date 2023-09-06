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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        DBUrunYonetimEntities db = new DBUrunYonetimEntities();
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.TBL_URUN.ToList();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            TBL_URUN t = new TBL_URUN();
            t.URUNAD = txtUrunAd.Text;
            t.URUNSTOK = Convert.ToInt16(txtStokSayısı.Text);
            t.URUNMARKA = txtUrunMarka.Text;
            t.URUNKATEGORI = int.Parse(cmbUrunKategori.Text);
            t.URUNFIYAT = decimal.Parse(txtUrunFiyat.Text);
            t.URUNSTOKDURUM = true;
            db.TBL_URUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün sisteme kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = db.TBL_URUN.ToList();

        }
    }
}
