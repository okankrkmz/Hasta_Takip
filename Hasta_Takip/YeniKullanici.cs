using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hasta_Takip
{
    public partial class YeniKullanici : Form
    {
        public YeniKullanici()
        {
            InitializeComponent();
        }
        string verify = "19052000";

        private void btnsignup_Click(object sender, EventArgs e)
        {
            if (txtpassword.Text == txtrepassword.Text)
            {
                if (txtverify.Text == verify)
                {
                    SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=HospitalDB;Integrated Security=SSPI");
                    baglanti.Open();
                    SqlCommand command = new SqlCommand("insert into Kullanıcılar (Username,Password) values ('" + txtusername.Text.ToString() + "','"
                        + txtpassword.Text.ToString() + "'  )", baglanti);
                    command.ExecuteNonQuery();
                    baglanti.Close();
                    toolStripStatusLabel1.Text = "Kayıt işlemi başarı ile gerçekleşti";
                    statusStrip1.Refresh();
                    Application.DoEvents();
                    this.Close();
                }
                else
                {
                    toolStripStatusLabel1.Text = "Referans Kodunu Kontrol Ediniz !";
                    statusStrip1.Refresh();
                    Application.DoEvents();
                }
            }
            else
            {
                toolStripStatusLabel1.Text = "Bilgilerinizi Kontrol Edip Tekrar Deneyiniz !";
                statusStrip1.Refresh();
                Application.DoEvents();
            }

        }

        private void YeniKullanici_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
