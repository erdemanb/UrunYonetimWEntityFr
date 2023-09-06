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
            t.KATEGORIAD = txtKategoriAd.Text;
            db.TBL_KATEGORI.Add(t);
            db.SaveChanges();
            var kategoriler = db.TBL_KATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
            MessageBox.Show("Kategori Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtKategoriID.Text);
            var ktgr = db.TBL_KATEGORI.Find(x);
            db.TBL_KATEGORI.Remove(ktgr);
            db.SaveChanges();
            var kategoriler = db.TBL_KATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
            MessageBox.Show("Kategori Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information );
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(txtKategoriID.Text);
            var ktgr = db.TBL_KATEGORI.Find(x);
            ktgr.KATEGORIAD = txtKategoriAd.Text;
            db.SaveChanges();
            var kategoriler = db.TBL_KATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
            MessageBox.Show("Kategori Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKategoriID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKategoriAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
