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
    public partial class FrmIstatistik : Form
    {
        public FrmIstatistik()
        {
            InitializeComponent();
        }
        DBUrunYonetimEntities db = new DBUrunYonetimEntities();

        private void FrmIstatistik_Load(object sender, EventArgs e)
        {
            lblToplamKategori.Text = db.TBL_KATEGORI.Count().ToString();
            lblToplamUrun.Text = db.TBL_URUN.Count().ToString();
            lblAktifMusteri.Text = db.TBL_MUSTERI.Count(x => x.MUSTERİDURUM == true).ToString();
            lblPasifMusteri.Text = db.TBL_MUSTERI.Count(x => x.MUSTERİDURUM == false).ToString();
            lblToplamStok.Text = db.TBL_URUN.Sum(y => y.URUNSTOK).ToString();
            lblKasaTutar.Text = db.TBL_SATIS.Sum(z=> z.SATISFIYAT).ToString() + " TL";
            lblEnYuksekFiyat.Text = (from x in db.TBL_URUN orderby x.URUNFIYAT descending select x.URUNAD).FirstOrDefault().ToString();
            lblEnDusukFiyat.Text = (from x in db.TBL_URUN orderby x.URUNFIYAT ascending select x.URUNAD).FirstOrDefault().ToString();
            lblBeyazEsya.Text = db.TBL_URUN.Count(x=>x.URUNKATEGORI == 1).ToString();
            lblToplamBuzdolabı.Text = db.TBL_URUN.Count(x => x.URUNAD == "BUZDOLABI").ToString();
            lblSehirSayisi.Text = (from x in db.TBL_MUSTERI select x.MUSTERISEHIR).Distinct().Count().ToString();
            //Üst satırdaki Distinct metodu şehirlerin tekrarsız gelmesini sağlar.
            lblEnFazlaMarka.Text = db.MARKAGETIR().FirstOrDefault().ToString();


            

        }
    }
}
