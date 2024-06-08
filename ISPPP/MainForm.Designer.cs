
namespace ISPPP
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.данныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ГрафикToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.АлгоритмToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.джонсонToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обобщение1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обобщение2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обобщение3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обобщение4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обобщение5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.петровСоколицынToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сумма1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сумма2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сумма3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.PetrovSokolicin = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.formsPlot1 = new ScottPlot.FormsPlot();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.formsPlot3 = new ScottPlot.FormsPlot();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.formsPlot2 = new ScottPlot.FormsPlot();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.PetrovSokolicin.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.данныеToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.АлгоритмToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1028, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // данныеToolStripMenuItem
            // 
            this.данныеToolStripMenuItem.Name = "данныеToolStripMenuItem";
            this.данныеToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.данныеToolStripMenuItem.Text = "Данные";
            this.данныеToolStripMenuItem.Click += new System.EventHandler(this.данныеToolStripMenuItem_Click_1);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьToolStripMenuItem,
            this.загрузитьToolStripMenuItem1});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            this.файлToolStripMenuItem.Click += new System.EventHandler(this.файлToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem
            // 
            this.загрузитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьДанныеToolStripMenuItem,
            this.ГрафикToolStripMenuItem});
            this.загрузитьToolStripMenuItem.Name = "загрузитьToolStripMenuItem";
            this.загрузитьToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem.Text = "Сохранить";
            // 
            // сохранитьДанныеToolStripMenuItem
            // 
            this.сохранитьДанныеToolStripMenuItem.Name = "сохранитьДанныеToolStripMenuItem";
            this.сохранитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.сохранитьДанныеToolStripMenuItem.Text = "Данные";
            this.сохранитьДанныеToolStripMenuItem.Click += new System.EventHandler(this.ДанныеToolStripMenuItem_Click);
            // 
            // ГрафикToolStripMenuItem
            // 
            this.ГрафикToolStripMenuItem.Name = "ГрафикToolStripMenuItem";
            this.ГрафикToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.ГрафикToolStripMenuItem.Text = "График";
            this.ГрафикToolStripMenuItem.Click += new System.EventHandler(this.ГрафикToolStripMenuItem_Click);
            // 
            // загрузитьToolStripMenuItem1
            // 
            this.загрузитьToolStripMenuItem1.Name = "загрузитьToolStripMenuItem1";
            this.загрузитьToolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.загрузитьToolStripMenuItem1.Text = "Загрузить";
            this.загрузитьToolStripMenuItem1.Click += new System.EventHandler(this.загрузитьToolStripMenuItem1_Click);
            // 
            // АлгоритмToolStripMenuItem
            // 
            this.АлгоритмToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.джонсонToolStripMenuItem,
            this.петровСоколицынToolStripMenuItem});
            this.АлгоритмToolStripMenuItem.Enabled = false;
            this.АлгоритмToolStripMenuItem.Name = "АлгоритмToolStripMenuItem";
            this.АлгоритмToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.АлгоритмToolStripMenuItem.Text = "Алгоритм";
            // 
            // джонсонToolStripMenuItem
            // 
            this.джонсонToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.обобщение1ToolStripMenuItem,
            this.обобщение2ToolStripMenuItem,
            this.обобщение3ToolStripMenuItem,
            this.обобщение4ToolStripMenuItem,
            this.обобщение5ToolStripMenuItem});
            this.джонсонToolStripMenuItem.Name = "джонсонToolStripMenuItem";
            this.джонсонToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.джонсонToolStripMenuItem.Text = "Джонсон";
            this.джонсонToolStripMenuItem.Click += new System.EventHandler(this.джонсонToolStripMenuItem_Click);
            this.джонсонToolStripMenuItem.MouseEnter += new System.EventHandler(this.джонсонToolStripMenuItem_MouseEnter);
            // 
            // обобщение1ToolStripMenuItem
            // 
            this.обобщение1ToolStripMenuItem.Name = "обобщение1ToolStripMenuItem";
            this.обобщение1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обобщение1ToolStripMenuItem.Text = "Обобщение 1";
            this.обобщение1ToolStripMenuItem.Click += new System.EventHandler(this.обобщение1ToolStripMenuItem_Click);
            // 
            // обобщение2ToolStripMenuItem
            // 
            this.обобщение2ToolStripMenuItem.Name = "обобщение2ToolStripMenuItem";
            this.обобщение2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обобщение2ToolStripMenuItem.Text = "Обобщение 2";
            this.обобщение2ToolStripMenuItem.Click += new System.EventHandler(this.обобщение2ToolStripMenuItem_Click);
            // 
            // обобщение3ToolStripMenuItem
            // 
            this.обобщение3ToolStripMenuItem.Name = "обобщение3ToolStripMenuItem";
            this.обобщение3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обобщение3ToolStripMenuItem.Text = "Обобщение 3";
            this.обобщение3ToolStripMenuItem.Click += new System.EventHandler(this.обобщение3ToolStripMenuItem_Click);
            // 
            // обобщение4ToolStripMenuItem
            // 
            this.обобщение4ToolStripMenuItem.Name = "обобщение4ToolStripMenuItem";
            this.обобщение4ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обобщение4ToolStripMenuItem.Text = "Обобщение 4";
            this.обобщение4ToolStripMenuItem.Click += new System.EventHandler(this.обобщение4ToolStripMenuItem_Click);
            // 
            // обобщение5ToolStripMenuItem
            // 
            this.обобщение5ToolStripMenuItem.Name = "обобщение5ToolStripMenuItem";
            this.обобщение5ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.обобщение5ToolStripMenuItem.Text = "Обобщение 5";
            this.обобщение5ToolStripMenuItem.Click += new System.EventHandler(this.обобщение5ToolStripMenuItem_Click);
            // 
            // петровСоколицынToolStripMenuItem
            // 
            this.петровСоколицынToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сумма1ToolStripMenuItem,
            this.сумма2ToolStripMenuItem,
            this.сумма3ToolStripMenuItem});
            this.петровСоколицынToolStripMenuItem.Name = "петровСоколицынToolStripMenuItem";
            this.петровСоколицынToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.петровСоколицынToolStripMenuItem.Text = "Петров-Соколицын";
            this.петровСоколицынToolStripMenuItem.Click += new System.EventHandler(this.петровСоколицынToolStripMenuItem_Click);
            // 
            // сумма1ToolStripMenuItem
            // 
            this.сумма1ToolStripMenuItem.Name = "сумма1ToolStripMenuItem";
            this.сумма1ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сумма1ToolStripMenuItem.Text = "Сумма 1";
            this.сумма1ToolStripMenuItem.Click += new System.EventHandler(this.сумма1ToolStripMenuItem_Click);
            // 
            // сумма2ToolStripMenuItem
            // 
            this.сумма2ToolStripMenuItem.Name = "сумма2ToolStripMenuItem";
            this.сумма2ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сумма2ToolStripMenuItem.Text = "Сумма 2";
            this.сумма2ToolStripMenuItem.Click += new System.EventHandler(this.сумма2ToolStripMenuItem_Click);
            // 
            // сумма3ToolStripMenuItem
            // 
            this.сумма3ToolStripMenuItem.Name = "сумма3ToolStripMenuItem";
            this.сумма3ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.сумма3ToolStripMenuItem.Text = "Разность";
            this.сумма3ToolStripMenuItem.Click += new System.EventHandler(this.сумма3ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox1);
            this.panel1.Controls.Add(this.PetrovSokolicin);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1028, 324);
            this.panel1.TabIndex = 1;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(884, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(144, 324);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // PetrovSokolicin
            // 
            this.PetrovSokolicin.Controls.Add(this.tabPage1);
            this.PetrovSokolicin.Controls.Add(this.tabPage2);
            this.PetrovSokolicin.Dock = System.Windows.Forms.DockStyle.Left;
            this.PetrovSokolicin.Location = new System.Drawing.Point(0, 0);
            this.PetrovSokolicin.Name = "PetrovSokolicin";
            this.PetrovSokolicin.SelectedIndex = 0;
            this.PetrovSokolicin.Size = new System.Drawing.Size(884, 324);
            this.PetrovSokolicin.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.formsPlot1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 298);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jonson";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(430, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(448, 301);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // formsPlot1
            // 
            this.formsPlot1.Location = new System.Drawing.Point(3, 3);
            this.formsPlot1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot1.Name = "formsPlot1";
            this.formsPlot1.Size = new System.Drawing.Size(418, 291);
            this.formsPlot1.TabIndex = 0;
            this.formsPlot1.Load += new System.EventHandler(this.formsPlot1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.pictureBox3);
            this.tabPage2.Controls.Add(this.formsPlot3);
            this.tabPage2.Controls.Add(this.pictureBox2);
            this.tabPage2.Controls.Add(this.formsPlot2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(876, 298);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "PetrovSokolicin";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(424, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(448, 301);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 4;
            this.pictureBox3.TabStop = false;
            // 
            // formsPlot3
            // 
            this.formsPlot3.Location = new System.Drawing.Point(-3, 0);
            this.formsPlot3.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot3.Name = "formsPlot3";
            this.formsPlot3.Size = new System.Drawing.Size(418, 291);
            this.formsPlot3.TabIndex = 3;
            this.formsPlot3.Load += new System.EventHandler(this.formsPlot3_Load);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(696, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(158, 114);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // formsPlot2
            // 
            this.formsPlot2.Location = new System.Drawing.Point(712, 0);
            this.formsPlot2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.formsPlot2.Name = "formsPlot2";
            this.formsPlot2.Size = new System.Drawing.Size(70, 110);
            this.formsPlot2.TabIndex = 1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1028, 348);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Диаграмма";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.PetrovSokolicin.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьToolStripMenuItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem АлгоритмToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem джонсонToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обобщение1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обобщение2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обобщение3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обобщение4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обобщение5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem петровСоколицынToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сумма1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сумма2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сумма3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ГрафикToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
		private System.Windows.Forms.ToolStripMenuItem данныеToolStripMenuItem;
		private System.Windows.Forms.TabControl PetrovSokolicin;
		private System.Windows.Forms.TabPage tabPage1;
		private ScottPlot.FormsPlot formsPlot1;
		private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ScottPlot.FormsPlot formsPlot2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private ScottPlot.FormsPlot formsPlot3;
    }
}

