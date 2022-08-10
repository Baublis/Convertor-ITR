namespace CITR
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox_exel = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox_soft_setting = new System.Windows.Forms.GroupBox();
            this.checkBox_textparting = new System.Windows.Forms.CheckBox();
            this.groupBox_lines = new System.Windows.Forms.GroupBox();
            this.textBox_lines = new System.Windows.Forms.TextBox();
            this.checkBox_txt = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button_switch = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TextBox_Application = new System.Windows.Forms.RichTextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox_soft_setting.SuspendLayout();
            this.groupBox_lines.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_exel
            // 
            this.checkBox_exel.Checked = true;
            this.checkBox_exel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_exel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_exel.Location = new System.Drawing.Point(12, 155);
            this.checkBox_exel.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_exel.Name = "checkBox_exel";
            this.checkBox_exel.Size = new System.Drawing.Size(372, 29);
            this.checkBox_exel.TabIndex = 2;
            this.checkBox_exel.Text = "Генерить базу переменных EXEL";
            this.checkBox_exel.UseVisualStyleBackColor = true;
            this.checkBox_exel.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_exel.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(12, 63);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(372, 87);
            this.button1.TabIndex = 1;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Main_Soft);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox_soft_setting
            // 
            this.groupBox_soft_setting.Controls.Add(this.checkBox_textparting);
            this.groupBox_soft_setting.Controls.Add(this.groupBox_lines);
            this.groupBox_soft_setting.Controls.Add(this.checkBox_txt);
            this.groupBox_soft_setting.Controls.Add(this.button1);
            this.groupBox_soft_setting.Controls.Add(this.checkBox_exel);
            this.groupBox_soft_setting.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox_soft_setting.Location = new System.Drawing.Point(12, 35);
            this.groupBox_soft_setting.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_soft_setting.Name = "groupBox_soft_setting";
            this.groupBox_soft_setting.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_soft_setting.Size = new System.Drawing.Size(394, 486);
            this.groupBox_soft_setting.TabIndex = 2;
            this.groupBox_soft_setting.TabStop = false;
            this.groupBox_soft_setting.Text = "ISaGRAF";
            // 
            // checkBox_textparting
            // 
            this.checkBox_textparting.Checked = true;
            this.checkBox_textparting.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_textparting.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_textparting.Location = new System.Drawing.Point(12, 222);
            this.checkBox_textparting.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_textparting.Name = "checkBox_textparting";
            this.checkBox_textparting.Size = new System.Drawing.Size(372, 29);
            this.checkBox_textparting.TabIndex = 4;
            this.checkBox_textparting.Text = "Разделять большие файлы";
            this.checkBox_textparting.UseVisualStyleBackColor = true;
            this.checkBox_textparting.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_textparting.Click += new System.EventHandler(this.checkBox_textparting_Click);
            this.checkBox_textparting.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // groupBox_lines
            // 
            this.groupBox_lines.Controls.Add(this.textBox_lines);
            this.groupBox_lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox_lines.Location = new System.Drawing.Point(12, 256);
            this.groupBox_lines.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_lines.Name = "groupBox_lines";
            this.groupBox_lines.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_lines.Size = new System.Drawing.Size(210, 88);
            this.groupBox_lines.TabIndex = 6;
            this.groupBox_lines.TabStop = false;
            this.groupBox_lines.Text = "Максимальное количество строк";
            // 
            // textBox_lines
            // 
            this.textBox_lines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_lines.Location = new System.Drawing.Point(7, 51);
            this.textBox_lines.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_lines.Name = "textBox_lines";
            this.textBox_lines.Size = new System.Drawing.Size(194, 26);
            this.textBox_lines.TabIndex = 0;
            this.textBox_lines.Text = "3000";
            this.textBox_lines.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_lines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_lines.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_lines_KeyPress);
            this.textBox_lines.Layout += new System.Windows.Forms.LayoutEventHandler(this.textBox_Layout);
            // 
            // checkBox_txt
            // 
            this.checkBox_txt.Checked = true;
            this.checkBox_txt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_txt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_txt.Location = new System.Drawing.Point(12, 188);
            this.checkBox_txt.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_txt.Name = "checkBox_txt";
            this.checkBox_txt.Size = new System.Drawing.Size(372, 29);
            this.checkBox_txt.TabIndex = 3;
            this.checkBox_txt.Text = "Генерить FB, FB ModBus и IEC Program";
            this.checkBox_txt.UseVisualStyleBackColor = true;
            this.checkBox_txt.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_txt.Click += new System.EventHandler(this.checkBox_txt_Click);
            this.checkBox_txt.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button_switch);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox_soft_setting);
            this.groupBox3.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(12, 38);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(836, 541);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(412, 333);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(397, 92);
            this.button4.TabIndex = 7;
            this.button4.Text = "Help";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.Button_Help_Click);
            // 
            // button_switch
            // 
            this.button_switch.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_switch.Location = new System.Drawing.Point(412, 429);
            this.button_switch.Margin = new System.Windows.Forms.Padding(2);
            this.button_switch.Name = "button_switch";
            this.button_switch.Size = new System.Drawing.Size(397, 92);
            this.button_switch.TabIndex = 1;
            this.button_switch.Text = "Astra IDE";
            this.button_switch.UseVisualStyleBackColor = true;
            this.button_switch.Click += new System.EventHandler(this.Select_Form);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TextBox_Application);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(412, 35);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(397, 294);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Uploaded files";
            // 
            // TextBox_Application
            // 
            this.TextBox_Application.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBox_Application.Font = new System.Drawing.Font("Lucida Console", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox_Application.HideSelection = false;
            this.TextBox_Application.Location = new System.Drawing.Point(12, 69);
            this.TextBox_Application.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox_Application.Name = "TextBox_Application";
            this.TextBox_Application.ReadOnly = true;
            this.TextBox_Application.Size = new System.Drawing.Size(423, 58);
            this.TextBox_Application.TabIndex = 7;
            this.TextBox_Application.Text = "Имя Application.xml";
            this.TextBox_Application.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 738);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(922, 35);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(871, 589);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Convertor ITR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit_application);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.VisibleChanged += new System.EventHandler(this.Form2_VisibleChanged);
            this.groupBox_soft_setting.ResumeLayout(false);
            this.groupBox_lines.ResumeLayout(false);
            this.groupBox_lines.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.CheckBox checkBox_exel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox_soft_setting;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RichTextBox TextBox_Application;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_switch;
        public System.Windows.Forms.CheckBox checkBox_txt;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox_lines;
        private System.Windows.Forms.TextBox textBox_lines;
        public System.Windows.Forms.CheckBox checkBox_textparting;
        private System.Windows.Forms.Button button4;
    }
}

