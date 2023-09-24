using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class FrmDokotorBilgDuzenle : Form
    {
        public FrmDokotorBilgDuzenle()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl =new sqlbaglantısı();
        public string tcno;
        private void msktc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void FrmDokotorBilgDuzenle_Load(object sender, EventArgs e)
        {
            msktc.Text = tcno;
            sqlbaglantısı bgl = new sqlbaglantısı();

            SqlCommand komut = new SqlCommand("select * from tbl_doktorlar where doktortc=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr["DoktorAd"].ToString(); // Sütun adlarını kullanın.
                TxtSoyad.Text = dr["DoktorSoyad"].ToString();
                CmbBrans.Text = dr["DoktorBrans"].ToString();
                txtsifre.Text = dr["DoktorSifre"].ToString();
            }
            bgl.baglantı().Close();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_doktorlar set doktorad=@p1,doktorsoyad=@p2,doktorbrans=@p3,doktorsifre=@p5 where doktrtc=@p4",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut.Parameters.AddWithValue("@p2",TxtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",CmbBrans.Text);
            komut.Parameters.AddWithValue("@p4",msktc.Text);
            komut.Parameters.AddWithValue("@p5",txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
        }
        
        
    }
}
