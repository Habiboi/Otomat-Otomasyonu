using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Oracle.ManagedDataAccess.Client;

namespace OtomatOtomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                if (textBox1.Text == "haberadmin" && textBox2.Text == "1234")
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı/şifre hatalı.","Hata");
                }
            }
            else if(comboBox1.SelectedIndex == 1|| comboBox1.SelectedIndex == 2)
            {
                bool x = SQL_Baglantisi.LoginControl(comboBox1.SelectedIndex, textBox1.Text, textBox2.Text);

                if (x)
                {
                    if(comboBox1.SelectedIndex == 1)
                    {
                        Form3 form3 = new Form3();
                        form3.Show();
                        this.Hide();
                    }
                    else
                    {
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Kullanıcı adı/şifre hatalı.", "Hata");
                }
            }
            
        }
    }
}
