using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hasta_Takip
{
    public partial class Arayuz : Form
    {
        public Arayuz()
        {
            InitializeComponent();
            Login login = new Login();
            YeniKullanici yeniKullanici = new YeniKullanici();
            login.FormClosed += Login_FormClosed;
            yeniKullanici.FormClosed += YeniKullanici_FormClosed;
        }
        Login login = new Login();
        YeniKullanici yeniKullanici = new YeniKullanici();
        DialogResult dialog = new DialogResult();

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            login = null;
        }

        private void YeniKullanici_FormClosed(object sender, FormClosedEventArgs e)
        {
            yeniKullanici = null;
        }


        private void girişYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (login == null || login.IsDisposed)
            {
                login = new Login();
                login.FormClosed += Login_FormClosed;
            }
            login.Show();
        }

        private void yeniKullanıcıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (yeniKullanici == null || yeniKullanici.IsDisposed)
            {
                yeniKullanici = new YeniKullanici();
                yeniKullanici.FormClosed += YeniKullanici_FormClosed;
            }
            yeniKullanici.Show();
        }

        private void çıkışYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dialog = MessageBox.Show("Çıkış Yapmak Üzeresiniz.\nÇıkış Yapmak İstediğinizden Emin Misiniz ?", "Bilgi", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dialog == DialogResult.OK)
            {

                Application.Exit();

            }
        }
    }
}
