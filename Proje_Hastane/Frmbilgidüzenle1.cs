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
    public partial class Frmbilgidüzenle1 : Form
    {
        public Frmbilgidüzenle1()
        {
            InitializeComponent();
        }
        public string TCno;
        sqlbaglantısı bgl =new sqlbaglantısı();
        private void Frmbilgidüzenle1_Load(object sender, EventArgs e)
        {

            msktc.Text = TCno;
            SqlCommand komut = new SqlCommand("select *From Tbl_Hastalar where HastaTC=@p1",bgl.baglantı());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                TxtAd.Text = dr[1].ToString();
                TxtSoyad.Text = dr[2].ToString();
                
                txtsifre.Text= dr[5].ToString();
                cmbcinsiyet.Text = dr[6].ToString();


            }
            bgl.baglantı().Close();




        }

        private void btnbilgiguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("update Tbl_Hastalar set Hastaad=@p1,hastasoyad=@p2,hastatelefon=@p3,hastasifre=@p4,hastacinsiyet=@p5 where hastatc=@p6",bgl.baglantı());
            komut2.Parameters.AddWithValue("@p1",TxtAd.Text);
            komut2.Parameters.AddWithValue("@p2",TxtAd.Text);
            komut2.Parameters.AddWithValue("@p3",TxtSoyad.Text);
            komut2.Parameters.AddWithValue("@p4",txtsifre.Text);
            komut2.Parameters.AddWithValue("@p5",cmbcinsiyet.Text);
            komut2.Parameters.AddWithValue("@p6",msktc.Text);
            komut2.ExecuteNonQuery();
            bgl.baglantı().Close() ;
            MessageBox.Show("Bilgileriniz Güncellendi","bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);


        }
    }
}
