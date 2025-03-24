namespace Laba
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox1 = new PictureBox();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            открытьToolStripMenuItem = new ToolStripMenuItem();
            фильтрыToolStripMenuItem = new ToolStripMenuItem();
            точечныеToolStripMenuItem = new ToolStripMenuItem();
            инверсияToolStripMenuItem = new ToolStripMenuItem();
            оттенкиСерогоToolStripMenuItem = new ToolStripMenuItem();
            сепияToolStripMenuItem = new ToolStripMenuItem();
            увеличитьЯркостьToolStripMenuItem = new ToolStripMenuItem();
            сдвигНа50ToolStripMenuItem = new ToolStripMenuItem();
            сдвигНа50ВправоToolStripMenuItem = new ToolStripMenuItem();
            матричныеToolStripMenuItem = new ToolStripMenuItem();
            тиснениеToolStripMenuItem = new ToolStripMenuItem();
            размытиеВДвиженииToolStripMenuItem = new ToolStripMenuItem();
            серыйМирToolStripMenuItem = new ToolStripMenuItem();
            autolevelsToolStripMenuItem = new ToolStripMenuItem();
            идеальныйОтражательToolStripMenuItem = new ToolStripMenuItem();
            расширениеToolStripMenuItem = new ToolStripMenuItem();
            сужениеToolStripMenuItem = new ToolStripMenuItem();
            медианаToolStripMenuItem = new ToolStripMenuItem();
            фильтрСобеляToolStripMenuItem = new ToolStripMenuItem();
            фильтрШарраToolStripMenuItem = new ToolStripMenuItem();
            progressBar1 = new ProgressBar();
            Отмена = new Button();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(35, 28);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(742, 344);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фильтрыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { открытьToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(48, 20);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // открытьToolStripMenuItem
            // 
            открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            открытьToolStripMenuItem.Size = new Size(121, 22);
            открытьToolStripMenuItem.Text = "Открыть";
            открытьToolStripMenuItem.Click += открытьToolStripMenuItem_Click;
            // 
            // фильтрыToolStripMenuItem
            // 
            фильтрыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { точечныеToolStripMenuItem, матричныеToolStripMenuItem });
            фильтрыToolStripMenuItem.Name = "фильтрыToolStripMenuItem";
            фильтрыToolStripMenuItem.Size = new Size(69, 20);
            фильтрыToolStripMenuItem.Text = "Фильтры";
            // 
            // точечныеToolStripMenuItem
            // 
            точечныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { инверсияToolStripMenuItem, оттенкиСерогоToolStripMenuItem, сепияToolStripMenuItem, увеличитьЯркостьToolStripMenuItem, сдвигНа50ToolStripMenuItem, сдвигНа50ВправоToolStripMenuItem });
            точечныеToolStripMenuItem.Name = "точечныеToolStripMenuItem";
            точечныеToolStripMenuItem.Size = new Size(139, 22);
            точечныеToolStripMenuItem.Text = "Точечные";
            // 
            // инверсияToolStripMenuItem
            // 
            инверсияToolStripMenuItem.Name = "инверсияToolStripMenuItem";
            инверсияToolStripMenuItem.Size = new Size(179, 22);
            инверсияToolStripMenuItem.Text = "Инверсия";
            инверсияToolStripMenuItem.Click += инверсияToolStripMenuItem_Click;
            // 
            // оттенкиСерогоToolStripMenuItem
            // 
            оттенкиСерогоToolStripMenuItem.Name = "оттенкиСерогоToolStripMenuItem";
            оттенкиСерогоToolStripMenuItem.Size = new Size(179, 22);
            оттенкиСерогоToolStripMenuItem.Text = "Оттенки серого";
            оттенкиСерогоToolStripMenuItem.Click += оттенкиСерогоToolStripMenuItem_Click;
            // 
            // сепияToolStripMenuItem
            // 
            сепияToolStripMenuItem.Name = "сепияToolStripMenuItem";
            сепияToolStripMenuItem.Size = new Size(179, 22);
            сепияToolStripMenuItem.Text = "Сепия";
            сепияToolStripMenuItem.Click += сепияToolStripMenuItem_Click;
            // 
            // увеличитьЯркостьToolStripMenuItem
            // 
            увеличитьЯркостьToolStripMenuItem.Name = "увеличитьЯркостьToolStripMenuItem";
            увеличитьЯркостьToolStripMenuItem.Size = new Size(179, 22);
            увеличитьЯркостьToolStripMenuItem.Text = "Увеличить яркость";
            увеличитьЯркостьToolStripMenuItem.Click += увеличитьЯркостьToolStripMenuItem_Click;
            // 
            // сдвигНа50ToolStripMenuItem
            // 
            сдвигНа50ToolStripMenuItem.Name = "сдвигНа50ToolStripMenuItem";
            сдвигНа50ToolStripMenuItem.Size = new Size(179, 22);
            сдвигНа50ToolStripMenuItem.Text = "Сдвиг на 50";
            сдвигНа50ToolStripMenuItem.Click += сдвигНа50ToolStripMenuItem_Click;
            // 
            // сдвигНа50ВправоToolStripMenuItem
            // 
            сдвигНа50ВправоToolStripMenuItem.Name = "сдвигНа50ВправоToolStripMenuItem";
            сдвигНа50ВправоToolStripMenuItem.Size = new Size(179, 22);
            сдвигНа50ВправоToolStripMenuItem.Text = "Сдвиг на 50 вправо";
            сдвигНа50ВправоToolStripMenuItem.Click += сдвигНа50ВправоToolStripMenuItem_Click;
            // 
            // матричныеToolStripMenuItem
            // 
            матричныеToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { тиснениеToolStripMenuItem, размытиеВДвиженииToolStripMenuItem, серыйМирToolStripMenuItem, autolevelsToolStripMenuItem, идеальныйОтражательToolStripMenuItem, расширениеToolStripMenuItem, сужениеToolStripMenuItem, медианаToolStripMenuItem, фильтрСобеляToolStripMenuItem, фильтрШарраToolStripMenuItem });
            матричныеToolStripMenuItem.Name = "матричныеToolStripMenuItem";
            матричныеToolStripMenuItem.Size = new Size(139, 22);
            матричныеToolStripMenuItem.Text = "Матричные";
            // 
            // тиснениеToolStripMenuItem
            // 
            тиснениеToolStripMenuItem.Name = "тиснениеToolStripMenuItem";
            тиснениеToolStripMenuItem.Size = new Size(204, 22);
            тиснениеToolStripMenuItem.Text = "Тиснение";
            тиснениеToolStripMenuItem.Click += тиснениеToolStripMenuItem_Click;
            // 
            // размытиеВДвиженииToolStripMenuItem
            // 
            размытиеВДвиженииToolStripMenuItem.Name = "размытиеВДвиженииToolStripMenuItem";
            размытиеВДвиженииToolStripMenuItem.Size = new Size(204, 22);
            размытиеВДвиженииToolStripMenuItem.Text = "Размытие в движении";
            размытиеВДвиженииToolStripMenuItem.Click += размытиеВДвиженииToolStripMenuItem_Click;
            // 
            // серыйМирToolStripMenuItem
            // 
            серыйМирToolStripMenuItem.Name = "серыйМирToolStripMenuItem";
            серыйМирToolStripMenuItem.Size = new Size(204, 22);
            серыйМирToolStripMenuItem.Text = "Серый мир";
            серыйМирToolStripMenuItem.Click += серыйМирToolStripMenuItem_Click;
            // 
            // autolevelsToolStripMenuItem
            // 
            autolevelsToolStripMenuItem.Name = "autolevelsToolStripMenuItem";
            autolevelsToolStripMenuItem.Size = new Size(204, 22);
            autolevelsToolStripMenuItem.Text = "Autolevels";
            autolevelsToolStripMenuItem.Click += autolevelsToolStripMenuItem_Click;
            // 
            // идеальныйОтражательToolStripMenuItem
            // 
            идеальныйОтражательToolStripMenuItem.Name = "идеальныйОтражательToolStripMenuItem";
            идеальныйОтражательToolStripMenuItem.Size = new Size(204, 22);
            идеальныйОтражательToolStripMenuItem.Text = "Идеальный отражатель";
            идеальныйОтражательToolStripMenuItem.Click += идеальныйОтражательToolStripMenuItem_Click;
            // 
            // расширениеToolStripMenuItem
            // 
            расширениеToolStripMenuItem.Name = "расширениеToolStripMenuItem";
            расширениеToolStripMenuItem.Size = new Size(204, 22);
            расширениеToolStripMenuItem.Text = "Расширение";
            расширениеToolStripMenuItem.Click += расширениеToolStripMenuItem_Click;
            // 
            // сужениеToolStripMenuItem
            // 
            сужениеToolStripMenuItem.Name = "сужениеToolStripMenuItem";
            сужениеToolStripMenuItem.Size = new Size(204, 22);
            сужениеToolStripMenuItem.Text = "Сужение";
            сужениеToolStripMenuItem.Click += сужениеToolStripMenuItem_Click;
            // 
            // медианаToolStripMenuItem
            // 
            медианаToolStripMenuItem.Name = "медианаToolStripMenuItem";
            медианаToolStripMenuItem.Size = new Size(204, 22);
            медианаToolStripMenuItem.Text = "Медиана";
            медианаToolStripMenuItem.Click += медианаToolStripMenuItem_Click;
            // 
            // фильтрСобеляToolStripMenuItem
            // 
            фильтрСобеляToolStripMenuItem.Name = "фильтрСобеляToolStripMenuItem";
            фильтрСобеляToolStripMenuItem.Size = new Size(204, 22);
            фильтрСобеляToolStripMenuItem.Text = "Фильтр Собеля";
            фильтрСобеляToolStripMenuItem.Click += фильтрСобеляToolStripMenuItem_Click;
            // 
            // фильтрШарраToolStripMenuItem
            // 
            фильтрШарраToolStripMenuItem.Name = "фильтрШарраToolStripMenuItem";
            фильтрШарраToolStripMenuItem.Size = new Size(204, 22);
            фильтрШарраToolStripMenuItem.Text = "Фильтр Шарра";
            фильтрШарраToolStripMenuItem.Click += фильтрШарраToolStripMenuItem_Click;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(35, 399);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(649, 23);
            progressBar1.TabIndex = 2;
            // 
            // Отмена
            // 
            Отмена.Location = new Point(702, 399);
            Отмена.Name = "Отмена";
            Отмена.Size = new Size(75, 23);
            Отмена.TabIndex = 3;
            Отмена.Text = "Отмена";
            Отмена.UseVisualStyleBackColor = true;
            Отмена.Click += Свойства_Click;
            // 
            // backgroundWorker1
            // 
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Отмена);
            Controls.Add(progressBar1);
            Controls.Add(pictureBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private ToolStripMenuItem фильтрыToolStripMenuItem;
        private ToolStripMenuItem точечныеToolStripMenuItem;
        private ToolStripMenuItem инверсияToolStripMenuItem;
        private ToolStripMenuItem матричныеToolStripMenuItem;
        private ToolStripMenuItem оттенкиСерогоToolStripMenuItem;
        private ToolStripMenuItem сепияToolStripMenuItem;
        private ToolStripMenuItem увеличитьЯркостьToolStripMenuItem;
        private ToolStripMenuItem сдвигНа50ToolStripMenuItem;
        private ToolStripMenuItem сдвигНа50ВправоToolStripMenuItem;
        private ToolStripMenuItem тиснениеToolStripMenuItem;
        private ToolStripMenuItem размытиеВДвиженииToolStripMenuItem;
        private ToolStripMenuItem серыйМирToolStripMenuItem;
        private ToolStripMenuItem autolevelsToolStripMenuItem;
        private ToolStripMenuItem идеальныйОтражательToolStripMenuItem;
        private ToolStripMenuItem расширениеToolStripMenuItem;
        private ToolStripMenuItem сужениеToolStripMenuItem;
        private ToolStripMenuItem медианаToolStripMenuItem;
        private ToolStripMenuItem фильтрСобеляToolStripMenuItem;
        private ToolStripMenuItem фильтрШарраToolStripMenuItem;
        private ProgressBar progressBar1;
        private Button Отмена;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}
