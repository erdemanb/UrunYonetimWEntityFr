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
            dataGridView1.DataSource = (from x in db.TBL_URUN
                                        select new
                                        {
                                            x.URUNID,
                                            x.URUNAD,
                                            x.URUNMARKA,
                                            x.URUNSTOK,
                                            x.URUNFIYAT,
                                            x.TBL_KATEGORI.KATEGORIAD,
                                            x.URUNSTOKDURUM
                                        }).ToList();
            var kategoriler = (from x in db.TBL_KATEGORI select new { x.KATEGORIID, x.KATEGORIAD }).ToList();
            cmbUrunKategori.ValueMember = "KATEGORIID";
            cmbUrunKategori.DisplayMember = "KATEGORIAD";
            cmbUrunKategori.DataSource = kategoriler;
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

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtUrunID.Text);
            var urun = db.TBL_URUN.Find(x);
            db.TBL_URUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = db.TBL_URUN.ToList();
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtUrunID.Text);
            var urun = db.TBL_URUN.Find(x);
            urun.URUNAD = txtUrunAd.Text;
            urun.URUNSTOK = short.Parse(txtStokSayısı.Text);
            urun.URUNMARKA = txtUrunMarka.Text;
            db.SaveChanges();
            MessageBox.Show("Ürün güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.DataSource = db.TBL_URUN.ToList();


        }
    }
}
