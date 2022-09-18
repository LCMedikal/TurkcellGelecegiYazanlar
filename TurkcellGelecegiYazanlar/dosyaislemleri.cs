using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace TurkcellGelecegiYazanlar
{
    public partial class dosyaislemleri : Form
    {
        public dosyaislemleri()
        {
            InitializeComponent();
        }

        private void knmSec_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text = "Seçilen klasör yolu : " + folderBrowserDialog1.SelectedPath;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label2.Text = "Seçilen dosya yolu :" + openFileDialog1.FileName;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();

        }
        string belgeyolu, belgeadi;

        private void txtKaydet_Click(object sender, EventArgs e)
        {
            belgeadi = textBox2.Text;
            StreamWriter sw = File.CreateText(belgeyolu+"\\"+belgeadi+".txt");
            MessageBox.Show("Dosya Olusturuldu","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void txtOku_Click(object sender, EventArgs e)
        {
            listBox1.HorizontalScrollbar = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader oku = new StreamReader(openFileDialog1.FileName);
                string satir = oku.ReadLine();
                while (satir !=null)
                {
                    listBox1.Items.Add(satir);
                    richTextBox1.Text += satir+ Environment.NewLine;
                    satir = oku.ReadLine();
                }
            }
        }

        private void richtextboxwrite_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.ShowDialog();
            StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName);
            kaydet.WriteLine(richTextBox1.Text);
            kaydet.Close();
            MessageBox.Show("Metin belgesine kaydedildi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                belgeyolu = folderBrowserDialog1.SelectedPath;
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
