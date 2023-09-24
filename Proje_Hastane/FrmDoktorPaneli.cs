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
    public partial class FrmDoktorPaneli : Form
    {
        public FrmDoktorPaneli()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl =new sqlbaglantısı();
        private void FrmDoktorPaneli_Load(object sender, EventArgs e)
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from tbl_doktorlar", bgl.baglantı());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;
            //brans ekleme 
            SqlCommand komut3 =new SqlCommand("select bransad from tbl_branslar",bgl.baglantı());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbbrans.Items.Add(dr3[0]);
            }

        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_doktorlar (doktorad,doktorsoyad,doktorbrans,doktortc,doktorsifre)values(@d1,@d2,@d3,@d4,@d5)",bgl.baglantı());
            komut.Parameters.AddWithValue("@d1",txtad.Text);
            komut.Parameters.AddWithValue("@d2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3",cmbbrans.Text);
            komut.Parameters.AddWithValue("@d4",msktc.Text);
            komut.Parameters.AddWithValue("@d5",txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("doktor eklendi","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

 
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbbrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            msktc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtsifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();



        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tbl_doktorlar where doktortc=@p1", bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("kayıt silindi","uyarı",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update tbl_doktorlar set doktorad=@d1,doktorsoyad=@d2,doktorbrans=@d3,doktorsifre=@d5 where doktortc=@d4", bgl.baglantı());
            komut.Parameters.AddWithValue("@d1", txtad.Text);
            komut.Parameters.AddWithValue("@d2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@d3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@d5", txtsifre.Text);
            komut.Parameters.AddWithValue("@d4", msktc.Text);
            komut.ExecuteNonQuery();
            bgl.baglantı().Close();
            MessageBox.Show("doktor güncellendi", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
