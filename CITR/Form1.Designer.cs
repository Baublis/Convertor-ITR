namespace CITR
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.checkBox_MBTCP = new System.Windows.Forms.CheckBox();
            this.checkBox_IEC = new System.Windows.Forms.CheckBox();
            this.checkBoxR200 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox_BROADCAST = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox_MB_OS = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.textBox_TR_sum = new System.Windows.Forms.RichTextBox();
            this.textBox_TR = new System.Windows.Forms.RichTextBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.textBox_TI_sum = new System.Windows.Forms.RichTextBox();
            this.textBox_TI = new System.Windows.Forms.RichTextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.textBox_TU_sum = new System.Windows.Forms.RichTextBox();
            this.textBox_TU = new System.Windows.Forms.RichTextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_version = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_TS_sum = new System.Windows.Forms.RichTextBox();
            this.textBox_TS = new System.Windows.Forms.RichTextBox();
            this.checkBox_MBS_RTU_2 = new System.Windows.Forms.CheckBox();
            this.checkBox_IO = new System.Windows.Forms.CheckBox();
            this.checkBox_MBS_RTU_1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox_ARDEV = new System.Windows.Forms.CheckBox();
            this.checkBox_FB_field = new System.Windows.Forms.CheckBox();
            this.checkBox_imit = new System.Windows.Forms.CheckBox();
            this.groupBox_CMD = new System.Windows.Forms.GroupBox();
            this.groupBox_CMD_2 = new System.Windows.Forms.GroupBox();
            this.textBox_CMD_2 = new System.Windows.Forms.TextBox();
            this.groupBox_CMD_1 = new System.Windows.Forms.GroupBox();
            this.textBox_CMD_1 = new System.Windows.Forms.TextBox();
            this.checkBox_VQT = new System.Windows.Forms.CheckBox();
            this.checkBox_AutoTime = new System.Windows.Forms.CheckBox();
            this.checkBox_IEC_EDC = new System.Windows.Forms.CheckBox();
            this.checkBox_RETAIN = new System.Windows.Forms.CheckBox();
            this.checkBox_PERSISTENT = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TextBox_apr = new System.Windows.Forms.RichTextBox();
            this.TextBox3 = new System.Windows.Forms.RichTextBox();
            this.TextBox_apllication = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.radioButton_epsilon = new System.Windows.Forms.RadioButton();
            this.radioButton_astra = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox_CMD.SuspendLayout();
            this.groupBox_CMD_2.SuspendLayout();
            this.groupBox_CMD_1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkBox_MBTCP
            // 
            this.checkBox_MBTCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_MBTCP.Location = new System.Drawing.Point(12, 141);
            this.checkBox_MBTCP.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_MBTCP.Name = "checkBox_MBTCP";
            this.checkBox_MBTCP.Size = new System.Drawing.Size(164, 29);
            this.checkBox_MBTCP.TabIndex = 2;
            this.checkBox_MBTCP.Text = "ModBus TCP Slave";
            this.checkBox_MBTCP.UseVisualStyleBackColor = true;
            this.checkBox_MBTCP.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_MBTCP.Click += new System.EventHandler(this.checkBox_MBTCP_Click);
            this.checkBox_MBTCP.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_IEC
            // 
            this.checkBox_IEC.Checked = true;
            this.checkBox_IEC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_IEC.Location = new System.Drawing.Point(198, 42);
            this.checkBox_IEC.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_IEC.Name = "checkBox_IEC";
            this.checkBox_IEC.Size = new System.Drawing.Size(190, 29);
            this.checkBox_IEC.TabIndex = 3;
            this.checkBox_IEC.Text = "IEC104 Slave";
            this.checkBox_IEC.UseVisualStyleBackColor = true;
            this.checkBox_IEC.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_IEC.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBoxR200
            // 
            this.checkBoxR200.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxR200.Location = new System.Drawing.Point(12, 253);
            this.checkBoxR200.Margin = new System.Windows.Forms.Padding(2);
            this.checkBoxR200.Name = "checkBoxR200";
            this.checkBoxR200.Size = new System.Drawing.Size(164, 29);
            this.checkBoxR200.TabIndex = 1;
            this.checkBoxR200.Text = "Regul R200";
            this.checkBoxR200.UseVisualStyleBackColor = true;
            this.checkBoxR200.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBoxR200.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(12, 42);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 87);
            this.button1.TabIndex = 1;
            this.button1.Text = "START";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Main_Soft);
            // 
            // checkBox_BROADCAST
            // 
            this.checkBox_BROADCAST.Checked = true;
            this.checkBox_BROADCAST.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_BROADCAST.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_BROADCAST.Location = new System.Drawing.Point(12, 319);
            this.checkBox_BROADCAST.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_BROADCAST.Name = "checkBox_BROADCAST";
            this.checkBox_BROADCAST.Size = new System.Drawing.Size(372, 29);
            this.checkBox_BROADCAST.TabIndex = 8;
            this.checkBox_BROADCAST.Text = "Резервировать стуктуры по маске SHARED\r\n";
            this.checkBox_BROADCAST.UseVisualStyleBackColor = true;
            this.checkBox_BROADCAST.Visible = false;
            this.checkBox_BROADCAST.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_BROADCAST.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox_MB_OS);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.groupBox9);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Controls.Add(this.checkBox_MBS_RTU_2);
            this.groupBox1.Controls.Add(this.checkBox_IO);
            this.groupBox1.Controls.Add(this.checkBox_MBS_RTU_1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(815, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(397, 487);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "НУ и ИО для ВУ";
            // 
            // checkBox_MB_OS
            // 
            this.checkBox_MB_OS.Checked = true;
            this.checkBox_MB_OS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_MB_OS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_MB_OS.Location = new System.Drawing.Point(263, 331);
            this.checkBox_MB_OS.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_MB_OS.Name = "checkBox_MB_OS";
            this.checkBox_MB_OS.Size = new System.Drawing.Size(122, 32);
            this.checkBox_MB_OS.TabIndex = 13;
            this.checkBox_MB_OS.Text = "ModBus OS";
            this.checkBox_MB_OS.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox1.Location = new System.Drawing.Point(263, 213);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(122, 55);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Генерить ИО для PGE";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox1.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.textBox_TR_sum);
            this.groupBox10.Controls.Add(this.textBox_TR);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox10.Location = new System.Drawing.Point(12, 240);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox10.Size = new System.Drawing.Size(245, 69);
            this.groupBox10.TabIndex = 10;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Количество ТР";
            // 
            // textBox_TR_sum
            // 
            this.textBox_TR_sum.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TR_sum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TR_sum.HideSelection = false;
            this.textBox_TR_sum.Location = new System.Drawing.Point(163, 25);
            this.textBox_TR_sum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TR_sum.Name = "textBox_TR_sum";
            this.textBox_TR_sum.ReadOnly = true;
            this.textBox_TR_sum.Size = new System.Drawing.Size(69, 28);
            this.textBox_TR_sum.TabIndex = 11;
            this.textBox_TR_sum.Text = "Сумма";
            this.textBox_TR_sum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBox_TR
            // 
            this.textBox_TR.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TR.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TR.HideSelection = false;
            this.textBox_TR.Location = new System.Drawing.Point(12, 25);
            this.textBox_TR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TR.Name = "textBox_TR";
            this.textBox_TR.ReadOnly = true;
            this.textBox_TR.Size = new System.Drawing.Size(139, 28);
            this.textBox_TR.TabIndex = 10;
            this.textBox_TR.Text = "";
            this.textBox_TR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.textBox_TI_sum);
            this.groupBox9.Controls.Add(this.textBox_TI);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox9.Location = new System.Drawing.Point(12, 325);
            this.groupBox9.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox9.Size = new System.Drawing.Size(245, 69);
            this.groupBox9.TabIndex = 11;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Количество ТИ";
            // 
            // textBox_TI_sum
            // 
            this.textBox_TI_sum.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TI_sum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TI_sum.HideSelection = false;
            this.textBox_TI_sum.Location = new System.Drawing.Point(163, 25);
            this.textBox_TI_sum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TI_sum.Name = "textBox_TI_sum";
            this.textBox_TI_sum.ReadOnly = true;
            this.textBox_TI_sum.Size = new System.Drawing.Size(69, 28);
            this.textBox_TI_sum.TabIndex = 11;
            this.textBox_TI_sum.Text = "Сумма";
            this.textBox_TI_sum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBox_TI
            // 
            this.textBox_TI.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TI.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TI.HideSelection = false;
            this.textBox_TI.Location = new System.Drawing.Point(12, 25);
            this.textBox_TI.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TI.Name = "textBox_TI";
            this.textBox_TI.ReadOnly = true;
            this.textBox_TI.Size = new System.Drawing.Size(139, 28);
            this.textBox_TI.TabIndex = 10;
            this.textBox_TI.Text = "";
            this.textBox_TI.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.textBox_TU_sum);
            this.groupBox8.Controls.Add(this.textBox_TU);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox8.Location = new System.Drawing.Point(12, 410);
            this.groupBox8.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox8.Size = new System.Drawing.Size(245, 69);
            this.groupBox8.TabIndex = 12;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Количество ТУ";
            // 
            // textBox_TU_sum
            // 
            this.textBox_TU_sum.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TU_sum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TU_sum.HideSelection = false;
            this.textBox_TU_sum.Location = new System.Drawing.Point(163, 23);
            this.textBox_TU_sum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TU_sum.Name = "textBox_TU_sum";
            this.textBox_TU_sum.ReadOnly = true;
            this.textBox_TU_sum.Size = new System.Drawing.Size(69, 28);
            this.textBox_TU_sum.TabIndex = 11;
            this.textBox_TU_sum.Text = "Сумма";
            this.textBox_TU_sum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBox_TU
            // 
            this.textBox_TU.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TU.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TU.HideSelection = false;
            this.textBox_TU.Location = new System.Drawing.Point(12, 25);
            this.textBox_TU.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TU.Name = "textBox_TU";
            this.textBox_TU.ReadOnly = true;
            this.textBox_TU.Size = new System.Drawing.Size(139, 28);
            this.textBox_TU.TabIndex = 10;
            this.textBox_TU.Text = "";
            this.textBox_TU.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox_version);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox6.Location = new System.Drawing.Point(267, 424);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox6.Size = new System.Drawing.Size(122, 55);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dev Version";
            // 
            // textBox_version
            // 
            this.textBox_version.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_version.Location = new System.Drawing.Point(12, 22);
            this.textBox_version.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_version.Name = "textBox_version";
            this.textBox_version.Size = new System.Drawing.Size(98, 26);
            this.textBox_version.TabIndex = 0;
            this.textBox_version.Text = "1.6.5.1";
            this.textBox_version.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_version.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_version.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_version_KeyPress);
            this.textBox_version.Layout += new System.Windows.Forms.LayoutEventHandler(this.textBox_Layout);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox_TS_sum);
            this.groupBox7.Controls.Add(this.textBox_TS);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox7.Location = new System.Drawing.Point(12, 158);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox7.Size = new System.Drawing.Size(245, 69);
            this.groupBox7.TabIndex = 9;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Количество ТС";
            // 
            // textBox_TS_sum
            // 
            this.textBox_TS_sum.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TS_sum.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TS_sum.HideSelection = false;
            this.textBox_TS_sum.Location = new System.Drawing.Point(163, 25);
            this.textBox_TS_sum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TS_sum.Name = "textBox_TS_sum";
            this.textBox_TS_sum.ReadOnly = true;
            this.textBox_TS_sum.Size = new System.Drawing.Size(69, 28);
            this.textBox_TS_sum.TabIndex = 11;
            this.textBox_TS_sum.Text = "Сумма";
            this.textBox_TS_sum.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // textBox_TS
            // 
            this.textBox_TS.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textBox_TS.Font = new System.Drawing.Font("Arial", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_TS.HideSelection = false;
            this.textBox_TS.Location = new System.Drawing.Point(12, 25);
            this.textBox_TS.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_TS.Name = "textBox_TS";
            this.textBox_TS.ReadOnly = true;
            this.textBox_TS.Size = new System.Drawing.Size(139, 28);
            this.textBox_TS.TabIndex = 10;
            this.textBox_TS.Text = "";
            this.textBox_TS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // checkBox_MBS_RTU_2
            // 
            this.checkBox_MBS_RTU_2.Checked = true;
            this.checkBox_MBS_RTU_2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_MBS_RTU_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_MBS_RTU_2.Location = new System.Drawing.Point(263, 367);
            this.checkBox_MBS_RTU_2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_MBS_RTU_2.Name = "checkBox_MBS_RTU_2";
            this.checkBox_MBS_RTU_2.Size = new System.Drawing.Size(122, 55);
            this.checkBox_MBS_RTU_2.TabIndex = 5;
            this.checkBox_MBS_RTU_2.Text = "Удалять исходники ModBus НУ";
            this.checkBox_MBS_RTU_2.UseVisualStyleBackColor = true;
            this.checkBox_MBS_RTU_2.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_MBS_RTU_2.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_IO
            // 
            this.checkBox_IO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_IO.Location = new System.Drawing.Point(263, 154);
            this.checkBox_IO.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_IO.Name = "checkBox_IO";
            this.checkBox_IO.Size = new System.Drawing.Size(122, 55);
            this.checkBox_IO.TabIndex = 2;
            this.checkBox_IO.Text = "Генерить ИО для DevStudio";
            this.checkBox_IO.UseVisualStyleBackColor = true;
            this.checkBox_IO.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_IO.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_MBS_RTU_1
            // 
            this.checkBox_MBS_RTU_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_MBS_RTU_1.Location = new System.Drawing.Point(263, 272);
            this.checkBox_MBS_RTU_1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_MBS_RTU_1.Name = "checkBox_MBS_RTU_1";
            this.checkBox_MBS_RTU_1.Size = new System.Drawing.Size(122, 55);
            this.checkBox_MBS_RTU_1.TabIndex = 4;
            this.checkBox_MBS_RTU_1.Text = "Генерить карту ModBus НУ";
            this.checkBox_MBS_RTU_1.UseVisualStyleBackColor = true;
            this.checkBox_MBS_RTU_1.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_MBS_RTU_1.Click += new System.EventHandler(this.checbox_MBS_RTU_Click);
            this.checkBox_MBS_RTU_1.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // button2
            // 
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(12, 63);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(373, 87);
            this.button2.TabIndex = 1;
            this.button2.Text = "START";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Main_IO);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox_ARDEV);
            this.groupBox2.Controls.Add(this.checkBox_FB_field);
            this.groupBox2.Controls.Add(this.checkBox_imit);
            this.groupBox2.Controls.Add(this.groupBox_CMD);
            this.groupBox2.Controls.Add(this.checkBox_VQT);
            this.groupBox2.Controls.Add(this.checkBox_AutoTime);
            this.groupBox2.Controls.Add(this.checkBox_IEC_EDC);
            this.groupBox2.Controls.Add(this.checkBox_RETAIN);
            this.groupBox2.Controls.Add(this.checkBox_PERSISTENT);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.checkBoxR200);
            this.groupBox2.Controls.Add(this.checkBox_BROADCAST);
            this.groupBox2.Controls.Add(this.checkBox_IEC);
            this.groupBox2.Controls.Add(this.checkBox_MBTCP);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(12, 35);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox2.Size = new System.Drawing.Size(394, 486);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Astra IDE";
            // 
            // checkBox_ARDEV
            // 
            this.checkBox_ARDEV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_ARDEV.Location = new System.Drawing.Point(12, 174);
            this.checkBox_ARDEV.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_ARDEV.Name = "checkBox_ARDEV";
            this.checkBox_ARDEV.Size = new System.Drawing.Size(164, 75);
            this.checkBox_ARDEV.TabIndex = 13;
            this.checkBox_ARDEV.Text = "Указатели на единую область памяти для ModBus TCP";
            this.checkBox_ARDEV.UseVisualStyleBackColor = true;
            this.checkBox_ARDEV.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_ARDEV.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_FB_field
            // 
            this.checkBox_FB_field.Checked = true;
            this.checkBox_FB_field.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_FB_field.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_FB_field.Location = new System.Drawing.Point(12, 448);
            this.checkBox_FB_field.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_FB_field.Name = "checkBox_FB_field";
            this.checkBox_FB_field.Size = new System.Drawing.Size(372, 29);
            this.checkBox_FB_field.TabIndex = 12;
            this.checkBox_FB_field.Text = "Перенос кода секции *FB в field";
            this.checkBox_FB_field.UseVisualStyleBackColor = true;
            this.checkBox_FB_field.Visible = false;
            this.checkBox_FB_field.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_FB_field.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_imit
            // 
            this.checkBox_imit.Checked = true;
            this.checkBox_imit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_imit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_imit.Location = new System.Drawing.Point(12, 419);
            this.checkBox_imit.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_imit.Name = "checkBox_imit";
            this.checkBox_imit.Size = new System.Drawing.Size(372, 29);
            this.checkBox_imit.TabIndex = 11;
            this.checkBox_imit.Text = "Преобразования для имитации поля";
            this.checkBox_imit.UseVisualStyleBackColor = true;
            this.checkBox_imit.Visible = false;
            this.checkBox_imit.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_imit.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // groupBox_CMD
            // 
            this.groupBox_CMD.Controls.Add(this.groupBox_CMD_2);
            this.groupBox_CMD.Controls.Add(this.groupBox_CMD_1);
            this.groupBox_CMD.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox_CMD.Location = new System.Drawing.Point(198, 139);
            this.groupBox_CMD.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_CMD.Name = "groupBox_CMD";
            this.groupBox_CMD.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_CMD.Size = new System.Drawing.Size(190, 100);
            this.groupBox_CMD.TabIndex = 7;
            this.groupBox_CMD.TabStop = false;
            this.groupBox_CMD.Text = "Время блокировки команды, мс";
            // 
            // groupBox_CMD_2
            // 
            this.groupBox_CMD_2.Controls.Add(this.textBox_CMD_2);
            this.groupBox_CMD_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox_CMD_2.Location = new System.Drawing.Point(95, 40);
            this.groupBox_CMD_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_CMD_2.Name = "groupBox_CMD_2";
            this.groupBox_CMD_2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_CMD_2.Size = new System.Drawing.Size(85, 50);
            this.groupBox_CMD_2.TabIndex = 9;
            this.groupBox_CMD_2.TabStop = false;
            this.groupBox_CMD_2.Text = "IEC104_EDC";
            // 
            // textBox_CMD_2
            // 
            this.textBox_CMD_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_CMD_2.Location = new System.Drawing.Point(5, 18);
            this.textBox_CMD_2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_CMD_2.Name = "textBox_CMD_2";
            this.textBox_CMD_2.Size = new System.Drawing.Size(75, 26);
            this.textBox_CMD_2.TabIndex = 1;
            this.textBox_CMD_2.Text = "5000";
            this.textBox_CMD_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_CMD_2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_CMD_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CMD_KeyPress);
            this.textBox_CMD_2.Layout += new System.Windows.Forms.LayoutEventHandler(this.textBox_Layout);
            // 
            // groupBox_CMD_1
            // 
            this.groupBox_CMD_1.Controls.Add(this.textBox_CMD_1);
            this.groupBox_CMD_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox_CMD_1.Location = new System.Drawing.Point(5, 40);
            this.groupBox_CMD_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_CMD_1.Name = "groupBox_CMD_1";
            this.groupBox_CMD_1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox_CMD_1.Size = new System.Drawing.Size(85, 50);
            this.groupBox_CMD_1.TabIndex = 8;
            this.groupBox_CMD_1.TabStop = false;
            this.groupBox_CMD_1.Text = "IEC104";
            // 
            // textBox_CMD_1
            // 
            this.textBox_CMD_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_CMD_1.Location = new System.Drawing.Point(5, 18);
            this.textBox_CMD_1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBox_CMD_1.Name = "textBox_CMD_1";
            this.textBox_CMD_1.Size = new System.Drawing.Size(75, 26);
            this.textBox_CMD_1.TabIndex = 0;
            this.textBox_CMD_1.Text = "5000";
            this.textBox_CMD_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_CMD_1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            this.textBox_CMD_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_CMD_KeyPress);
            this.textBox_CMD_1.Layout += new System.Windows.Forms.LayoutEventHandler(this.textBox_Layout);
            // 
            // checkBox_VQT
            // 
            this.checkBox_VQT.Checked = true;
            this.checkBox_VQT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_VQT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_VQT.Location = new System.Drawing.Point(12, 286);
            this.checkBox_VQT.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_VQT.Name = "checkBox_VQT";
            this.checkBox_VQT.Size = new System.Drawing.Size(372, 29);
            this.checkBox_VQT.TabIndex = 6;
            this.checkBox_VQT.Text = "Перекладка IEC104 с учетом VQT";
            this.checkBox_VQT.UseVisualStyleBackColor = true;
            this.checkBox_VQT.Visible = false;
            this.checkBox_VQT.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_VQT.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_AutoTime
            // 
            this.checkBox_AutoTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_AutoTime.Location = new System.Drawing.Point(198, 108);
            this.checkBox_AutoTime.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_AutoTime.Name = "checkBox_AutoTime";
            this.checkBox_AutoTime.Size = new System.Drawing.Size(190, 29);
            this.checkBox_AutoTime.TabIndex = 4;
            this.checkBox_AutoTime.Text = "IEC104 Slave : AutoTime";
            this.checkBox_AutoTime.UseVisualStyleBackColor = true;
            this.checkBox_AutoTime.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_AutoTime.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_IEC_EDC
            // 
            this.checkBox_IEC_EDC.Checked = true;
            this.checkBox_IEC_EDC.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_IEC_EDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_IEC_EDC.Location = new System.Drawing.Point(198, 75);
            this.checkBox_IEC_EDC.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_IEC_EDC.Name = "checkBox_IEC_EDC";
            this.checkBox_IEC_EDC.Size = new System.Drawing.Size(190, 29);
            this.checkBox_IEC_EDC.TabIndex = 5;
            this.checkBox_IEC_EDC.Text = "IEC104 Slave EDC";
            this.checkBox_IEC_EDC.UseVisualStyleBackColor = true;
            this.checkBox_IEC_EDC.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_IEC_EDC.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_RETAIN
            // 
            this.checkBox_RETAIN.Checked = true;
            this.checkBox_RETAIN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_RETAIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_RETAIN.Location = new System.Drawing.Point(12, 385);
            this.checkBox_RETAIN.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_RETAIN.Name = "checkBox_RETAIN";
            this.checkBox_RETAIN.Size = new System.Drawing.Size(372, 29);
            this.checkBox_RETAIN.TabIndex = 10;
            this.checkBox_RETAIN.Text = "Не сохранять флаг инициальзации в RETAIN";
            this.checkBox_RETAIN.UseVisualStyleBackColor = true;
            this.checkBox_RETAIN.Visible = false;
            this.checkBox_RETAIN.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_RETAIN.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // checkBox_PERSISTENT
            // 
            this.checkBox_PERSISTENT.Checked = true;
            this.checkBox_PERSISTENT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_PERSISTENT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBox_PERSISTENT.Location = new System.Drawing.Point(12, 352);
            this.checkBox_PERSISTENT.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox_PERSISTENT.Name = "checkBox_PERSISTENT";
            this.checkBox_PERSISTENT.Size = new System.Drawing.Size(372, 29);
            this.checkBox_PERSISTENT.TabIndex = 9;
            this.checkBox_PERSISTENT.Text = "Преобразовать GVL RETAIN в GVL PERSISTENT";
            this.checkBox_PERSISTENT.UseVisualStyleBackColor = true;
            this.checkBox_PERSISTENT.Visible = false;
            this.checkBox_PERSISTENT.CheckStateChanged += new System.EventHandler(this.checkBox_CheckStateChanged);
            this.checkBox_PERSISTENT.Layout += new System.Windows.Forms.LayoutEventHandler(this.checkBox_Layout);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Font = new System.Drawing.Font("Segoe Print", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(12, 38);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(1233, 541);
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
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(412, 429);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(397, 92);
            this.button3.TabIndex = 1;
            this.button3.Text = "ISaGRAF";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.selection_Form);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TextBox_apr);
            this.groupBox4.Controls.Add(this.TextBox3);
            this.groupBox4.Controls.Add(this.TextBox_apllication);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox4.Location = new System.Drawing.Point(412, 35);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox4.Size = new System.Drawing.Size(397, 294);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Uploaded files";
            // 
            // TextBox_apr
            // 
            this.TextBox_apr.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBox_apr.Font = new System.Drawing.Font("Lucida Console", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox_apr.HideSelection = false;
            this.TextBox_apr.Location = new System.Drawing.Point(12, 69);
            this.TextBox_apr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox_apr.Name = "TextBox_apr";
            this.TextBox_apr.ReadOnly = true;
            this.TextBox_apr.Size = new System.Drawing.Size(373, 66);
            this.TextBox_apr.TabIndex = 7;
            this.TextBox_apr.Text = "Имя APR.xml";
            this.TextBox_apr.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // TextBox3
            // 
            this.TextBox3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBox3.Font = new System.Drawing.Font("Lucida Console", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox3.HideSelection = false;
            this.TextBox3.Location = new System.Drawing.Point(12, 219);
            this.TextBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox3.Name = "TextBox3";
            this.TextBox3.ReadOnly = true;
            this.TextBox3.Size = new System.Drawing.Size(373, 66);
            this.TextBox3.TabIndex = 9;
            this.TextBox3.Text = "Имена CSV";
            this.TextBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // TextBox_apllication
            // 
            this.TextBox_apllication.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.TextBox_apllication.Font = new System.Drawing.Font("Lucida Console", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TextBox_apllication.HideSelection = false;
            this.TextBox_apllication.Location = new System.Drawing.Point(12, 146);
            this.TextBox_apllication.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.TextBox_apllication.Name = "TextBox_apllication";
            this.TextBox_apllication.ReadOnly = true;
            this.TextBox_apllication.Size = new System.Drawing.Size(373, 66);
            this.TextBox_apllication.TabIndex = 8;
            this.TextBox_apllication.Text = "Имя Application.xml";
            this.TextBox_apllication.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyDown);
            // 
            // radioButton_epsilon
            // 
            this.radioButton_epsilon.AutoSize = true;
            this.radioButton_epsilon.Location = new System.Drawing.Point(12, 13);
            this.radioButton_epsilon.Name = "radioButton_epsilon";
            this.radioButton_epsilon.Size = new System.Drawing.Size(80, 19);
            this.radioButton_epsilon.TabIndex = 4;
            this.radioButton_epsilon.Text = "Epsilon LD";
            this.radioButton_epsilon.UseVisualStyleBackColor = true;
            this.radioButton_epsilon.CheckedChanged += new System.EventHandler(this.radio_CheckStateChanged);
            this.radioButton_epsilon.Click += new System.EventHandler(this.select_Epsilon);
            // 
            // radioButton_astra
            // 
            this.radioButton_astra.AutoSize = true;
            this.radioButton_astra.Checked = true;
            this.radioButton_astra.Location = new System.Drawing.Point(112, 12);
            this.radioButton_astra.Name = "radioButton_astra";
            this.radioButton_astra.Size = new System.Drawing.Size(72, 19);
            this.radioButton_astra.TabIndex = 5;
            this.radioButton_astra.TabStop = true;
            this.radioButton_astra.Text = "Astra IDE";
            this.radioButton_astra.UseVisualStyleBackColor = true;
            this.radioButton_astra.CheckedChanged += new System.EventHandler(this.radio_CheckStateChanged);
            this.radioButton_astra.Click += new System.EventHandler(this.select_Astra);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 589);
            this.Controls.Add(this.radioButton_astra);
            this.Controls.Add(this.radioButton_epsilon);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Convertor ITR";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit_application);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox_CMD.ResumeLayout(false);
            this.groupBox_CMD_2.ResumeLayout(false);
            this.groupBox_CMD_2.PerformLayout();
            this.groupBox_CMD_1.ResumeLayout(false);
            this.groupBox_CMD_1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.CheckBox checkBox_MBTCP;
        public System.Windows.Forms.CheckBox checkBox_IEC;
        public System.Windows.Forms.CheckBox checkBoxR200;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.CheckBox checkBox_BROADCAST;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.CheckBox checkBox_PERSISTENT;
        private System.Windows.Forms.RichTextBox TextBox_apr;
        private System.Windows.Forms.RichTextBox TextBox_apllication;
        private System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.CheckBox checkBox_RETAIN;
        public System.Windows.Forms.CheckBox checkBox_MBS_RTU_1;
        public System.Windows.Forms.CheckBox checkBox_IO;
        private System.Windows.Forms.Button button3;
        public System.Windows.Forms.CheckBox checkBox_MBS_RTU_2;
        public System.Windows.Forms.CheckBox checkBox_IEC_EDC;
        public System.Windows.Forms.CheckBox checkBox_AutoTime;
        public System.Windows.Forms.CheckBox checkBox_VQT;
        private System.Windows.Forms.GroupBox groupBox_CMD;
        private System.Windows.Forms.TextBox textBox_CMD_1;
        public System.Windows.Forms.CheckBox checkBox_imit;
        public System.Windows.Forms.CheckBox checkBox_FB_field;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_version;
        private System.Windows.Forms.RichTextBox TextBox3;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RichTextBox textBox_TS_sum;
        private System.Windows.Forms.RichTextBox textBox_TS;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.RichTextBox textBox_TR_sum;
        private System.Windows.Forms.RichTextBox textBox_TR;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RichTextBox textBox_TI_sum;
        private System.Windows.Forms.RichTextBox textBox_TI;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RichTextBox textBox_TU_sum;
        private System.Windows.Forms.RichTextBox textBox_TU;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.TextBox textBox_CMD_2;
        private System.Windows.Forms.GroupBox groupBox_CMD_1;
        private System.Windows.Forms.GroupBox groupBox_CMD_2;
        private System.Windows.Forms.RadioButton radioButton_epsilon;
        private System.Windows.Forms.RadioButton radioButton_astra;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.CheckBox checkBox_ARDEV;
        public System.Windows.Forms.CheckBox checkBox_MB_OS;
    }
}

