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
    public partial class FrmDoktorDetay1 : Form
    {
        public FrmDoktorDetay1()
        {
            InitializeComponent();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void lblTc_Click(object sender, EventArgs e)
        {

        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        public string tc;

        private void FrmDoktorDetay1_Load(object sender, EventArgs e)
        {
            lblTc.Text = tc;
            //doktor adsoyad 
            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktortc=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",lblTc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];

            }
            bgl.baglantı().Close();
            //randevular 
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_randevular where randevudoktor='"+lblAdSoyad.Text +"'",bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;





        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            Frmbilgidüzenle1 fr =new Frmbilgidüzenle1();
            fr.TCno = lblTc.Text;
            fr.Show();
        }

        private void BtnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDuyurular fr =new FrmDuyurular();
            fr.Show();

        }

        private void BtnCıkıs_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
