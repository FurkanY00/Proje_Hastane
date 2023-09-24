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
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        public string tcnumara;
       
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void lbltc_Click(object sender, EventArgs e)
        {

        }

        private void lbladsoyad_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantısı bgl =new sqlbaglantısı();
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tcnumara;
            
            // adsoyad
            SqlCommand komut1 = new SqlCommand("select sekreteradsoyad from tbl_sekreter where sekretertc=@p1", bgl.baglantı());
            komut1.Parameters.AddWithValue("@p1",lbltc.Text);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lbladsoyad.Text = dr1[0].ToString();
            }
            bgl.baglantı().Close();


            //branşları aktarma 
            DataTable dt1 =new DataTable ();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_branslar",bgl.baglantı());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;
            //doktorları listeye aktarma 
            DataTable dt2 = new DataTable ();
            SqlDataAdapter da2 = new SqlDataAdapter("select (doktorad +' '+ doktorsoyad)as 'Doktorlar', doktorbrans from tbl_doktorlar",bgl.baglantı());

            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
            //bransı combobx aktarma 
            SqlCommand komut2 = new SqlCommand("select bransad from tbl_branslar", bgl.baglantı());
            SqlDataReader dr2= komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0].ToString());  
            }
     

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            SqlCommand kaydet = new SqlCommand("insert into tbl_randevular (randevutarih,randevusaat,randevubrans,randevudoktor)values (@k1,@k2,@k3,@k4)",bgl.baglantı());
            kaydet.Parameters.AddWithValue("@k1",msktarih.Text);
            kaydet.Parameters.AddWithValue("@k2",msksaat.Text);
            kaydet.Parameters.AddWithValue("@k3",cmbbrans.Text);
            kaydet.Parameters.AddWithValue("@k4",cmbdoktor.Text);
            kaydet.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("Randevu oluşturuldu");
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut3 = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbrans=@p1", bgl.baglantı());
            komut3.Parameters.AddWithValue("@p1",cmbbrans.Text);

            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0]+ " " + dr3[1]);
            }
            bgl.baglantı().Close();
        }

        private void btnduyuruolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyurular (duyuru)values (@d1)",bgl.baglantı());
            komut.Parameters.AddWithValue("@d1",rchduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("duyuru oluşturuldu");
        }

        private void btndoktorpanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPaneli drp = new FrmDoktorPaneli();
            drp.Show();
        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnbranspanel_Click(object sender, EventArgs e)
        {
            FrmBrans frb=new FrmBrans();
            frb.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            FrmRandevuListesi rnd =new FrmRandevuListesi();
            rnd.Show();

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr=new FrmDuyurular();
            fr.Show();
        }
    }
}
