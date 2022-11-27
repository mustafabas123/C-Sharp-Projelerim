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

namespace Hastane_proje
{
    public partial class Frm_Hasta_giris : Form
    {
        public static string tc=" ";
        Thread th;
        public Frm_Hasta_giris()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl=new SqlBaglanti();




        private void linkLabelUye_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

 
            th = new Thread(OpenNewForm);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
            

        }
        private void OpenNewForm() 
        {
            Application.Run(new Frm_Hasta_kayit());
        }
        private void OpenNewForm2()
        {
            Application.Run(new Frm_hasta_detay());
        }
 

        private void button1_Click(object sender, EventArgs e)
        {
            tc=mskTxtBoxTC.Text;
            SqlCommand komut=new SqlCommand("select * from Tbl_hastalar where HastaTC=@a1 and HastaSifre=@a2",bgl.baglanti());
            komut.Parameters.AddWithValue("@a1",mskTxtBoxTC.Text);
            komut.Parameters.AddWithValue("@a2",txtBoxSifre.Text);
            SqlDataReader dr=komut.ExecuteReader();


            if (dr.Read())
            {
 

                
                th = new Thread(OpenNewForm2);
                th.SetApartmentState(ApartmentState.STA);
                
                th.Start();
                
                this.Close();
            }
            else
            {
                MessageBox.Show("hatali kullanici adi veya sifre girdiniz");
            }
            bgl.baglanti().Close();

        }
    }
}
