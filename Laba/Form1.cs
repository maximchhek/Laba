using System.ComponentModel;

namespace Laba
{
    public partial class Form1 : Form
    {
        Bitmap image;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.bmp;*.jpg|All files(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreyFilter filter = new GreyFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SepFilter filter = new SepFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YarkFilter filter = new YarkFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sdvig();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������50������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SdvigRev();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Tisnenie();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Rasmitie();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayWorld();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void autolevelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Autolevels();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new IdealOtrazh();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Rasshirenie();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Suzhenie();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Median();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ������������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sobel();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void �����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sharr();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void ��������_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }
    }
}
