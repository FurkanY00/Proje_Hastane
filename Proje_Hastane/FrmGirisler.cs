﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void btnhastagirisi_Click(object sender, EventArgs e)
        {
            Frmhastagiris fr = new Frmhastagiris();
            fr.Show();
            this.Hide();
            

            }
       

        private void btndoktorgirisi_Click(object sender, EventArgs e)
        {
            frmdoktorgiris fr =new frmdoktorgiris();
            fr.Show();
            this.Hide();
        }

        private void btnsekretergirisi_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris fr =new FrmSekreterGiris();
            fr.Show();
            this.Hide();    
        }

        private void FrmGirisler_Load(object sender, EventArgs e)
        {

        }
    }
}