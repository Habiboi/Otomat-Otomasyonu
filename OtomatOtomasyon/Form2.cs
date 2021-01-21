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
    public partial class Form2 : Form
    {
        int selectIndex = -1;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                int selectedrowindex = dataGridView1.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dataGridView1.Rows[selectedrowindex];
                selectIndex = int.Parse(Convert.ToString(selectedRow.Cells["OTOMAT_NO"].Value));
                label8.Text = selectIndex + " Nolu otomat seçildi.";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectIndex != -1)
            {
                SQL_Baglantisi.OtomatBakimGuncelle(selectIndex, "Ekip yola çıktı. " + DateTime.Now.ToString());
                SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            }
            else
            {
                MessageBox.Show("Lütfen Otomat Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectIndex != -1)
            {
                SQL_Baglantisi.OtomatBakimGuncelle(selectIndex, "Ürünler ekleniyor. " + DateTime.Now.ToString());
                SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            }
            else
            {
                MessageBox.Show("Lütfen Otomat Seç butonunu kullanınız.", "HATA");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectIndex != -1)
            {
                SQL_Baglantisi.OtomatBakimGuncelle(selectIndex, "Ürünler eklendi. " + DateTime.Now.ToString());
                SQL_Baglantisi.TabloListele(dataGridView1, "OTOMAT");
            }
            else
            {
                MessageBox.Show("Lütfen Otomat Seç butonunu kullanınız.", "HATA");
            }
        }
    }
}
