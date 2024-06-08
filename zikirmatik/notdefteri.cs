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

namespace zikirmatik
{
    public partial class notdefteri : Form
    {
        public notdefteri(Form1 form1)
        {
            InitializeComponent();
        }

        private void notdefteri_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button1, "Bu Pencereyi Sabitleyebilirsiniz.");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (TopMost)
            {
                this.TopMost = false;
                Image image = Sayaç.Properties.Resources.thumbtacks; // 'example' eklenen resmin adıdır

                // Butonun arkaplan resmini ayarlayın
                button1.BackgroundImage = image;
                button1.BackgroundImageLayout = ImageLayout.Zoom;
            }
            else
            {
                this.TopMost = true;
                Image image = Sayaç.Properties.Resources.imageedit_5_2528243654; // 'example' eklenen resmin adıdır

                // Butonun arkaplan resmini ayarlayın
                button1.BackgroundImage = image;
                button1.BackgroundImageLayout = ImageLayout.Zoom;
            }
        }

        private void notdefteri_Shown(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";
            saveFileDialog.AddExtension = true;
            saveFileDialog.Title = "Metni Kaydet";

            // SaveFileDialog göster ve kullanıcı bir dosya adı seçerse dosyayı kaydet
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // RichTextBox'taki metni seçilen dosyaya yazma
                    File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                    MessageBox.Show("Dosya başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Hata durumunda kullanıcıya mesaj göster
                    MessageBox.Show("Dosya kaydedilirken bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt";
            openFileDialog.Title = "Bir Metin Dosyası Seçin";

            // OpenFileDialog'u göster ve kullanıcının dosya seçmesini bekleyin
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen dosyanın yolunu alın
                string filePath = openFileDialog.FileName;

                // Dosyanın içeriğini okuyun
                string fileContent = File.ReadAllText(filePath);

                // İçeriği RichTextBox'a atayın
                richTextBox1.Text = fileContent;
            }
        }
    }
}
