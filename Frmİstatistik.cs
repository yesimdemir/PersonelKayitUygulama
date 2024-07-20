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

namespace PersonelKayit
{
    public partial class Frmİstatistik : Form
    {
        public Frmİstatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-P9D39CIC;Initial Catalog=PersonelVeriTabani;Integrated Security=True");
        private void Frmİstatistik_Load(object sender, EventArgs e)
        {

            //toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while(dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();


            //evli personel sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=1",baglanti);
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                lblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();


            //bekar personel sayısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select Count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }

            baglanti.Close();


            //şehir sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("select count(distinct(PerSehir)) from Tbl_Personel",baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblSehirSayisi.Text = dr4[0].ToString();
            }
            baglanti.Close();


            //toplam maaş
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("select sum (PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr5=komut5.ExecuteReader();
            while (dr5.Read()) { 
            lblToplamMaas.Text = dr5[0].ToString();
            }
            baglanti.Close();


            //ortalama maaş
            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("select avg (PerMaas) from Tbl_Personel", baglanti);
            SqlDataReader dr6=komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblOrtalamaMaas.Text = dr6[0].ToString();
            }
            baglanti.Close();
        }
    }
}
