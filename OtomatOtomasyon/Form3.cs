using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtomatOtomasyon
{
    public partial class Form3 : Form
    {
        int otomatNo = -1;
        int ekipNo = -1;
        int urunNo = -1;
        int calisanNo = -1;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            SQL_Baglantisi.TabloListele(dataGridView2, "URUN");
            SQL_Baglantisi.TabloListele(dataGridView3, "CALISAN");
            SQL_Baglantisi.TabloListele(dataGridView4, "CALISAN");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                otomatNo = int.Parse(Convert.ToString(selectedRow.Cells["OTOMAT_NO"].Value));
                label8.Text = otomatNo + " Nolu otomat seçildi.";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (dataGridView4.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView4.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView4.Rows[selectedrowindex];
                ekipNo = int.Parse(Convert.ToString(selectedRow.Cells["EKIP_NO"].Value));
                label6.Text = ekipNo + " Nolu ekip seçildi.";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView2.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView2.Rows[selectedrowindex];
                urunNo = int.Parse(Convert.ToString(selectedRow.Cells["URUN_NO"].Value));
                label4.Text = urunNo + " Nolu ürün seçildi.";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView3.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView3.Rows[selectedrowindex];
                calisanNo = int.Parse(Convert.ToString(selectedRow.Cells["OTOMAT_NO"].Value));
                label5.Text = calisanNo + " Nolu çalışan seçildi.";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (otomatNo != -1)
            {
                SQL_Baglantisi.KayitSil("OTOMAT", "OTOMAT_NO = '" + otomatNo + "'");
                SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            }
            else
            {
                MessageBox.Show("Lütfen Otomat Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (urunNo != -1)
            {
                SQL_Baglantisi.KayitSil("URUN", "URUN_NO = '" + urunNo + "'");
                SQL_Baglantisi.TabloListele(dataGridView2, "URUN");
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (calisanNo != -1)
            {
                SQL_Baglantisi.KayitSil("CALISAN", "CALISAN_NO = '" + calisanNo + "'");
                SQL_Baglantisi.TabloListele(dataGridView3, "CALISAN");
            }
            else
            {
                MessageBox.Show("Lütfen Çalışan Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (ekipNo != -1)
            {
                SQL_Baglantisi.OtomatBakimGuncelle(ekipNo, "Ekip görevlendirildi. " + DateTime.Now.ToString());
                SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            }
            else
            {
                MessageBox.Show("Lütfen Ekip Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SQL_Baglantisi.OtomatEkle(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (urunNo != -1)
            {
                SQL_Baglantisi.UrunGuncelle(textBox13.Text, textBox14.Text, urunNo);
                SQL_Baglantisi.TabloListele(dataGridView2, "URUN");
            }
            else
            {
                MessageBox.Show("Lütfen Ürün Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SQL_Baglantisi.UrunEkle(textBox5.Text, textBox6.Text);
            SQL_Baglantisi.TabloListele(dataGridView2, "URUN");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQL_Baglantisi.CalisanEkle(textBox7.Text, textBox8.Text, textBox23.Text, textBox24.Text);
            SQL_Baglantisi.TabloListele(dataGridView3, "CALISAN");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (otomatNo != -1)
            {
                SQL_Baglantisi.OtomatGuncelle(textBox12.Text, textBox11.Text, textBox10.Text, textBox9.Text, otomatNo);
                SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            }
            else
            {
                MessageBox.Show("Lütfen Otomat Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (calisanNo != -1)
            {
                SQL_Baglantisi.CalisanGuncelle(textBox15.Text, textBox16.Text, calisanNo);
                SQL_Baglantisi.TabloListele(dataGridView3, "CALISAN");
            }
            else
            {
                MessageBox.Show("Lütfen Çalışan Seç butonunu kullanınız.", "HATA");
            }
        }
    }
}
