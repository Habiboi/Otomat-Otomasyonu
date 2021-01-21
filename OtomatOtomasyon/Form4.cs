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
    public partial class Form4 : Form
    {
        int otomatNo = -1;
        int ekipNo = -1;
        int urunNo = -1;
        int calisanNo = -1;
        int yoneticiNo = -1;
        public Form4()
        {
            InitializeComponent();
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SQL_Baglantisi.CalisanEkle(textBox7.Text, textBox8.Text, textBox23.Text, textBox24.Text);
            SQL_Baglantisi.TabloListele(dataGridView3, "CALISAN");
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            SQL_Baglantisi.TabloListele(dataGridView2, "URUN");
            SQL_Baglantisi.TabloListele(dataGridView3, "CALISAN");
            SQL_Baglantisi.TabloListele(dataGridView4, "CALISAN");
            SQL_Baglantisi.TabloListele(dataGridView5, "YONETICI");
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

        private void button22_Click(object sender, EventArgs e)
        {
            if (dataGridView5.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView5.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView5.Rows[selectedrowindex];
                yoneticiNo = int.Parse(Convert.ToString(selectedRow.Cells["YONETICI_NO"].Value));
                label28.Text = yoneticiNo + " Nolu çalışan seçildi.";
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (yoneticiNo != -1)
            {
                SQL_Baglantisi.KayitSil("YONETICI", "YONETICI_NO = '" + yoneticiNo + "'");
                SQL_Baglantisi.TabloListele(dataGridView3, "YONETICI");
            }
            else
            {
                MessageBox.Show("Lütfen Yönetici Seç butonunu kullanınız.", "HATA");
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

        private void button19_Click(object sender, EventArgs e)
        {
            if (calisanNo != -1)
            {
                SQL_Baglantisi.YoneticiGuncelle(textBox17.Text, textBox17.Text, yoneticiNo);
                SQL_Baglantisi.TabloListele(dataGridView5, "YONETICI");
            }
            else
            {
                MessageBox.Show("Lütfen Yönetici Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            SQL_Baglantisi.YoneticiEkle(textBox19.Text, textBox20.Text, textBox21.Text, textBox22.Text);
            SQL_Baglantisi.TabloListele(dataGridView3, "YONETICI");
        }
    }
}
