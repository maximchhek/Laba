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

        private void îòêğûòüToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void èíâåğñèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertFilter filter = new InvertFilter();
            Bitmap resultImage = filter.processImage(image);
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void îòòåíêèÑåğîãîToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GreyFilter filter = new GreyFilter();
            Bitmap resultImage = filter.processImage(image);
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void ñåïèÿToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SepFilter filter = new SepFilter();
            Bitmap resultImage = filter.processImage(image);
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void óâåëè÷èòüßğêîñòüToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YarkFilter filter = new YarkFilter();
            Bitmap resultImage = filter.processImage(image);
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }

        private void ñäâèãÍà50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Sdvig();
            Bitmap resultImage = filter.processImage(image);
            image = resultImage;
            pictureBox1.Image = resultImage;
            pictureBox1.Refresh();
        }
    }
}
