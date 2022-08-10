using System;
using System.Threading;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Collections;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

//[assembly: AssemblyVersion("2021.11.9.5")]

namespace CITR
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = "Convertor ITR " + Assembly.GetExecutingAssembly().GetName().Version.ToString();

            // Создаем всплывающую подсказку и связываем ее с контейнером формы.
            ToolTip toolTip1 = new ToolTip();

            // Настройте задержки для всплывающей подсказки.
            toolTip1.AutoPopDelay = 7500;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Принудительно отображать текст всплывающей подсказки независимо от того, активна форма или нет
            toolTip1.ShowAlways = true;

            // Настройrf текстf всплывающей подсказки
            toolTip1.SetToolTip(this.checkBox_exel, "Если выбран, то содается Exel файл с глобальными переменными для импорта в среду ISaGRAF");
            toolTip1.SetToolTip(this.checkBox_txt, "Если выбран, то создается *.txt файлы с кодом на языке \"ST\" для среды ISaGRAF");
            toolTip1.SetToolTip(this.checkBox_textparting, "Если выбран, то *.txt файлы с кодом на языке \"ST\" для среды ISaGRAF будут иметь ограничения на количество строк. \nПЛК не может обработать более 3000 строк за цикл. ");
            toolTip1.SetToolTip(this.textBox_lines, "Количество строк для ограничения размера *.txt файлов с кодом на языке \"ST\" для среды ISaGRAF");
            toolTip1.SetToolTip(this.groupBox_lines, "Количество строк для ограничения размера *.txt файлов с кодом на языке \"ST\" для среды ISaGRAF");
        }
        private void Exit_application(object sender, FormClosingEventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            helloKey.SetValue("last_Form", "FALSE");
            helloKey.Close();
            Application.Exit();
        }
        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            if (helloKey.GetValue("groupBox2") != null)
                button_switch.Text = helloKey.GetValue("groupBox2").ToString();
            helloKey.Close();
        }
        private void Select_Form                (object sender, EventArgs e)
        {
            Program.frm1.Location = this.Location;
            Program.frm1.StartPosition = FormStartPosition.Manual;
            Program.frm1.Show();
            this.Hide();
        }      
        private void textBox_KeyDown            (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape)
            {
                this.ActiveControl = null;
                Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
                Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
                TextBox textbox = (TextBox)sender;
                helloKey.SetValue(textbox.Name, textbox.Text);
                helloKey.Close();
            }
        }
        private void checkBox_CheckStateChanged(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            CheckBox checkbox = (CheckBox)sender;
            helloKey.SetValue(checkbox.Name, checkbox.Checked.ToString());
            helloKey.Close();
        }
        private void checkBox_Layout(object sender, LayoutEventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            CheckBox checkbox = (CheckBox)sender;
            if (helloKey.GetValue(checkbox.Name) != null)
                checkbox.Checked = Convert.ToBoolean(helloKey.GetValue(checkbox.Name).ToString());
            helloKey.Close();
        }
        private void textBox_Layout(object sender, LayoutEventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            TextBox textbox = (TextBox)sender;
            if (helloKey.GetValue(textbox.Name) != null)
                textbox.Text = helloKey.GetValue(textbox.Name).ToString();
        }
        private void textBox_lines_KeyPress     (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        private void checkBox_textparting_Click (object sender, EventArgs e)
        {
            groupBox_lines.Enabled = checkBox_textparting.Checked;
        }
        private void checkBox_txt_Click(object sender, EventArgs e)
        {
            groupBox_lines.Enabled = checkBox_txt.Checked;
            checkBox_textparting.Enabled = checkBox_txt.Checked;
        }
        private void Button_Help_Click(Object sender, EventArgs e)
        {
            string filePath = Path.GetTempPath() + "help_vu.chm";
            var data = Properties.Resources.help_vu;
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    stream.Write(data, 0, data.Length);
                    stream.Flush();
                }
            }
            catch
            {

            }
            Help.ShowHelp(this, filePath);
        }

        XmlDocument  Application_IN     =   new XmlDocument();
        XmlDocument  Application_IN2    =   new XmlDocument();

        private ArrayList   Corrction_TXT(ArrayList txt_list)
        {
            ArrayList sFB_list = new ArrayList();
            ArrayList sFBModbus_list = new ArrayList();
            ArrayList IEC_870_list = new ArrayList();
            string buf_all;
            string[] ar_all;
            for (int i = 0; i < txt_list.Count; i++)
            {
                bool key = false;
                try
                {
                    if (!txt_list[i].ToString().Contains("_sFBModbus") && txt_list[i].ToString().Contains("_sFB"))
                    {
                        buf_all = txt_list[i + 1].ToString();
                        ar_all = buf_all.Split('\n');
                        buf_all = "";
                        for (int j = 0; j < ar_all.Length; j++)
                        {
                            if (ar_all[j].Contains("(* variables transitions *)")) key = true;
                            if (key)
                            {
                                sFB_list.Add(ar_all[j].Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                            }
                            else
                            {
                                buf_all = buf_all + ar_all[j];
                            }
                        }
                        for (int k = 0; k < sFB_list.Count; k++)
                        {
                            string[] var = new string[4];
                            if (sFB_list[k].ToString().Contains("(*"))
                            {
                                if (sFB_list[k + 1].ToString().Contains("FOR") && !sFB_list[k].ToString().Contains("END_FOR;"))
                                {
                                    var[0] = sFB_list[k + 1].ToString().Split(' ')[1].Replace("Index", "indexFB");
                                    var[1] = sFB_list[k + 1].ToString().Split(' ')[3];
                                    var[2] = sFB_list[k + 1].ToString().Split(' ')[5];
                                    var[3] = sFB_list[k + 2].ToString().Split(' ')[0].Replace("FB", "");
                                    buf_all = buf_all + "\r\n" + FB_FOR(var);
                                    k = k + 4;
                                }
                                else
                                {
                                    if (sFB_list[k + 1].ToString().Split(' ').Length > 1)
                                    {
                                        var[0] = sFB_list[k + 1].ToString().Split(' ')[0].Replace("FB", "");
                                        var[1] = sFB_list[k + 1].ToString().Split(' ')[3].Split('[')[1].Split(']')[0];
                                    }
                                    buf_all = buf_all + "\r\n" + FB_FOR(var);
                                    //k = k + 3;
                                }
                            }
                        }
                        txt_list[i + 1] = buf_all;
                        sFB_list.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка в секции FB (Corrction_TXT)", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_list = null;
                    break;
                }
                try
                {
                    if (txt_list[i].ToString().Contains("_sFBModbus"))
                    {
                        buf_all = txt_list[i + 1].ToString();
                        ar_all = buf_all.Split('\n');
                        buf_all = "";
                        for (int j = 0; j < ar_all.Length; j++)
                        {
                            if (ar_all[j].Contains("(* variables transitions *)")) key = true;
                            if (key)
                            {
                                sFBModbus_list.Add(ar_all[j].Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                            }
                            else
                            {
                                buf_all = buf_all + ar_all[j];
                            }
                        }
                        for (int k = 1; k < sFBModbus_list.Count; k++)
                        {
                            string[] var = new string[6];
                            if (sFBModbus_list[k].ToString().Contains("(*"))
                            {
                                buf_all = buf_all + "\r" + sFBModbus_list[k].ToString() + "\r";
                                if (sFBModbus_list[k + 1].ToString().Contains("FOR"))
                                {
                                    if (sFBModbus_list[k + 3].ToString().Contains("END_FOR;"))
                                    {
                                        var[0] = sFBModbus_list[k + 1].ToString().Split(' ')[1].Replace("Index", "indexFBModbus");
                                        var[1] = sFBModbus_list[k + 1].ToString().Split(' ')[3];
                                        var[2] = sFBModbus_list[k + 1].ToString().Split(' ')[5];
                                        var[3] = sFBModbus_list[k + 2].ToString().Split(' ')[0].Replace("FB", "");
                                        var[4] = sFBModbus_list[k + 2].ToString().Split(' ')[3].Replace("Index", "indexFBModbus");
                                        buf_all = buf_all + "\r\n" + FBModbus_FOR(var);
                                        k = k + 4;
                                    }
                                    else
                                    {
                                        var[0] = sFBModbus_list[k + 1].ToString().Split(' ')[1].Replace("Index", "indexFBModbus");
                                        var[1] = sFBModbus_list[k + 1].ToString().Split(' ')[3];
                                        var[2] = sFBModbus_list[k + 1].ToString().Split(' ')[5];
                                        var[3] = sFBModbus_list[k + 2].ToString().Split(' ')[0].Replace("FB", "");
                                        var[4] = sFBModbus_list[k + 2].ToString().Split(' ')[3].Replace("Index", "indexFBModbus");
                                        var[5] = sFBModbus_list[k + 3].ToString().Split(' ')[2].Replace("Index", "indexFBModbus");
                                        buf_all = buf_all + "\r\n" + FBModbus_FOR(var);
                                        k = k + 4;
                                    }
                                }
                                else
                                {
                                    if (sFBModbus_list[k + 1].ToString() != "")
                                    {
                                        if (sFBModbus_list[k + 2].ToString() != "")
                                        {
                                            var[0] = sFBModbus_list[k + 1].ToString().Split(' ')[0].Replace("FB", "");
                                            var[1] = sFBModbus_list[k + 1].ToString().Split(' ')[3].Replace(")", "").Replace(";", "") + sFBModbus_list[k + 2].ToString().Split(' ')[sFBModbus_list[k + 2].ToString().Split(' ').Length -1].Replace(")", "").Replace(";", "");
                                        }
                                        else
                                        {
                                            var[0] = sFBModbus_list[k + 1].ToString().Split(' ')[0].Replace("FB", "");
                                            var[1] = sFBModbus_list[k + 1].ToString().Split(' ')[3].Replace(")", "").Replace(";", "");
                                        }                                     
                                    }
                                    buf_all = buf_all + "\r\n" + FBModbus_FOR(var);
                                    //k = k + 1;
                                }
                            }
                        }
                        txt_list[i + 1] = buf_all;
                        sFBModbus_list.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка в секции FBModbus (Corrction_TXT)", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_list = null;
                    break;
                }
                try
                {
                    if (txt_list[i].ToString().Contains("_IEC_870_"))
                    {
                        buf_all = txt_list[i + 1].ToString();
                        ar_all = buf_all.Split('\n');
                        buf_all = "";
                        for (int j = 0; j < ar_all.Length; j++)
                        {
                            IEC_870_list.Add(ar_all[j].Replace("\r", "").Replace("\n", "").Replace("\t", ""));
                        }
                        for (int jm = 0; jm < 16; jm++)
                        {
                            IEC_870_list.Add(""); // Добавляем пустые для работы алгоритма
                        }
                        for (int k = 1; k < IEC_870_list.Count - 1; k++)
                        {                                                    
                            if (IEC_870_list[k + 1].ToString().Contains("IF indexIEC < 512 THEN"))
                            {
                                int N_strings = 1;
                                for (int km = k + 2; km < IEC_870_list.Count - 1; km++)
                                {
                                    if (IEC_870_list[km].ToString().Contains("END_IF;"))
                                    {
                                        //N_strings++;
                                        break;
                                    }                                        
                                    else
                                        N_strings++;
                                }
                                string[] var = new string[N_strings];
                                var[0] = IEC_870_list[k].ToString().Split(' ')[2].Replace(";", "");                            
                                for (int km = 1; km < N_strings; km++)
                                {
                                    var[km] = IEC_870_list[k + 1 + km].ToString();
                                }

                                k = k + N_strings+1;
                                buf_all = buf_all + IEC_IF(var) + "\r\n";
                            }
                            else /*if (IEC_870_list[k + 1].ToString() != "")*/
                            {
                                buf_all = buf_all + IEC_870_list[k].ToString() + "\r\n";
                               // buf_all = buf_all + " ";
                            }
                        }
                        txt_list[i + 1] = buf_all;
                        IEC_870_list.Clear();
                    }
                }
                catch
                {
                    MessageBox.Show("Ошибка в секции IEC_870 (Corrction_TXT)", "Отмена операции", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_list = null;
                    break;
                }
            }
            return txt_list;
        }
        private string      FB_FOR(string[] var)
        {
            string new_str = "";
            if (var[3] != null)
            {
                new_str = "\r\n" + var[0] + " := " + var[1] + ";\r\n";
                new_str = new_str + "WHILE " + var[0] + " <= " + var[2] + " DO\r\n";
                new_str = new_str + "\ttmpBool := " + var[3] + "(" + var[0] + ");\r\n\t";
                new_str = new_str + var[0] + " := " + var[0] + " + 1;\r\n";
                new_str = new_str + "END_WHILE;\r";
            }
            if (var[3] == null & var[1] != null)
            {
                new_str = "\r\ntmpBool" + " := " + var[0] + " (" + var[1] + ");\r\n";
            }
            return new_str;
        }                                       // Варианты FB_FOR
        private string      FBModbus_FOR(string[] var)
        {
            string new_str = "";
            if (var[2] == null)
            {
                new_str = "\r\ntmpBool" + " := " + var[0] + " (" + var[1] + ");\r\n";
            }
            if (var[5] == null && var[4] != null)
            {
                new_str = "\r\n" + var[0] + " := " + var[1] + ";\r\n";
                new_str = new_str + "WHILE " + var[0] + " <= " + var[2] + " DO\r\n";
                new_str = new_str + "\ttmpBool := " + var[3] + "(" + var[4] + "\r\n\t";
                new_str = new_str + var[0] + " := " + var[0] + " + 1;\r\n";
                new_str = new_str + "END_WHILE;\r\n";
            }
            if (var[5] != null)
            {
                new_str = "\r\n" + var[0] + " := " + var[1] + ";\r\n";
                new_str = new_str + "WHILE " + var[0] + " <= " + var[2] + " DO\r\n";
                new_str = new_str + "\ttmpBool := " + var[3] + "(" + var[4] + var[5] + "\r\n\t";
                new_str = new_str + var[0] + " := " + var[0] + " + 1;\r\n";
                new_str = new_str + "END_WHILE;\r\n";
            }
            return new_str;
        }                                 // Варианты FBModbus_FOR
        private string      IEC_IF(string[] var)
        {
            string new_str = "";
            if (var[0] != null)
            {
                int indexIEC = Convert.ToInt32(var[0]);
                int buf_indexIEC;
                for (int index_var = var.Length - 1; index_var > 0; index_var--)
                {
                    if (indexIEC >= 2560)
                    {
                        buf_indexIEC = indexIEC - 2560;
                        if (var[index_var].Contains("indexIEC - 2560"))
                            new_str = new_str + var[index_var].Replace("indexIEC - 2560", buf_indexIEC.ToString()) + "\r\n";
                    }
                    else if(indexIEC >= 2048)
                    {
                        buf_indexIEC = indexIEC - 2048;
                        if (var[index_var].Contains("indexIEC - 2048"))
                            new_str = new_str + var[index_var].Replace("indexIEC - 2048", buf_indexIEC.ToString()) + "\r\n";
                    }
                    else if (indexIEC >= 1536)
                    {
                        buf_indexIEC = indexIEC - 1536;
                        if (var[index_var].Contains("indexIEC - 1536"))
                            new_str = new_str + var[index_var].Replace("indexIEC - 1536", buf_indexIEC.ToString()) + "\r\n";
                    }
                    else if (indexIEC >= 1024)
                    {
                        buf_indexIEC = indexIEC - 1024;
                        if (var[index_var].Contains("indexIEC - 1024"))
                            new_str = new_str + var[index_var].Replace("indexIEC - 1024", buf_indexIEC.ToString()) + "\r\n";
                    }
                    else if (indexIEC >= 512)
                    {
                        buf_indexIEC = indexIEC - 512;
                        if (var[index_var].Contains("indexIEC - 512"))
                            new_str = new_str + var[index_var].Replace("indexIEC - 512", buf_indexIEC.ToString()) + "\r\n";
                    }
                    else
                        if (!var[index_var].Contains("indexIEC - ") && var[index_var].Contains("indexIEC") && !var[index_var].Contains("ELSIF"))
                            new_str = new_str + var[index_var].Replace("indexIEC", indexIEC.ToString()) + "\r\n";
                }
            }
            return new_str;
        }                                       // Варианты FB_FOR  
        //private void        Corrction_TXT2(string path, int MAX_LINES)
        //{
        //    var reader = File.OpenText(path);          
        //    int outFileNumber = 1;
        //    int idx;
        //    string buf ="";
        //    while (!reader.EndOfStream)
        //    { 
        //        var writer = File.CreateText(path.Replace("Program", "Program" + outFileNumber++.ToString()));
        //        for (idx = 0; idx < MAX_LINES; idx++)
        //        {
        //            buf = reader.ReadLine();
        //            writer.WriteLine(buf);
        //            if (reader.EndOfStream || buf.Contains("(* end_section *)")) break;
        //        }
        //        if (!buf.Contains("(* end_section *)"))
        //        {
        //            do
        //            {
        //                buf = reader.ReadLine();
        //                writer.WriteLine(buf);
        //                if (reader.EndOfStream) break;
        //            }
        //            while (!reader.ReadLine().Contains("END_IF;"));
        //        }             
        //        //if (buf.Contains("(* end_section *)")) break;
        //        if (idx >= MAX_LINES)
        //            writer.WriteLine("END_IF;");
        //        writer.Close();
        //    }
        //    reader.Close();
        //}
        private void        Create_TXT()
        {
            if (checkBox_txt.Checked)
            {
                string path = DataTransport.data_puth;
                string name_USO = DataTransport.name;
                ArrayList TXT_list = new ArrayList();
                name_USO = name_USO.Split('_')[0];
                string new_path = path + "\\" + name_USO;
                string name_FBModbus = new_path + "_FB ModBus.txt";
                string name_FB = new_path + "_FB.txt";
                string path_IEC = new_path + "_IEC Program.txt";
                bool key_sFBModbus = false, key_sFB = false, key_IEC = false;
                if (Application_IN.FirstChild != null)
                {
                    XmlNodeList proverka0 = Application_IN.GetElementsByTagName("pous");
                    if (proverka0 != null)
                    {
                        foreach (XmlElement proverka1 in proverka0)
                        {
                            foreach (XmlElement proverka2 in proverka1)
                            {
                                if (proverka2.GetAttribute("pouType") == "program")
                                {
                                    TXT_list.Add("(*" + proverka2.GetAttribute("name") + "*)\r\r");
                                    if (proverka2.FirstChild.NextSibling.FirstChild.FirstChild != null)
                                    {
                                        if (proverka2.FirstChild.NextSibling.FirstChild != null)
                                        {
                                            if (proverka2.FirstChild.NextSibling.FirstChild.LocalName == "ST")
                                            {
                                                TXT_list.Add(proverka2.FirstChild.NextSibling.FirstChild.FirstChild.InnerText);
                                                TXT_list.Add("\r\r(* end_section *)\r\n");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (TXT_list != null)
                {
                    int N = 1;
                    TXT_list = Corrction_TXT(TXT_list);
                    // открываем файл (стираем содержимое файла)
                    string new_path_IEC = path_IEC.Replace("Program", "Program1");
                    string old_path_IEC = new_path_IEC;
                    FileStream file_FB = File.Open(name_FB, FileMode.Create);
                    FileStream file_FBModbus = File.Open(name_FBModbus, FileMode.Create);
                    FileStream file_IEC = File.Open(new_path_IEC, FileMode.Create);
                    // получаем поток
                    StreamWriter output_FB = new StreamWriter(file_FB);
                    StreamWriter output_FBModbus = new StreamWriter(file_FBModbus);
                    StreamWriter output_IEC = new StreamWriter(file_IEC);
                    // записываем текст в поток                  
                    if (TXT_list != null)
                    for (int i = 0; i < TXT_list.Count; i++)
                    {
                            string buf = TXT_list[i].ToString();
                            string[] arr_buf = buf.Split('\n');
                            if (TXT_list[i].ToString().Contains("_sFBModbus")) key_sFBModbus = true;
                            if (TXT_list[i].ToString().Contains("_sFB") && !TXT_list[i].ToString().Contains("_sFBModbus")) key_sFB = true;
                            if (TXT_list[i].ToString().Contains("_IEC_870_")) key_IEC = true;
                            if (key_sFB)
                            {
                                for (int j = 0; j < arr_buf.Length; j++)
                                {
                                    if (arr_buf[j] != "\r" && arr_buf[j] != "\t\r")
                                        output_FB.Write(arr_buf[j]);
                                    if (arr_buf[j].Contains("end_section"))
                                    {
                                        key_sFB = false;
                                    }
                                }
                            }
                            if (key_sFBModbus)
                            {
                                for (int j = 0; j < arr_buf.Length; j++)
                                {
                                    if (arr_buf[j] != "\r" && arr_buf[j] != "\t\r")
                                        output_FBModbus.Write(arr_buf[j]);
                                    if (arr_buf[j].Contains("end_section"))
                                    {
                                        key_sFBModbus = false;
                                    }
                                }
                            }
                            if (key_IEC)
                            {                              
                                int b = 0;
                                bool end_if = false;
                                for (int j = 0;  j < arr_buf.Length; j++)
                                {
                                    if (arr_buf[j].Contains("IF"))
                                    {
                                        end_if = false;
                                        if (arr_buf[j].Contains("END_IF"))
                                            end_if = true;
                                    }
                                    int max_lines = Convert.ToInt32(textBox_lines.Text);
                                    if (b > max_lines && checkBox_textparting.Checked && end_if)
                                    {
                                        string probf = arr_buf[j];
                                        b = 0;
                                        N++;
                                        new_path_IEC = path_IEC.Replace("Program", "Program" + N.ToString());
                                        output_IEC.Close();
                                        file_IEC = File.Open(new_path_IEC, FileMode.Create);
                                        output_IEC = new StreamWriter(file_IEC);
                                        output_IEC.Write(arr_buf[j]);
                                    }
                                    else if (arr_buf[j] != "\r" && arr_buf[j] != "\t\r")
                                    {
                                        b++;
                                        output_IEC.Write(arr_buf[j]);
                                    }
                                    else if (b > max_lines && checkBox_textparting.Checked && !end_if)
                                    {
                                        b++;
                                        output_IEC.Write(arr_buf[j]);
                                    }
                                    if (arr_buf[j].Contains("end_section"))
                                    {                                      
                                        key_IEC = false;
                                        N++;
                                        new_path_IEC = path_IEC.Replace("Program", "Program" + N.ToString());
                                        output_IEC.Close();
                                        file_IEC = File.Open(new_path_IEC, FileMode.Create);
                                        output_IEC = new StreamWriter(file_IEC);
                                    }
                                }
                            }
                    }
                    // закрываем поток
                    output_FB.Close();
                    output_IEC.Close();
                    output_FBModbus.Close();
                    if (File.Exists(name_FB) && TXT_list == null)
                    {
                        File.Delete(name_FB);
                    }
                    if (File.Exists(name_FBModbus) && TXT_list == null)
                    {
                        File.Delete(name_FBModbus);
                    }
                    if (File.Exists(old_path_IEC) && TXT_list == null)
                    {
                        File.Delete(old_path_IEC);
                    }
                    else if (File.Exists(new_path_IEC))
                    {
                        File.Delete(new_path_IEC);
                    }

                }
            }                    
        }

        private void        Create_Excel()
        {
            if (DataTransport.data_puth != "" && checkBox_exel.Checked)
            {
                Application_IN2.Load(DataTransport.Application);
                string name = DataTransport.name;
                string path = DataTransport.data_puth;
                string tempPath = Path.GetTempFileName();
                File.WriteAllBytes(tempPath, Properties.Resources.exel_SHB);
                Excel.Application xlApp = new Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!!");
                    return;
                }
                name = name.Split('_')[0] + ".xls";
                path = path + "\\" + name;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkBook = xlApp.Workbooks.Open(tempPath);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int N_variable = 1;
                if (Application_IN2.FirstChild != null)
                {
                    XmlNodeList proverka1 = Application_IN2.GetElementsByTagName("globalVars");
                    if (proverka1 != null)
                    {
                        foreach (XmlElement proverka2 in proverka1)
                        {
                            if (proverka2.GetAttribute("name") == "global_vars" || proverka2.GetAttribute("name") == "const_vars")
                            {
                                foreach (XmlElement proverka3 in proverka2)
                                {
                                    xlWorkSheet.Cells[N_variable + 2, 1] = proverka3.GetAttribute("name");
                                    if (proverka3.FirstChild.FirstChild != null)
                                    {
                                        if (proverka3.FirstChild.FirstChild.LocalName == "array")
                                        {
                                            XmlElement dimension = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild;
                                            XmlElement struct_name = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild.NextSibling.FirstChild;
                                            string str_struct_name = struct_name.GetAttribute("name");
                                            xlWorkSheet.Cells[N_variable + 2, 2] = struct_name.GetAttribute("name");
                                            if (str_struct_name == "")
                                                xlWorkSheet.Cells[N_variable + 2, 2] = struct_name.LocalName;
                                            xlWorkSheet.Cells[N_variable + 2, 3] = "[" + dimension.GetAttribute("lower") + ".." + dimension.GetAttribute("upper") + "]";
                                        }
                                        else
                                        {
                                            XmlElement simpleValue2 = (XmlElement)proverka3.FirstChild.FirstChild;
                                            if (proverka3.FirstChild.FirstChild.LocalName != "derived")
                                            {
                                                xlWorkSheet.Cells[N_variable + 2, 2] = proverka3.FirstChild.FirstChild.LocalName;
                                            }
                                            else
                                            {
                                                xlWorkSheet.Cells[N_variable + 2, 2] = simpleValue2.GetAttribute("name");
                                            }
                                            if (proverka3.FirstChild.FirstChild.LocalName != "Bool")
                                            {
                                                foreach (XmlElement proverka4 in proverka3)
                                                {
                                                    if (proverka4.LocalName == "initialValue")
                                                    {
                                                        XmlElement simpleValue = (XmlElement)proverka4.FirstChild;
                                                        xlWorkSheet.Cells[N_variable + 2, 5] = simpleValue.GetAttribute("value");
                                                    }
                                                }
                                            }
                                        }////////////////Тут есть вопросы
                                    }////////////////Тут есть вопросы
                                    xlWorkSheet.Cells[N_variable + 2, 6] = "Var";
                                    xlWorkSheet.Cells[N_variable + 2, 7] = "ReadWrite";
                                    xlWorkSheet.Cells[N_variable + 2, 12] = "False ";
                                    N_variable++;
                                }
                            }
                        }
                    }
                }
                try
                {
                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlOpenXMLWorkbook, misValue,
                    misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();
                }
                catch
                {
                    MessageBox.Show("Отмена операции пользователем", "Ошибка создания Excel файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }       
        }
        
        private void        Thread_Progressbar(object p)
        {
            this.Invoke(new MethodInvoker(() => progressBar1.Visible = true));
            IProgress<int> progress = p as IProgress<int>;
            //int k = 0;
            int i = 0;
            //int T = k * Convert.ToInt32(APR_Corrected.GetElementsByTagName("Parameter").Count / 100);
            //if (checkBox_IEC.Checked) k++;
            //if (checkBox_IEC_EDC.Checked) k++;
            while (i <= 100)
            {
                progress.Report(i++);
                Thread.Sleep(30); // имитация бурной деятельности
            }
        }                               // Поток для Progressbar

        async void          Main_Soft(object sender, EventArgs e)
        {
            groupBox_soft_setting.Enabled = false;
            button_switch.Enabled = false;          
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите ЭЛСИ-ТМК_Application.xml";
            DialogResult dialogResult = MessageBox.Show("Выберите ЭЛСИ-ТМК_Application.xml,\nкоторые формируется из ACS кнопкой \"Экспорт ПО\"", "Создание ПО", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
            if (dialogResult == DialogResult.OK)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    DataTransport.Application = openFileDialog1.FileName;
                    Application_IN.Load(DataTransport.Application);
                    DataTransport.name = openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length - 1];
                    TextBox_Application.BackColor = Color.Green;
                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string path = folderBrowserDialog1.SelectedPath;
                        DataTransport.data_puth = path;

                        IProgress<int> progress1 = new Progress<int>((p) => progressBar1.Value = p);
                        Thread thread_Progressbar = new Thread(Thread_Progressbar);
                        thread_Progressbar.Start(progress1);

                        var task1 = Task.Run(Create_Excel);
                        var task2 = Task.Run(Create_TXT);
                        await Task.WhenAll(task1, task2);
                        MessageBox.Show("Генерация завершена", "Отчет о готовности ПО", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }              
            {
                if (Application_IN != null) Application_IN.RemoveAll();
                TextBox_Application.BackColor = Color.FromArgb(255, 200, 200, 200);
                groupBox_soft_setting.Enabled = true;
                button_switch.Enabled = true;
                progressBar1.Visible = false;
            }
        }

        
    }
}
