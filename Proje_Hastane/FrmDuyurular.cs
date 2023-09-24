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
    public partial class FrmDuyurular : Form
    {
        public FrmDuyurular()
        {
            InitializeComponent();
        }
        sqlbaglantısı bgl = new sqlbaglantısı();
        private void FrmDuyurular_Load(object sender, EventArgs e)
        {
            DataTable dt =new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_duyurular",bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void FrmDuyurular_Load_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select *from tbl_duyurular", bgl.baglantı());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
