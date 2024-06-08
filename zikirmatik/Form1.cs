using System;
using System.Drawing;
using System.Windows.Forms;

namespace zikirmatik
{
    public partial class Form1 : Form
    {
        private NotifyIcon notifyIcon;

        public Form1()
        {
            InitializeComponent();
            InitializeNotifyIcon();

        }
        private void InitializeNotifyIcon()
        {
            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information; // Simgeyi burada ayarlayın
            notifyIcon.Visible = true;
            notifyIcon.BalloonTipTitle = "Sayaç";
            notifyIcon.BalloonTipText = "Hedefinize Ulaştınız!";
            notifyIcon.BalloonTipIcon = ToolTipIcon.Info; // İsteğe bağlı: Info, Warning, Error
        }
        private void ShowNotification()
        {
            notifyIcon.ShowBalloonTip(3000); // 3000 milisaniye (3 saniye) süreyle göster
        }
        public static int sayac = 0;
        public static bool hedefsecildimi = false;
        public static bool acildimi= false;
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        private void azalt()
        {
            if (hedef.secilenhedef == sayac)
            {
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
            }
            if (sayac > 0)
            {
                if (!hedefsecildimi)
                {
                    sayac -= 1;
                    label1.Text = sayac.ToString();
                }
                else
                {
                    sayac -= 1;
                    label1.Text = hedef.secilenhedef + " / " + sayac.ToString();
                    if (sayac < hedef.secilenhedef)
                    {

                        progressBar1.Value -= 1;
                        float progressValue = progressBar1.Value;
                        float progressMax = progressBar1.Maximum;

                        // Yüzdesel hesaplama yapıyoruz.
                        float percentage = (float)((float)progressValue / progressMax * 100);

                        // Label'a yüzdesel değeri yazıyoruz.
                        label2.Text = $"%{percentage}";
                    }

                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

            
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked && !acildimi)
            {
                
                hedef hedefsec= new hedef(this);
                hedefsec.Show();
                checkBox1.Enabled = false;
                acildimi = true;
            }
            else
            {
                hedefsecildimi = false;
                hedef.secilenhedef = 0;
                label1.Text = sayac.ToString();
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label2.Visible = false;
                progressBar1.Value = 0;
                progressBar1.Visible = false;
                label2.Text = "% 0";

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (hedefsecildimi)
            {
                sayac = 0;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label1.Text = hedef.secilenhedef + " / 0";
                label2.Text = "% 0";
                progressBar1.Value = 0;
            }
            else
            {
                sayac = 0;
                label1.ForeColor = Color.Black;
                label2.ForeColor = Color.Black;
                label1.Text = "0";
                label2.Text = "% 0";
                progressBar1.Value = 0;
            }
        }

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            arttır();
            
            timer3.Start();
        }
        private void arttır()
        {

            if (!hedefsecildimi)
            {
                sayac += 1;
                label1.Text = sayac.ToString();
            }
            else
            {

               
                    sayac += 1;
                    label1.Text = hedef.secilenhedef + " / " + sayac.ToString();
                if (sayac <= hedef.secilenhedef)
                {
                    progressBar1.Value += 1;
                    int progressValue = progressBar1.Value;
                    int progressMax = progressBar1.Maximum;

                    // Yüzdesel hesaplama yapıyoruz.
                    float percentage = (float)((float)progressValue / progressMax * 100);

                    // Label'a yüzdesel değeri yazıyoruz.
                    label2.Text = $"%{percentage}";
                }
                    if (sayac == hedef.secilenhedef)
                    {
                        label1.Text = hedef.secilenhedef + " / " + sayac.ToString();
                    timer1.Stop();
                    timer3.Stop();
                    label1.ForeColor = Color.Red;
                    label2.ForeColor = Color.Green;
                    ShowNotification();
                   
                    //  MessageBox.Show("Hedefinize Ulaştınız!");
                }

            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            arttır();
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            timer3.Stop();
            timer1.Stop();
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            timer1.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            timer2.Start();

        }

        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            azalt();
            timer4.Start();
        }

        private void button2_MouseUp(object sender, MouseEventArgs e)
        {
            timer4.Stop();
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            azalt();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            notdefteri notepad= new notdefteri(this);


            // Ana pencerenin konumunu alın
            int mainFormRight = this.Location.X + this.Width;
            int mainFormTop = this.Location.Y;

            // Yeni pencerenin konumunu ayarlayın (ana pencerenin hemen sağında)
            notepad.Location = new System.Drawing.Point(mainFormRight, mainFormTop);


            notepad.Show();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.button4, "Yeni Bir Not Defteri Penceresi Açar.");

        }
    }
}
