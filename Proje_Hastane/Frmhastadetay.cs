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
    public partial class Frmhastadetay : Form
    {
        public Frmhastadetay()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        public string tc;
        private void Frmhastadetay_Load(object sender, EventArgs e)
        {


            lbltc.Text = tc;
            //adsoyad cekme 
            SqlCommand komut = new SqlCommand("select HastaAd, HastaSoyad From Tbl_Hastalar where HastaTC=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglantı().Close();



            //randevu geçmiş 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from Tbl_Randevular where HastaTC=" + tc, bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            //branşları cekme 
            SqlCommand komut2 = new SqlCommand("select BransAd From Tbl_Branslar", bgl.baglantı());
            SqlDataReader dr2 =komut2.ExecuteReader();  
            while (dr2.Read())
            {
                cmbbrans.Items.Add(dr2[0]);
            }
            bgl.baglantı().Close();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbdoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from Tbl_randevular where randevubrans='" + cmbbrans.Text + "'"+ "and randevudoktor='" + cmbdoktor.Text + "' and randevudurum = 0", bgl.baglantı());
            da.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad From Tbl_Doktorlar where doktorbrans=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader dr3 =komut.ExecuteReader();
            while (dr3.Read())
            {
                cmbdoktor.Items.Add(dr3[0]+ " " + dr3[1]);
            }
        }

        private void lnkbilgiduzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Frmbilgidüzenle1 fr =new Frmbilgidüzenle1();
            fr.TCno = lbltc.Text;
            fr.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_randevular set randevudurum=1,hastatc=@p1,hastasikayet=@p2 where randevuid=@p3", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",lbltc.Text);
            komut.Parameters.AddWithValue("@p2",rchsikayet.Text);
            komut.Parameters.AddWithValue("@p3",txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("randevu alındı","uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
