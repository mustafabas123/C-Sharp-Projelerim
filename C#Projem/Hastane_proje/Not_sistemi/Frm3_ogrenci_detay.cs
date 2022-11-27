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
namespace Not_sistemi
{
    public partial class Frm3_ogrenci_detay : Form
    {
        SqlBglanti3 bgl =new SqlBglanti3();
        public Frm3_ogrenci_detay()
        {
            InitializeComponent();
        }

        private void Frm3_ogrenci_detay_Load(object sender, EventArgs e)
        {
            // bilgileri aktarma
            lblNumara.Text=Frm3_ogrenci_giris.Numara.ToString();
            SqlCommand komut=new SqlCommand("select * from Tbl_ogrenci where OgrenciNumara=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lblNumara.Text);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdveSoyad.Text = dr[1] + " " + dr[2];
                lbl1Not.Text = dr[5].ToString();
                lblNot2.Text=dr[6].ToString();
                lblNot3.Text=dr[7].ToString();
                lblNumara.Text= dr[3].ToString();   
            }
            bgl.baglanti().Close();
            
            // ortalama hesplama
            SqlCommand komut2 = new SqlCommand("select (Not1+Not2+Not3)/3 from Tbl_ogrenci where OgrenciNumara=@k1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@k1", lblNumara.Text);
            SqlDataReader dr2=komut2.ExecuteReader();
            if (dr2.Read())
            {
                lblOrtalama.Text = dr2[0].ToString();
            }
            bgl.baglanti().Close();

        }
    }
}
