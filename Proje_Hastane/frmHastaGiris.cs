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
    public partial class Frmhastagiris : Form
    {
        public Frmhastagiris()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl =new sqlbaglantısı();
        private void lnkuyeol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit fr =new FrmHastaKayit();
            fr.Show();

        }

        private void btngirisyap_Click(object sender, EventArgs e)
        {
            SqlCommand komut =new SqlCommand("select *from Tbl_Hastalar where HastaTC=@p1 and HastaSifre=@p2",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1",msktc.Text);
            komut.Parameters.AddWithValue("@p2",txtsifre.Text);
            SqlDataReader dr =komut.ExecuteReader();
            if (dr.Read())
            {
                Frmhastadetay fr=new Frmhastadetay();
                fr.tc=msktc.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Bilgi Girdiniz!!!");
            }
            bgl.baglantı().Close();
        }

        private void Frmhastagiris_Load(object sender, EventArgs e)
        {

        }
    }
}
