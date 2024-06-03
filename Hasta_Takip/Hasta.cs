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
    public partial class Hasta : Form
    {
        public Hasta()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=HospitalDB;Integrated Security=SSPI");
        SqlCommand command;
        SqlDataAdapter da;

        void DataShow()
        {
            SqlConnection baglanti = new SqlConnection("server=.;Initial Catalog=HospitalDB;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("SELECT *FROM Hastalar", baglanti);
            DataTable table = new DataTable();
            da.Fill(table);
            dataGridView1.DataSource = table;
            baglanti.Close();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            DataShow();
            toolStripStatusLabel3.Text = "Hastalar  Listeleniyor !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            string sorgu1 = "INSERT INTO Hastalar(Name,Surname,TC,BirthDate,Telefon,DoktorAdi,HastaNotlari,HastaKayit,HastaTaburcu,Hastalık,HastalıkGecmisi,Boy,Kilo,KanGrubu) VALUES (@Name,@Surname,@TC,@BirthDate,@Telefon,@DoktorAdi," +
    "@HastaNotlari,@HastaKayit,@HastaTaburcu,@Hastalık,@HastalıkGecmisi,@Boy,@Kilo,@KanGrubu)";
            command = new SqlCommand(sorgu1, baglanti);
            command.Parameters.AddWithValue("@Name", txtAd.Text);
            command.Parameters.AddWithValue("@Surname", txtSoyad.Text);
            command.Parameters.AddWithValue("@TC", txttc.Text);
            command.Parameters.AddWithValue("@BirthDate", dtpdogum.Value);
            command.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            command.Parameters.AddWithValue("@DoktorAdi", cbdoktorlar.Text);
            command.Parameters.AddWithValue("@HastaNotlari", rtbhastanot.Text);
            command.Parameters.AddWithValue("@HastaKayit", dtpkayit.Text);
            command.Parameters.AddWithValue("@HastaTaburcu", dtptaburcu.Text);
            command.Parameters.AddWithValue("@Hastalık", txtHastalik.Text);
            command.Parameters.AddWithValue("@HastalıkGecmisi", rtbHastalik.Text);
            command.Parameters.AddWithValue("@Boy", txtBoy.Text);
            command.Parameters.AddWithValue("@Kilo", txtKilo.Text);
            command.Parameters.AddWithValue("@KanGrubu", txtkan.Text);
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            toolStripStatusLabel3.Text = "Hasta Başarılı Bir Şekilde Eklendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btndüzenle_Click(object sender, EventArgs e)
        {
            string sorgu = "UPDATE Hastalar SET Name = @Name,Surname = @Surname,TC = @TC,BirthDate = @BirthDate," +
"Telefon = @Telefon,DoktorAdi = @DoktorAdi,HastaNotlari = @HastaNotlari,HastaKayit = @HastaKayit, HastaTaburcu = @HastaTaburcu,Hastalık=@Hastalık,HastalıkGecmisi=@HastalıkGecmisi,Boy=@Boy,Kilo=@Kilo,KanGrubu=@KanGrubu WHERE ID = @ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            command.Parameters.AddWithValue("@Name", txtAd.Text);
            command.Parameters.AddWithValue("@Surname", txtSoyad.Text);
            command.Parameters.AddWithValue("@TC", txttc.Text);
            command.Parameters.AddWithValue("@BirthDate", dtpdogum.Value);
            command.Parameters.AddWithValue("@Telefon", txtTelefon.Text);
            command.Parameters.AddWithValue("@DoktorAdi", cbdoktorlar.Text);
            command.Parameters.AddWithValue("@HastaNotlari", rtbhastanot.Text);
            command.Parameters.AddWithValue("@HastaKayit", dtpkayit.Text);
            command.Parameters.AddWithValue("@HastaTaburcu", dtptaburcu.Text);
            command.Parameters.AddWithValue("@Hastalık", txtHastalik.Text);
            command.Parameters.AddWithValue("@HastalıkGecmisi", rtbHastalik.Text);
            command.Parameters.AddWithValue("@Boy", txtBoy.Text);
            command.Parameters.AddWithValue("@Kilo", txtKilo.Text);
            command.Parameters.AddWithValue("@KanGrubu", txtkan.Text);
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel3.Text = "Hasta Başarılı Bir Şekilde Güncellendi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string sorgu = "DELETE FROM Hastalar WHERE ID=@ID";
            command = new SqlCommand(sorgu, baglanti);
            command.Parameters.AddWithValue("@ID", Convert.ToInt32(txtid.Text));
            baglanti.Open();
            command.ExecuteNonQuery();
            baglanti.Close();
            DataShow();
            toolStripStatusLabel3.Text = "Hasta Başarılı Bir Şekilde Silindi !";
            statusStrip1.Refresh();
            Application.DoEvents();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            foreach (Control item in groupBox1.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
                if (item is RichTextBox)
                {
                    item.Text = "";
                }
                if (item is DateTimePicker)
                {
                    item.ResetText();
                }
                if (item is ComboBox)
                {
                    item.Text = "";
                }
                if (item is NumericUpDown)
                {
                    item.Text = "";
                }
            }
            toolStripStatusLabel3.Text = "Bütün Yazılar Temizlendi ! ";
        }

        private void Hasta_Load(object sender, EventArgs e)
        {
            dtpdogum.Format = DateTimePickerFormat.Custom;
            dtpdogum.CustomFormat = "yyyy-MM-dd";
            dtpkayit.Format = DateTimePickerFormat.Custom;
            dtpkayit.CustomFormat = "yyyy-MM-dd";
            dtptaburcu.Format = DateTimePickerFormat.Custom;
            dtptaburcu.CustomFormat = "yyyy-MM-dd";
            baglanti.Open();
            SqlCommand command = new SqlCommand("Select * from Doktorlar", baglanti);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cbdoktorlar.Items.Add(reader["Name"]);
            }
            baglanti.Close();
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttc.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            dtpdogum.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtTelefon.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            cbdoktorlar.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            rtbhastanot.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dtpkayit.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            dtptaburcu.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtHastalik.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            rtbHastalik.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtBoy.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtKilo.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtkan.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
        }
    }
}
