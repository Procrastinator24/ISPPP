
namespace ISPPP
{
    partial class FormData
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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

        #region Windows Form Designer generated number

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the number editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormData));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_save = new System.Windows.Forms.Button();
            this.generate = new System.Windows.Forms.Button();
            this.numericUpDown_MaxTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_MinTime = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_M = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_N = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_N)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(784, 452);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.generate);
            this.panel1.Controls.Add(this.numericUpDown_MaxTime);
            this.panel1.Controls.Add(this.numericUpDown_MinTime);
            this.panel1.Controls.Add(this.numericUpDown_M);
            this.panel1.Controls.Add(this.numericUpDown_N);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(784, 124);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label6.Location = new System.Drawing.Point(13, 10);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 28);
            this.label6.TabIndex = 11;
            this.label6.Text = "Количество";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label5.Location = new System.Drawing.Point(293, 10);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Время";
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(580, 65);
            this.button_save.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(133, 33);
            this.button_save.TabIndex = 9;
            this.button_save.Text = "Выбрать";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button1_Click);
            // 
            // generate
            // 
            this.generate.Location = new System.Drawing.Point(580, 27);
            this.generate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.generate.Name = "generate";
            this.generate.Size = new System.Drawing.Size(133, 32);
            this.generate.TabIndex = 8;
            this.generate.Text = "Генерация";
            this.generate.UseVisualStyleBackColor = true;
            this.generate.Click += new System.EventHandler(this.generate_Click);
            // 
            // numericUpDown_MaxTime
            // 
            this.numericUpDown_MaxTime.Location = new System.Drawing.Point(453, 69);
            this.numericUpDown_MaxTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_MaxTime.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_MaxTime.Name = "numericUpDown_MaxTime";
            this.numericUpDown_MaxTime.Size = new System.Drawing.Size(64, 22);
            this.numericUpDown_MaxTime.TabIndex = 7;
            this.numericUpDown_MaxTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numericUpDown_MinTime
            // 
            this.numericUpDown_MinTime.Location = new System.Drawing.Point(453, 38);
            this.numericUpDown_MinTime.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_MinTime.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_MinTime.Name = "numericUpDown_MinTime";
            this.numericUpDown_MinTime.Size = new System.Drawing.Size(64, 22);
            this.numericUpDown_MinTime.TabIndex = 6;
            this.numericUpDown_MinTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numericUpDown_M
            // 
            this.numericUpDown_M.Location = new System.Drawing.Point(117, 69);
            this.numericUpDown_M.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_M.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_M.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_M.Name = "numericUpDown_M";
            this.numericUpDown_M.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown_M.TabIndex = 5;
            this.numericUpDown_M.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numericUpDown_N
            // 
            this.numericUpDown_N.Location = new System.Drawing.Point(117, 38);
            this.numericUpDown_N.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numericUpDown_N.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numericUpDown_N.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDown_N.Name = "numericUpDown_N";
            this.numericUpDown_N.Size = new System.Drawing.Size(67, 22);
            this.numericUpDown_N.TabIndex = 4;
            this.numericUpDown_N.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(317, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Максимальное:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(317, 42);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Минимальное:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Деталей:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Станков :";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dataGridView1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 452);
            this.panel2.TabIndex = 2;
            // 
            // FormData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 576);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormData";
            this.Text = "Данные";
            this.Load += new System.EventHandler(this.FormData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MaxTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_MinTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_N)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_MaxTime;
        private System.Windows.Forms.NumericUpDown numericUpDown_MinTime;
        private System.Windows.Forms.NumericUpDown numericUpDown_M;
        private System.Windows.Forms.NumericUpDown numericUpDown_N;
        private System.Windows.Forms.Button generate;
        private System.Windows.Forms.Button button_save;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
	}
}