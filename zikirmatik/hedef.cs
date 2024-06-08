using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zikirmatik
{
    public partial class hedef : Form
    {
        private Form1 anaForm;

        public hedef(Form1 anaForm)
        {
            InitializeComponent();
            this.anaForm = anaForm;

        }
        public static int secilenhedef = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            secilenhedef = Convert.ToInt32(numericUpDown1.Value);
            if (secilenhedef != 0)
            {
                Form1.acildimi = false;
                Form1.sayac = 0;
                anaForm.checkBox1.Enabled = true;
                anaForm.progressBar1.Visible = true;
                anaForm.progressBar1.Maximum = secilenhedef;
                anaForm.label2.Visible = true;
                anaForm.label1.ForeColor = Color.Black;
                anaForm.label2.ForeColor = Color.Black;
                Form1.hedefsecildimi = true;
                anaForm.label1.Text = $"{secilenhedef} / 0";
                Hide();
            }
            else
            {
                MessageBox.Show("Lütfen Bir Hedef Giriniz.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaForm.checkBox1.Enabled = true;
            anaForm.checkBox1.Checked = false;
            Form1.acildimi = false;
            Hide();

        }

        private void hedef_Shown(object sender, EventArgs e)
        {

        }
    }
}
