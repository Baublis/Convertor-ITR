using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.Reflection;

namespace CITR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //private readonly System.Diagnostics.Stopwatch uptime = new System.Diagnostics.Stopwatch();
        private void Form1_Load                 (object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            if (helloKey.GetValue(groupBox2.Name) != null)
                groupBox2.Text = helloKey.GetValue(groupBox2.Name).ToString();
            if (helloKey.GetValue(radioButton_epsilon.Name) != null)
                radioButton_epsilon.Checked = Convert.ToBoolean(helloKey.GetValue(radioButton_epsilon.Name).ToString());
            if (helloKey.GetValue(radioButton_astra.Name) != null)
                radioButton_astra.Checked = Convert.ToBoolean(helloKey.GetValue(radioButton_astra.Name).ToString());
            helloKey.Close();

            this.Text = "Convertor ITR " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            checkBox_MBS_RTU_2.Enabled = checkBox_MBS_RTU_1.Checked;
            checkBox_ARDEV.Enabled = checkBox_MBTCP.Checked;

            // Создаем всплывающую подсказку и связываем ее с контейнером формы.
            ToolTip toolTip1 = new ToolTip();

            // Настройте задержки для всплывающей подсказки.
            toolTip1.AutoPopDelay = 7500;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Принудительно отображать текст всплывающей подсказки независимо от того, активна форма или нет
            toolTip1.ShowAlways = true;

            // Настройка текста всплывающей подсказки
            toolTip1.SetToolTip(this.checkBoxR200, "Если выбран, то REGUL R200 целевой ПЛК, иначе REGUL R500");
            toolTip1.SetToolTip(this.checkBox_IEC, "Нужно выбрать для генерации станционного МЭК 104 Slave. В результате получем две XML (данные и комнады) для импорта");
            toolTip1.SetToolTip(this.checkBox_IEC_EDC, "Нужно выбрать для генерации диспетчерского МЭК 104 Slave. В результате получем две XML (данные и комнады) для импорта");
            toolTip1.SetToolTip(this.checkBox_VQT, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.checkBox_MBTCP, "Нужно выбрать для генерации ModBus TCP Slave. В результаете получем GVL и XML для импорта");
            toolTip1.SetToolTip(this.checkBox_AutoTime, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.textBox_CMD_1, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.textBox_CMD_2, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.groupBox_CMD_1, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.groupBox_CMD_2, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.groupBox_CMD, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.checkBox_BROADCAST, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.checkBox_PERSISTENT, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.checkBox_RETAIN, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.checkBox_imit, "Знает только Золотарев для чего это");
            toolTip1.SetToolTip(this.checkBox_FB_field, "Знает только Золотарев для чего это");

        }
        private void Exit_application(object sender, FormClosingEventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            helloKey.SetValue("last_Form", "TRUE");
            helloKey.Close();
            Application.Exit();
        }
        private void select_Epsilon             (object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            helloKey.SetValue("groupBox2", "Epsilon LD");
            groupBox2.Text = "Epsilon LD";
            helloKey.Close();
            groupBox_CMD.Text = "Время блокировки команды, с";
            textBox_CMD_1.Text = (Convert.ToInt32(textBox_CMD_1.Text) / 1000).ToString();
            textBox_CMD_2.Text = (Convert.ToInt32(textBox_CMD_2.Text) / 1000).ToString();
        }
        private void select_Astra               (object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            helloKey.SetValue("groupBox2", "Astra IDE");
            groupBox2.Text = "Astra IDE";
            helloKey.Close();
            groupBox_CMD.Text = "Время блокировки команды, мс";
            textBox_CMD_1.Text = (Convert.ToInt32(textBox_CMD_1.Text) * 1000).ToString();
            textBox_CMD_2.Text = (Convert.ToInt32(textBox_CMD_2.Text) * 1000).ToString();
        }
        private void selection_Form             (object sender, EventArgs e)
        {
            Program.frm2.Location = this.Location;
            Program.frm2.StartPosition = FormStartPosition.Manual;
            Program.frm2.Show();
            this.Hide();
        }
        private void checbox_MBS_RTU_Click      (object sender, EventArgs e)
        {
            checkBox_MBS_RTU_2.Checked = checkBox_MBS_RTU_1.Checked;
            checkBox_MBS_RTU_2.Enabled = checkBox_MBS_RTU_1.Checked;
            checkBox_MB_OS.Enabled = checkBox_MBS_RTU_1.Checked;
        }
        private void checkBox_MBTCP_Click       (object sender, EventArgs e)
        {
            checkBox_ARDEV.Enabled = checkBox_MBTCP.Checked;
        }
        private void textBox_CMD_KeyPress       (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57))
                e.Handled = true;
        }
        private void textBox_version_KeyPress   (object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 8 && (e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != '.')
                e.Handled = true;
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
        private void checkBox_CheckStateChanged (object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            CheckBox checkbox = (CheckBox)sender;
            helloKey.SetValue(checkbox.Name, checkbox.Checked.ToString());
            helloKey.Close();
        }
        private void checkBox_Layout            (object sender, LayoutEventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            CheckBox checkbox = (CheckBox)sender;
            if (helloKey.GetValue(checkbox.Name) != null)
                checkbox.Checked = Convert.ToBoolean(helloKey.GetValue(checkbox.Name).ToString());
            helloKey.Close();
        }
        private void textBox_Layout             (object sender, LayoutEventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            TextBox textbox = (TextBox)sender;
            if (helloKey.GetValue(textbox.Name) != null)
                textbox.Text = helloKey.GetValue(textbox.Name).ToString();
            helloKey.Close();
        }
        private void radio_CheckStateChanged    (object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey currentUserKey = Microsoft.Win32.Registry.CurrentUser;
            Microsoft.Win32.RegistryKey helloKey = currentUserKey.CreateSubKey("CITR");
            RadioButton radiobutton = (RadioButton)sender;
            helloKey.SetValue(radiobutton.Name, radiobutton.Checked.ToString());
            helloKey.Close();
        }
        //private void timer1_Tick                (object sender, EventArgs e)
        //{
        //    TimeSpan ts = uptime.Elapsed;
        //    label1.Text = ts.Minutes.ToString() + ":" + ts.Seconds.ToString()  + ":" + ts.Milliseconds.ToString();
        //}
        private void Button_Help_Click          (Object sender, EventArgs e)
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
            //Process.Start(filePath);
        }

        XmlDocument GVL                 =       new XmlDocument();
        XmlDocument XML                 =       new XmlDocument();
        XmlDocument Application_IN      =       new XmlDocument();
        XmlDocument APR                 =       new XmlDocument();
        XmlDocument APR_Corrected       =       new XmlDocument();
        XmlDocument REGUL_ModBus_TCP    =       new XmlDocument();
        XmlDocument REGUL_IEC_DATA      =       new XmlDocument();
        XmlDocument REGUL_IEC_CMD       =       new XmlDocument();
        ArrayList   trig_list           =       new ArrayList();
        string      path;
        string      short_name_application;
        string      short_name_apr;

        int          size_var (ArrayList list)
        {
            int size = 0;
            string buf;
            foreach (object str in list)
            {
                buf = str.ToString().Split(';')[2];
                if (buf == "DINT" || buf == "DWORD" || buf == "UDINT" || buf == "REAL")
                    size += 2;
                else
                    size += 1;
            }
            return size;
        }
        private void GVL_Bilding_Epsilon(string name, string dscr, int ID, ArrayList list, bool ligt_MBS)
        {
            XmlNode GVL_node_1, GVL_node_2, GVL_node_3, GVL_node_4, GVL_node_5, GVL_node_6, GVL_node_7, GVL_node_7_1, GVL_node_8, GVL_node_9;
            XmlNode GVL_node_0, Application_node_1, Application_node_2, Application_node_3, Application_node_4;

            string sID;
            int k = ID % 10;
            sID = k.ToString();
            ID /= 10;
            k = ID % 10;
            sID = k.ToString() + sID;
            ID /= 10;
            k = ID % 10;
            sID = k.ToString() + sID;
            sID = "aee2fe06-f677-434c-8c3d-69670ehui" + sID;

            GVL_node_0 = GVL.CreateElement("data");
            GVL_node_0.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_0.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/globalvars";
            GVL_node_0.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_0.Attributes["handleUnknown"].Value = "implementation";
            GVL_node_1 = GVL.CreateElement("globalVars");
            GVL_node_1.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_1.Attributes["name"].Value = name;
            ///////////////////////////////////////////////////////////////////////////
            if (ligt_MBS)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    GVL_node_1.AppendChild(Var_Bilding_MBS(list[i].ToString()));
                }             
                //var_string: name(string);array(bool);lower_ar(word);upper_ar(word);type_ar(string);
                string var_string = "Slave_Dev;true;0;"+ size_var(list).ToString() + ";WORD;";
                GVL_node_1.PrependChild(Var_Bilding(var_string));
            }
            else
                for (int i = 0; i < list.Count; i++)
                {
                    GVL_node_1.AppendChild(Var_Bilding(list[i].ToString()));
                }
            ///////////////////////////////////////////////////////////////////////////
            GVL_node_3 = GVL.CreateElement("xhtml");
            GVL_node_3.Attributes.Append(GVL.CreateAttribute("xmlns"));
            GVL_node_3.Attributes["xmlns"].Value = "http://www.w3.org/1999/xhtml";
            GVL_node_3.InnerText = dscr;
            GVL_node_2 = GVL.CreateElement("documentation");
            GVL_node_2.AppendChild(GVL_node_3);
            GVL_node_1.AppendChild(GVL_node_2);
            GVL_node_9 = GVL.CreateElement("ObjectId");
            GVL_node_9.InnerText = sID;
            GVL_node_8 = GVL.CreateElement("data");
            GVL_node_8.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_8.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/objectid";
            GVL_node_8.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_8.Attributes["handleUnknown"].Value = "discard";
            GVL_node_8.AppendChild(GVL_node_9);
            GVL_node_7 = GVL.CreateElement("Attribute");
            GVL_node_7.Attributes.Append(GVL.CreateAttribute("Name"));
            GVL_node_7.Attributes["Name"].Value = "subsequent";
            GVL_node_7.Attributes.Append(GVL.CreateAttribute("Value"));
            GVL_node_7.Attributes["Value"].Value = "";
            GVL_node_6 = GVL.CreateElement("Attributes");
            GVL_node_6.AppendChild(GVL_node_7);
            if (ligt_MBS)
            {
                GVL_node_7_1 = GVL.CreateElement("Attribute");
                GVL_node_7_1.Attributes.Append(GVL.CreateAttribute("Name"));
                GVL_node_7_1.Attributes["Name"].Value = "pack_mode";
                GVL_node_7_1.Attributes.Append(GVL.CreateAttribute("Value"));
                GVL_node_7_1.Attributes["Value"].Value = "1";
                GVL_node_6.AppendChild(GVL_node_7_1);
            }                  
            GVL_node_5 = GVL.CreateElement("data");
            GVL_node_5.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_5.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/attributes";
            GVL_node_5.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_5.Attributes["handleUnknown"].Value = "implementation";
            GVL_node_5.AppendChild(GVL_node_6);
            GVL_node_4 = GVL.CreateElement("addData");
            GVL_node_4.AppendChild(GVL_node_5);
            GVL_node_4.AppendChild(GVL_node_8);
            GVL_node_1.AppendChild(GVL_node_4);
            GVL_node_0.AppendChild(GVL_node_1);
            Application_node_4 = Application_IN.CreateElement("Object");
            Application_node_4.Attributes.Append(Application_IN.CreateAttribute("Name"));
            Application_node_4.Attributes["Name"].Value = name;
            Application_node_4.Attributes.Append(Application_IN.CreateAttribute("ObjectId"));
            Application_node_4.Attributes["ObjectId"].Value = sID;
            Application_node_3 = Application_IN.CreateElement("ProjectStructure");
            Application_node_3.AppendChild(Application_node_4);
            Application_node_2 = Application_IN.CreateElement("data");
            Application_node_2.Attributes.Append(Application_IN.CreateAttribute("name"));
            Application_node_2.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/projectstructure";
            Application_node_2.Attributes.Append(Application_IN.CreateAttribute("handleUnknown"));
            Application_node_2.Attributes["handleUnknown"].Value = "discard";
            Application_node_2.AppendChild(Application_node_3);
            Application_node_1 = Application_IN.ImportNode(GVL_node_0, true);
            Application_node_2.AppendChild(Application_node_3);
            Application_IN.DocumentElement.LastChild.AppendChild(Application_node_1);
            Application_IN.DocumentElement.LastChild.AppendChild(Application_node_2);
        }         // Конструктор GVL для Application_XML (Epsilon LD)
        private void GVL_Bilding_Astra(string name, string dscr, int ID, ArrayList list, bool ligt_MBS)
        {
            XmlNode GVL_node_1, GVL_node_2, GVL_node_3, GVL_node_4, GVL_node_5, GVL_node_6, GVL_node_7, GVL_node_8, GVL_node_9;
            XmlNode GVL_node_0, Application_node_1, Application_node_2, Application_node_3, Application_node_4, GVL_node_7_1, GVL_node_7_2;

            string sID;
            int k = ID % 10;
            sID = k.ToString();
            ID /= 10;
            k = ID % 10;
            sID = k.ToString() + sID;
            ID /= 10;
            k = ID % 10;
            sID = k.ToString() + sID;
            sID = "aee2fe06-f677-434c-8c3d-69670ehui" + sID;

            GVL_node_0 = GVL.CreateElement("data");
            GVL_node_0.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_0.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/globalvars";
            GVL_node_0.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_0.Attributes["handleUnknown"].Value = "implementation";
            GVL_node_1 = GVL.CreateElement("globalVars");
            GVL_node_1.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_1.Attributes["name"].Value = name;
            ///////////////////////////////////////////////////////////////////////////
            if (ligt_MBS)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    GVL_node_1.AppendChild(Var_Bilding_MBS(list[i].ToString()));

                }
                //var_string: name(string);array(bool);lower_ar(word);upper_ar(word);type_ar(string);
                string var_string = "Slave_Dev;true;0;" + size_var(list).ToString() + ";WORD;";
                GVL_node_1.PrependChild(Var_Bilding(var_string));
            }
            else
                for (int i = 0; i < list.Count; i++)
                {
                    GVL_node_1.AppendChild(Var_Bilding(list[i].ToString()));
                }
            ///////////////////////////////////////////////////////////////////////////
            GVL_node_3 = GVL.CreateElement("xhtml");
            GVL_node_3.Attributes.Append(GVL.CreateAttribute("xmlns"));
            GVL_node_3.Attributes["xmlns"].Value = "http://www.w3.org/1999/xhtml";
            GVL_node_3.InnerText = dscr;
            GVL_node_2 = GVL.CreateElement("documentation");
            GVL_node_2.AppendChild(GVL_node_3);
            GVL_node_1.AppendChild(GVL_node_2);
            GVL_node_9 = GVL.CreateElement("ObjectId");
            GVL_node_9.InnerText = sID;
            GVL_node_8 = GVL.CreateElement("data");
            GVL_node_8.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_8.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/objectid";
            GVL_node_8.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_8.Attributes["handleUnknown"].Value = "discard";
            GVL_node_8.AppendChild(GVL_node_9);
            GVL_node_7 = GVL.CreateElement("Attribute");
            GVL_node_7.Attributes.Append(GVL.CreateAttribute("Name"));
            GVL_node_7.Attributes["Name"].Value = "subsequent";
            GVL_node_7.Attributes.Append(GVL.CreateAttribute("Value"));
            GVL_node_7.Attributes["Value"].Value = "";
            GVL_node_7_1 = GVL.CreateElement("Attribute");
            GVL_node_7_1.Attributes.Append(GVL.CreateAttribute("Name"));
            GVL_node_7_1.Attributes["Name"].Value = "ps.add_redundancy";
            GVL_node_7_1.Attributes.Append(GVL.CreateAttribute("Value"));
            GVL_node_7_1.Attributes["Value"].Value = "";
            GVL_node_6 = GVL.CreateElement("Attributes");
            GVL_node_6.AppendChild(GVL_node_7);
            GVL_node_6.AppendChild(GVL_node_7_1);
            if (ligt_MBS)
            {
                GVL_node_7_2 = GVL.CreateElement("Attribute");
                GVL_node_7_2.Attributes.Append(GVL.CreateAttribute("Name"));
                GVL_node_7_2.Attributes["Name"].Value = "pack_mode";
                GVL_node_7_2.Attributes.Append(GVL.CreateAttribute("Value"));
                GVL_node_7_2.Attributes["Value"].Value = "1";
                GVL_node_6.AppendChild(GVL_node_7_2);
            }            
            GVL_node_5 = GVL.CreateElement("data");
            GVL_node_5.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_5.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/attributes";
            GVL_node_5.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_5.Attributes["handleUnknown"].Value = "implementation";
            GVL_node_5.AppendChild(GVL_node_6);
            GVL_node_4 = GVL.CreateElement("addData");
            GVL_node_4.AppendChild(GVL_node_5);
            GVL_node_4.AppendChild(GVL_node_8);
            GVL_node_1.AppendChild(GVL_node_4);
            GVL_node_0.AppendChild(GVL_node_1);
            Application_node_4 = Application_IN.CreateElement("Object");
            Application_node_4.Attributes.Append(Application_IN.CreateAttribute("Name"));
            Application_node_4.Attributes["Name"].Value = name;
            Application_node_4.Attributes.Append(Application_IN.CreateAttribute("ObjectId"));
            Application_node_4.Attributes["ObjectId"].Value = sID;
            Application_node_3 = Application_IN.CreateElement("ProjectStructure");
            Application_node_3.AppendChild(Application_node_4);
            Application_node_2 = Application_IN.CreateElement("data");
            Application_node_2.Attributes.Append(Application_IN.CreateAttribute("name"));
            Application_node_2.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/projectstructure";
            Application_node_2.Attributes.Append(Application_IN.CreateAttribute("handleUnknown"));
            Application_node_2.Attributes["handleUnknown"].Value = "discard";
            Application_node_2.AppendChild(Application_node_3);
            Application_node_1 = Application_IN.ImportNode(GVL_node_0, true);
            Application_node_2.AppendChild(Application_node_3);
            Application_IN.DocumentElement.LastChild.AppendChild(Application_node_1);
            Application_IN.DocumentElement.LastChild.AppendChild(Application_node_2);
        }           // Конструктор GVL для Application_XML (Astra IDE)
        private void GVL_Bilding_Astra_RVE(string name, string dscr, int ID, ArrayList list)
        {
            XmlNode GVL_node_1, GVL_node_2, GVL_node_3, GVL_node_4, GVL_node_5, GVL_node_6, GVL_node_7, GVL_node_8, GVL_node_9;
            XmlNode GVL_node_0, Application_node_1, Application_node_2, Application_node_3, Application_node_4, GVL_node_7_1;

            string sID;
            int k = ID % 10;
            sID = k.ToString();
            ID /= 10;
            k = ID % 10;
            sID = k.ToString() + sID;
            ID /= 10;
            k = ID % 10;
            sID = k.ToString() + sID;
            sID = "aee2fe06-f677-434c-8c3d-69670ehui" + sID;

            GVL_node_0 = GVL.CreateElement("data");
            GVL_node_0.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_0.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/globalvars";
            GVL_node_0.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_0.Attributes["handleUnknown"].Value = "implementation";
            GVL_node_1 = GVL.CreateElement("globalVars");
            GVL_node_1.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_1.Attributes["name"].Value = name;
            ///////////////////////////////////////////////////////////////////////////
            for (int i = 0; i < list.Count; i++)
            {
                GVL_node_1.AppendChild(Var_Bilding_RVE(list[i].ToString()));                        
                
            }
            ///////////////////////////////////////////////////////////////////////////
            GVL_node_3 = GVL.CreateElement("xhtml");
            GVL_node_3.Attributes.Append(GVL.CreateAttribute("xmlns"));
            GVL_node_3.Attributes["xmlns"].Value = "http://www.w3.org/1999/xhtml";
            GVL_node_3.InnerText = dscr;
            GVL_node_2 = GVL.CreateElement("documentation");
            GVL_node_2.AppendChild(GVL_node_3);
            GVL_node_1.AppendChild(GVL_node_2);
            GVL_node_9 = GVL.CreateElement("ObjectId");
            GVL_node_9.InnerText = sID;
            GVL_node_8 = GVL.CreateElement("data");
            GVL_node_8.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_8.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/objectid";
            GVL_node_8.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_8.Attributes["handleUnknown"].Value = "discard";
            GVL_node_8.AppendChild(GVL_node_9);
            GVL_node_7 = GVL.CreateElement("Attribute");
            GVL_node_7.Attributes.Append(GVL.CreateAttribute("Name"));
            GVL_node_7.Attributes["Name"].Value = "subsequent";
            GVL_node_7.Attributes.Append(GVL.CreateAttribute("Value"));
            GVL_node_7.Attributes["Value"].Value = "";
            //GVL_node_7_1 = GVL.CreateElement("Attribute");
            //GVL_node_7_1.Attributes.Append(GVL.CreateAttribute("Name"));
            //GVL_node_7_1.Attributes["Name"].Value = "ps.add_redundancy";
            //GVL_node_7_1.Attributes.Append(GVL.CreateAttribute("Value"));
            //GVL_node_7_1.Attributes["Value"].Value = "";
            GVL_node_6 = GVL.CreateElement("Attributes");
            GVL_node_6.AppendChild(GVL_node_7);
            //GVL_node_6.AppendChild(GVL_node_7_1);
            GVL_node_5 = GVL.CreateElement("data");
            GVL_node_5.Attributes.Append(GVL.CreateAttribute("name"));
            GVL_node_5.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/attributes";
            GVL_node_5.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
            GVL_node_5.Attributes["handleUnknown"].Value = "implementation";
            GVL_node_5.AppendChild(GVL_node_6);
            GVL_node_4 = GVL.CreateElement("addData");
            GVL_node_4.AppendChild(GVL_node_5);
            GVL_node_4.AppendChild(GVL_node_8);
            GVL_node_1.AppendChild(GVL_node_4);
            GVL_node_0.AppendChild(GVL_node_1);
            Application_node_4 = Application_IN.CreateElement("Object");
            Application_node_4.Attributes.Append(Application_IN.CreateAttribute("Name"));
            Application_node_4.Attributes["Name"].Value = name;
            Application_node_4.Attributes.Append(Application_IN.CreateAttribute("ObjectId"));
            Application_node_4.Attributes["ObjectId"].Value = sID;
            Application_node_3 = Application_IN.CreateElement("ProjectStructure");
            Application_node_3.AppendChild(Application_node_4);
            Application_node_2 = Application_IN.CreateElement("data");
            Application_node_2.Attributes.Append(Application_IN.CreateAttribute("name"));
            Application_node_2.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/projectstructure";
            Application_node_2.Attributes.Append(Application_IN.CreateAttribute("handleUnknown"));
            Application_node_2.Attributes["handleUnknown"].Value = "discard";
            Application_node_2.AppendChild(Application_node_3);
            Application_node_1 = Application_IN.ImportNode(GVL_node_0, true);
            Application_node_2.AppendChild(Application_node_3);
            Application_IN.DocumentElement.LastChild.AppendChild(Application_node_1);
            Application_IN.DocumentElement.LastChild.AppendChild(Application_node_2);
        }       // RVE конструктор GVL для Application_XML (Astra IDE)
        XmlNode      Var_Bilding_MBS(string var_string)
        {
            //var_string: name(string);array(bool);type_var(string);value_var(int);dscr_var(word);offset(int);

            XmlNode VAR_node_1, VAR_node_2, VAR_node_3, VAR_node_4, VAR_node_5;
            XmlNode VAR_node_6, VAR_node_7, VAR_node_8, VAR_node_9;
            string name, type_var, dscr_var, offset;

            string[] words = var_string.Split(';');
            name = words[0];
            type_var = words[2];
            dscr_var = words[4];
            offset = words[5];

            VAR_node_1 = GVL.CreateElement("variable");
            VAR_node_1.Attributes.Append(GVL.CreateAttribute("name"));
            VAR_node_1.Attributes["name"].Value = name;

            VAR_node_2 = GVL.CreateElement("type");
            VAR_node_3 = GVL.CreateElement("pointer");
            VAR_node_4 = GVL.CreateElement("baseType");
            VAR_node_5 = GVL.CreateElement(type_var);
            VAR_node_4.AppendChild(VAR_node_5);
            VAR_node_3.AppendChild(VAR_node_4);
            VAR_node_2.AppendChild(VAR_node_3);
            VAR_node_1.AppendChild(VAR_node_2);

            VAR_node_6 = GVL.CreateElement("initialValue");
            VAR_node_7 = GVL.CreateElement("simpleValue");
            VAR_node_7.Attributes.Append(GVL.CreateAttribute("value"));
            VAR_node_7.Attributes["value"].Value = "(ADR(Slave_Dev) + ("+ offset + "* SIZEOF(WORD)))";
            VAR_node_6.AppendChild(VAR_node_7);
            VAR_node_1.AppendChild(VAR_node_6);

            VAR_node_8 = GVL.CreateElement("documentation");
            VAR_node_9 = GVL.CreateElement("xhtml");
            VAR_node_9.Attributes.Append(GVL.CreateAttribute("xmlns"));
            VAR_node_9.Attributes["xmlns"].Value = "http://www.w3.org/1999/xhtml";
            VAR_node_9.InnerText = dscr_var;
            VAR_node_8.AppendChild(VAR_node_9);
            VAR_node_1.AppendChild(VAR_node_8);

            return VAR_node_1;
        }                                            // Конструктор переменных для GVL
        XmlNode      Var_Bilding(string var_string)
        {
            //var_string: name(string);array(bool);lower_ar(word);upper_ar(word);type_ar(string);
            //or
            //var_string: name(string);array(bool);type_var(string);value_var(int);dscr_var(word);

            XmlNode VAR_node_1, VAR_node_2, VAR_node_3, VAR_node_4, VAR_node_5;
            XmlNode VAR_node_6, VAR_node_7;
            XmlNode RVE_node_0, RVE_node_1, RVE_node_2, RVE_node_3;
            bool array = false;
            string name;
            string lower_ar, upper_ar, type_ar; ;
            string type_var, dscr_var, value_var;

            string[] words = var_string.Split(';');
            name = words[0];
            lower_ar = words[2];
            upper_ar = words[3];
            type_ar = words[4];
            type_var = words[2];
            value_var = words[3];
            dscr_var = words[4];
            if (words[1] == "true") array = true;

            VAR_node_1 = GVL.CreateElement("variable");
            VAR_node_1.Attributes.Append(GVL.CreateAttribute("name"));
            VAR_node_1.Attributes["name"].Value = name;

            if (array)
            {
                VAR_node_7 = GVL.CreateElement("derived");
                VAR_node_7.Attributes.Append(GVL.CreateAttribute("name"));
                VAR_node_7.Attributes["name"].Value = type_ar;
                VAR_node_6 = GVL.CreateElement("baseType");
                VAR_node_6.AppendChild(VAR_node_7);
                VAR_node_5 = GVL.CreateElement("dimension");
                VAR_node_5.Attributes.Append(GVL.CreateAttribute("lower"));
                VAR_node_5.Attributes["lower"].Value = lower_ar;
                VAR_node_5.Attributes.Append(GVL.CreateAttribute("upper"));
                VAR_node_5.Attributes["upper"].Value = upper_ar;
                VAR_node_4 = GVL.CreateElement("array");
                VAR_node_4.AppendChild(VAR_node_5);
                VAR_node_4.AppendChild(VAR_node_6);
                VAR_node_3 = GVL.CreateElement("type");
                VAR_node_3.AppendChild(VAR_node_4);
                VAR_node_1.AppendChild(VAR_node_3);
            }
            else
            {
                VAR_node_7 = GVL.CreateElement("simpleValue");
                if (value_var != "")
                {
                    VAR_node_7.Attributes.Append(GVL.CreateAttribute("value"));
                    VAR_node_7.Attributes["value"].Value = value_var;
                }
                VAR_node_6 = GVL.CreateElement("initialValue");
                VAR_node_6.AppendChild(VAR_node_7);
                VAR_node_5 = GVL.CreateElement("xhtml");
                VAR_node_5.Attributes.Append(GVL.CreateAttribute("xmlns"));
                VAR_node_5.Attributes["xmlns"].Value = "http://www.w3.org/1999/xhtml";
                VAR_node_5.InnerText = dscr_var;
                VAR_node_4 = GVL.CreateElement("documentation");
                VAR_node_4.AppendChild(VAR_node_5);
                VAR_node_3 = GVL.CreateElement(type_var);
                VAR_node_2 = GVL.CreateElement("type");
                VAR_node_2.AppendChild(VAR_node_3);
                VAR_node_1.AppendChild(VAR_node_2);
                VAR_node_1.AppendChild(VAR_node_6);
                VAR_node_1.AppendChild(VAR_node_4);
            }         
            return VAR_node_1;
        }                                                // Конструктор переменных для GVL
        XmlNode      Var_Bilding_RVE(string var_string)
        {
            //var_string: name(string);array(bool);lower_ar(word);upper_ar(word);type_ar(string);
            //or
            //var_string: name(string);array(bool);type_var(string);value_var(int);dscr_var(word);

            XmlNode VAR_node_1, VAR_node_2, VAR_node_3, VAR_node_4, VAR_node_5;
            XmlNode VAR_node_6, VAR_node_7;
            XmlNode RVE_node_0, RVE_node_1, RVE_node_2, RVE_node_3;
            bool array = false;
            string name;
            string lower_ar, upper_ar, type_ar; ;
            string type_var, dscr_var, value_var;

            string[] words = var_string.Split(';');
            name = words[0];
            lower_ar = words[2];
            upper_ar = words[3];
            type_ar = words[4];
            type_var = words[2];
            value_var = words[3];
            dscr_var = words[4];
            if (words[1] == "true") array = true;

            VAR_node_1 = GVL.CreateElement("variable");
            VAR_node_1.Attributes.Append(GVL.CreateAttribute("name"));
            VAR_node_1.Attributes["name"].Value = name;

            if (array)
            {
                VAR_node_7 = GVL.CreateElement("derived");
                VAR_node_7.Attributes.Append(GVL.CreateAttribute("name"));
                VAR_node_7.Attributes["name"].Value = type_ar;
                VAR_node_6 = GVL.CreateElement("baseType");
                VAR_node_6.AppendChild(VAR_node_7);
                VAR_node_5 = GVL.CreateElement("dimension");
                VAR_node_5.Attributes.Append(GVL.CreateAttribute("lower"));
                VAR_node_5.Attributes["lower"].Value = lower_ar;
                VAR_node_5.Attributes.Append(GVL.CreateAttribute("upper"));
                VAR_node_5.Attributes["upper"].Value = upper_ar;
                VAR_node_4 = GVL.CreateElement("array");
                VAR_node_4.AppendChild(VAR_node_5);
                VAR_node_4.AppendChild(VAR_node_6);
                VAR_node_3 = GVL.CreateElement("type");
                VAR_node_3.AppendChild(VAR_node_4);
                VAR_node_1.AppendChild(VAR_node_3);
            }
            else
            {
                VAR_node_7 = GVL.CreateElement("simpleValue");
                if (value_var != "")
                {
                    VAR_node_7.Attributes.Append(GVL.CreateAttribute("value"));
                    VAR_node_7.Attributes["value"].Value = value_var;
                }
                VAR_node_6 = GVL.CreateElement("initialValue");
                VAR_node_6.AppendChild(VAR_node_7);
                VAR_node_5 = GVL.CreateElement("xhtml");
                VAR_node_5.Attributes.Append(GVL.CreateAttribute("xmlns"));
                VAR_node_5.Attributes["xmlns"].Value = "http://www.w3.org/1999/xhtml";
                VAR_node_5.InnerText = dscr_var;
                VAR_node_4 = GVL.CreateElement("documentation");
                VAR_node_4.AppendChild(VAR_node_5);
                VAR_node_3 = GVL.CreateElement(type_var);
                VAR_node_2 = GVL.CreateElement("type");
                VAR_node_2.AppendChild(VAR_node_3);
                VAR_node_1.AppendChild(VAR_node_2);
                VAR_node_1.AppendChild(VAR_node_6);
            }
            if (!VAR_node_1.Attributes["name"].Value.Contains("_RVE"))
            {
                RVE_node_3 = GVL.CreateElement("Attribute");
                RVE_node_3.Attributes.Append(GVL.CreateAttribute("Name"));
                RVE_node_3.Attributes["Name"].Value = "ps.add_redundancy";
                RVE_node_3.Attributes.Append(GVL.CreateAttribute("Value"));
                RVE_node_3.Attributes["Value"].Value = "";
                RVE_node_2 = GVL.CreateElement("Attributes");
                RVE_node_1 = GVL.CreateElement("data");
                RVE_node_1.Attributes.Append(GVL.CreateAttribute("name"));
                RVE_node_1.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/attributes";
                RVE_node_1.Attributes.Append(GVL.CreateAttribute("handleUnknown"));
                RVE_node_1.Attributes["handleUnknown"].Value = "implementation";
                RVE_node_0 = GVL.CreateElement("addData");

                RVE_node_2.AppendChild(RVE_node_3);
                RVE_node_1.AppendChild(RVE_node_2);
                RVE_node_0.AppendChild(RVE_node_1);
                VAR_node_1.AppendChild(RVE_node_0);
            }
            return VAR_node_1;
        }                                            // Конструктор переменных для GVL
                                            
        private void Correction_Application()
        {
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("globalVars");
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name") == "retain_vars")
                    {
                        proverka2.Attributes["name"].Value = "PersistentVars";
                        proverka2.Attributes.Append(Application_IN.CreateAttribute("persistent"));
                        proverka2.Attributes["persistent"].Value = "true";
                    }
                }
            }
        }                          // Коррекция XML Application (Преобразовать GVL RETAIN в GVL PERSISTENT)
        private void Correction_Application_2()
        {
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("localVars");
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("retain") == "true")
                    {
                        proverka2.Attributes["retain"].Value = "false";
                    }
                }
            }
        }                        // Коррекция XML Application (Не сохранять флаг инициальзации в RETAIN)
        private void Correction_Application_3()
        {
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("globalVars");
            if (proverka1 != null)
            {   
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name") == "global_vars")
                    {
                        int i;
                        do
                        {
                            i = 0;
                            foreach (XmlElement proverka3 in proverka2)
                            {
                                if (proverka3.Name == "variable")
                                {
                                    if (proverka3.FirstChild == null)
                                    {
                                        proverka2.RemoveChild(proverka3);
                                        i = 1;
                                    }
                                }
                            }
                        }
                        while (i > 0);                   
                    }
                }
            }
        }                        // Коррекция XML Application (Очистка от пустых переменных)
        private void Correction_Application_4()
        {
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("pou");
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name").Contains("IEC_870_5"))
                    {
                        proverka2.InnerXml = proverka2.InnerXml.Replace("Value__Quality", "Quality").Replace("Value__Timestamp", "Timestamp");
                    }
                }
            }
        }                        // Коррекция XML Application (Перекладка IEC104 с учетом VQT)
        private void Correction_Application_5()
        {                  
            Application_IN.InnerXml = Regex.Replace(Application_IN.InnerXml, @"[\D]{4}_imit_", "");
        }                        // Коррекция XML Application (Преобразования для имитации поля)
        private void Correction_Application_6()
        {
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("pou");
            if (proverka1 != null)
            {
                string buf4 = "";
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name").Contains("FB"))
                    {                     
                        string buf = proverka2.InnerXml;
                        string[] buf2 = buf.Split('\n');
                        string buf3 = "";
                        for (int i = 0; i < buf2.Length; i++)
                        {
                            if (!buf2[i].Contains("(* variables setting *)"))
                            {
                                buf2[i] = "0";
                            } 
                            else
                            {
                                buf2[i] = "0";
                                break;
                            }
                        }
                        for (int i = buf2.Length - 1; i > 0; i--)
                        {
                            if (!buf2[i].Contains("(* variables transitions *)"))
                            {
                                buf2[i] = "0";
                            }
                            else
                            {
                                buf2[i] = "0";
                                break;
                            }
                        }
                        for (int i = 0; i < buf2.Length; i++)
                        {
                            if (buf2[i] != "0")
                            {
                                buf3 = buf3 + buf2[i].Replace("&gt;", ">").Replace("&lt;", "<").Replace("&ge;", ">=").Replace("&le;", "<="); 
                                proverka2.InnerXml = proverka2.InnerXml.Replace(buf2[i], "").Replace("\n\n\n", "");
                            }
                        }
                        
                        buf4 = buf4 + buf3;
                    }
                }
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name").Contains("field"))
                    {
                        proverka2.LastChild.LastChild.LastChild.LastChild.InnerText = proverka2.LastChild.LastChild.LastChild.LastChild.InnerText + buf4;
                    }
                }
            }
        }                        // Коррекция XML Application (Перекладка IEC104 с учетом VQT)
        private void Search_triggers(string[] array_string)
        {
            XmlNode GVL2_node_1, GVL2_node_2, GVL2_node_3, GVL2_node_4;
            if (array_string != null)
            {
                GVL2_node_1 = Application_IN.CreateElement("globalVars");
                GVL2_node_1.Attributes.Append(Application_IN.CreateAttribute("name"));
                GVL2_node_1.Attributes["name"].Value = "triggers";
                string[] words_new = { "", "" };
                if (checkBoxR200.Checked)
                {
                    words_new[0] = ".Inputs_v2^.Discrets";
                    words_new[1] = ".Outputs_v2^.Discrets";
                }
                else if (radioButton_astra.Checked)
                {
                    words_new[0] = "_Discrets";
                    words_new[1] = "_Discrets";
                }
                else
                {
                    words_new[0] = ".Inputs_v1^.Discrets";
                    words_new[1] = "_Discrets";
                }
                string[] words_old = { "_R500_DI_32.value", "_R500_DO_32.value", "_R500_DO_32.control" };
                int n = array_string.Length;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < 2; j++)
                        array_string[i] = array_string[i].Replace(words_old[j], words_new[j]);
                    if (array_string[i].Contains(words_old[2]))
                        array_string[i] = "";
                    if (array_string[i].Contains("_trigger_"))
                    {
                        GVL2_node_4 = Application_IN.CreateElement("BOOL");
                        GVL2_node_3 = Application_IN.CreateElement("type");
                        GVL2_node_3.AppendChild(GVL2_node_4);
                        GVL2_node_2 = Application_IN.CreateElement("variable");
                        GVL2_node_2.Attributes.Append(Application_IN.CreateAttribute("name"));
                        string[] split = array_string[i].Split(new Char[] { ' ', ')', ',' });
                        for (int k = 0; k < split.Length; k++)
                        {
                            if (split[k].Contains("_trigger_"))
                                GVL2_node_2.Attributes["name"].Value = split[k];
                        }
                        GVL2_node_2.AppendChild(GVL2_node_3);
                        GVL2_node_1.AppendChild(GVL2_node_2);
                    }
                }
                string str;
                foreach (XmlElement proverka1 in GVL2_node_1)
                {
                    bool flag_repeat = false;
                    str = proverka1.GetAttribute("name") + ";" + "false;" + "BOOL;" + ";" + ";";
                    foreach (string el_trig_list in trig_list)
                    {
                        if (el_trig_list == str)
                        {
                            flag_repeat = true;
                            break;
                        }                           
                    }
                    if (!flag_repeat)
                        trig_list.Add(str);
                }
            }
        }            // Генерация простанства именя для GVL triggers
        private void Search_BROADCAST()
        {
            ArrayList shared_list = new ArrayList();
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("globalVars");
            bool key = true;
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name") == "global_vars")
                    {
                        string str;
                        foreach (XmlElement proverka3 in proverka2)
                        {
                            if (proverka3.GetAttribute("name").Contains("_BROADCAST"))
                            {
                                XmlElement dimension_node = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild;
                                XmlElement type_node = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild.NextSibling.FirstChild;
                                string name, type, lower, upper;
                                name = proverka3.GetAttribute("name");
                                lower = dimension_node.GetAttribute("lower");
                                upper = dimension_node.GetAttribute("upper");
                                type = type_node.GetAttribute("name");
                                if (key)
                                {
                                    str = "StartAddress;" + "false;" + "BYTE;" + "0;" + "Начальный адрес резервируемой памяти;";
                                    shared_list.Add(str);
                                    key = false;
                                }
                                str = name + ";" + "true;" + lower + ";" + upper + ";" + type + ";";
                                shared_list.Add(str);
                                proverka3.RemoveAll();
                            }
                        }
                        str = "EndAddress;" + "false;" + "BYTE;" + "0;" + "Конеченый адрес резервируемой памяти;";
                        shared_list.Add(str);
                    }                    
                }   
            }
            if (shared_list.Count > 1)
                GVL_Bilding_Epsilon("shared_GVL", "", 3, shared_list, false);
        }                                // Генерация простанства именя для GVL shared (Резервировать стуктуры по маске BROADCAST)
        private void Search_Shared()
        {
            ArrayList shared_list = new ArrayList();
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("globalVars");
            bool key = true;
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name") == "global_vars")
                    {
                        string str;
                        foreach (XmlElement proverka3 in proverka2)
                        {
                            if (proverka3.GetAttribute("name").Contains("_SHARED"))
                            {
                                XmlElement dimension_node = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild;
                                XmlElement type_node = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild.NextSibling.FirstChild;
                                string name, type, lower, upper;
                                name = proverka3.GetAttribute("name");
                                lower = dimension_node.GetAttribute("lower");
                                upper = dimension_node.GetAttribute("upper");
                                type = type_node.GetAttribute("name");
                                if (key)
                                {
                                    str = "StartAddress;" + "false;" + "BYTE;" + "0;" + "Начальный адрес резервируемой памяти;";
                                    shared_list.Add(str);
                                    key = false;
                                }
                                str = name + ";" + "true;" + lower + ";" + upper + ";" + type + ";";
                                shared_list.Add(str);
                                proverka3.RemoveAll();
                            }
                        }
                        str = "EndAddress;" + "false;" + "BYTE;" + "0;" + "Конеченый адрес резервируемой памяти;";
                        shared_list.Add(str);
                    }
                }
            }
            if (shared_list.Count > 1)
                GVL_Bilding_Astra("shared_GVL", "", 3, shared_list, false);
        }                                   // Генерация простанства именя для GVL shared (Резервировать стуктуры по маске shared)
        private void Search_RVE()
        {
            ArrayList shared_list = new ArrayList();
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("globalVars");
            string name_global;
            //bool key = true;
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name") == "global_vars")
                    {
                        string str;
                        foreach (XmlElement proverka3 in proverka2)
                        {
                            if (proverka3.GetAttribute("name").Contains("_RVE"))
                            {
                                XmlElement dimension_node = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild;
                                XmlElement type_node = (XmlElement)proverka3.FirstChild.FirstChild.FirstChild.NextSibling.FirstChild;
                                string name, type, lower, upper;
                                name = proverka3.GetAttribute("name");
                                lower = dimension_node.GetAttribute("lower");
                                upper = dimension_node.GetAttribute("upper");
                                type = type_node.GetAttribute("name");
                                //if (key)
                                //{
                                //    str = "StartAddress;" + "false;" + "BYTE;" + "0;" + "Начальный адрес резервируемой памяти;";
                                //    shared_list.Add(str);
                                //    key = false;
                                //}
                                str = name + ";" + "true;" + lower + ";" + upper + ";" + type + ";";
                                shared_list.Add(str);
                                proverka3.RemoveAll();
                                name_global = name.Replace("_RVE", "");
                                foreach (XmlElement proverka4 in proverka2)
                                {
                                    if (proverka4.GetAttribute("name").Contains(name_global))
                                    {
                                        str = name_global + ";" + "true;" + lower + ";" + upper + ";" + type + ";";
                                        shared_list.Add(str);
                                        proverka4.RemoveAll();
                                    }
                                }
                            }
                        }
                        //str = "EndAddress;" + "false;" + "BYTE;" + "0;" + "Конеченый адрес резервируемой памяти;";
                        //shared_list.Add(str);

                    }
                }
            }
            if (shared_list.Count > 1)
                GVL_Bilding_Astra_RVE("crossed_GVL", "", 3, shared_list);
        }                                      // Генерация простанства именя для GVL shared (Резервировать стуктуры по маске rve)
        private void Search_RVE_IEC_104()
        {
            XmlNode GVL_node_7_1, GVL_node_4, GVL_node_5, GVL_node_6;
            XmlNodeList proverka1 = Application_IN.GetElementsByTagName("pou");
            if (proverka1 != null)
            {
                foreach (XmlElement proverka2 in proverka1)
                {
                    if (proverka2.GetAttribute("name").Contains("IEC_870") && proverka2.GetAttribute("pouType").Contains("program"))
                    {
                        foreach (XmlElement proverka3 in proverka2.FirstChild.FirstChild)
                        {
                            if (proverka3.GetAttribute("name").Contains("_RVE"))
                            {
                                string varname_RVE, varname;
                                varname_RVE = proverka3.GetAttribute("name");
                                varname = varname_RVE.Replace("_RVE", "");

                                foreach (XmlElement proverka4 in proverka2.FirstChild.FirstChild)
                                {
                                    if (proverka4.GetAttribute("name").Contains(varname) && proverka4.GetAttribute("name") != varname_RVE)
                                    {
                                        GVL_node_7_1 = Application_IN.CreateElement("Attribute");
                                        GVL_node_7_1.Attributes.Append(Application_IN.CreateAttribute("Name"));
                                        GVL_node_7_1.Attributes["Name"].Value = "ps.add_redundancy";
                                        GVL_node_7_1.Attributes.Append(Application_IN.CreateAttribute("Value"));
                                        GVL_node_7_1.Attributes["Value"].Value = "";

                                        GVL_node_6 = Application_IN.CreateElement("Attributes");
                                        GVL_node_6.AppendChild(GVL_node_7_1);

                                        GVL_node_5 = Application_IN.CreateElement("data");
                                        GVL_node_5.Attributes.Append(Application_IN.CreateAttribute("name"));
                                        GVL_node_5.Attributes["name"].Value = "http://www.3s-software.com/plcopenxml/attributes";
                                        GVL_node_5.Attributes.Append(Application_IN.CreateAttribute("handleUnknown"));
                                        GVL_node_5.Attributes["handleUnknown"].Value = "implementation";
                                        GVL_node_5.AppendChild(GVL_node_6);

                                        GVL_node_4 = Application_IN.CreateElement("addData");
                                        GVL_node_4.AppendChild(GVL_node_5);
                                        proverka4.AppendChild(GVL_node_4);
                                    }
                                }                           
                            }
                        }
                    }
                }
            }
        }                              // Редактирование простанства именя (Резервировать стуктуры по маске RVE_IEC)
        private void Task_Application()
        {         
            GVL_Bilding_Epsilon("triggers", "", 2, trig_list, false);
            trig_list.Clear();
                         
            if (checkBox_BROADCAST.Checked && radioButton_epsilon.Checked)
            {
                Search_BROADCAST();
            }
            else if (checkBox_BROADCAST.Checked && radioButton_astra.Checked)
            {
                Search_Shared();
                Search_RVE();
                Search_RVE_IEC_104();
            }
                
            if (true)
                Correction_Application_3();
            if (checkBox_PERSISTENT.Checked)
                Correction_Application();
            if (checkBox_RETAIN.Checked)
                Correction_Application_2();
            if (checkBox_VQT.Checked)
                Correction_Application_4();
            if (checkBox_imit.Checked)
                Correction_Application_5();
            if (checkBox_FB_field.Checked)
                Correction_Application_6();            
            if (Application_IN.FirstChild != null)
            {
                string sumname_XML = path + "\\" + short_name_apr.Replace(".xml", "") + "\\REGUL_Application.xml";
                Application_IN.Save(sumname_XML);
            }
            else
            {
                MessageBox.Show("Ошибка создания XML REGUL_Application", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                                // Задача для обработки и сохранения Application_IN

        private void Correction_APR(string name)
        {
            XmlNodeList proverka1 = APR_Corrected.GetElementsByTagName("configuration");
            XmlNode APR_Node = APR_Corrected.CreateElement("project");
            for (int i = 0; i < proverka1.Count; i++)
            {
                if (proverka1[i].Attributes["name"].Value == name)
                {
                    APR_Node.AppendChild(proverka1[i]);
                    i--;
                }
            }
            APR.LoadXml("<project>" + "</project>");
            XmlNode APR_Node2 = APR.CreateElement("project");
            APR_Node2 = APR.ImportNode(APR_Node, true);
            APR.DocumentElement.AppendChild(APR_Node2);
        }                       // Коррекция XML АПР
        private void Search_Iec104s(string name_XML, string name_IEC)
        {
            FileStream file_descr = File.Open(path + "\\" + "fileDescription.txt", FileMode.Create);
            StreamWriter output_file_descr = new StreamWriter(file_descr);
            string[] map_description = null; 
            Correction_APR(name_IEC); //Отредактировали АПР под станционный МЭК104
            string sumname_XML;
            XmlNode REGUL_IEC104_DATA_node_1, REGUL_IEC104_DATA_node_2, REGUL_IEC104_DATA_node_3;
            XmlNode REGUL_IEC104_CMD_node_1, REGUL_IEC104_CMD_node_2, REGUL_IEC104_CMD_node_3;
            XmlNodeList proverka1 = APR.GetElementsByTagName("Parameter");                  // Получаем выборку узлов по имени
            REGUL_IEC104_DATA_node_1 = REGUL_IEC_DATA.CreateElement("ListOfItem");
            REGUL_IEC104_CMD_node_1 = REGUL_IEC_CMD.CreateElement("ListOfItem");            
            foreach (XmlElement proverka2 in proverka1)                                         // Поиск каналов по выборке
            {                                
                if (proverka2.GetAttribute("type") == "localTypes:IEC_SLAVE_CHANNEL")
                {                    
                    foreach (XmlElement proverka3 in proverka2)     // Поиск узлов в канале
                    {                        
                        if (proverka3.Name == "Value")                // Остальные параметры каналов
                        {
                            string SignalsStartID;
                            foreach (XmlElement proverka4 in proverka3)
                            {
                                string flag_type;
                                if (proverka4.GetAttribute("name") == "PType")
                                {
                                    if ((proverka4.InnerText == "30") || (proverka4.InnerText == "33") || (proverka4.InnerText == "36") || (proverka4.InnerText == "9") || (proverka4.InnerText == "37")) flag_type = "DATA";
                                    else flag_type = "CMD";
                                    if (flag_type == "DATA")
                                    {
                                        int length = 1;
                                        {
                                            REGUL_IEC104_DATA_node_2 = REGUL_IEC_DATA.CreateElement("Item");
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("Name"));
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("Descr"));
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("TypeId"));
                                            REGUL_IEC104_DATA_node_2.Attributes["TypeId"].Value = proverka4.InnerText;
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("CustomTypeId"));
                                            REGUL_IEC104_DATA_node_2.Attributes["CustomTypeId"].Value = "0";
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("AutoTime"));
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("HighBound"));
                                            REGUL_IEC104_DATA_node_2.Attributes["HighBound"].Value = "32000";
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("LowBound"));
                                            REGUL_IEC104_DATA_node_2.Attributes["LowBound"].Value = "0";
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("Scale"));
                                            REGUL_IEC104_DATA_node_2.Attributes["Scale"].Value = "0";
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("IoAdr"));
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("MapVarName"));
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("Cycle"));
                                            REGUL_IEC104_DATA_node_2.Attributes.Append(REGUL_IEC_DATA.CreateAttribute("DeadBand"));
                                            REGUL_IEC104_DATA_node_2.Attributes["DeadBand"].Value = "0";
                                        }                                               // Создаем Канал Iec104s DATA
                                        foreach (XmlElement proverka5 in proverka3)
                                        {
                                            if (proverka5.GetAttribute("name") == "Address")
                                            {
                                                REGUL_IEC104_DATA_node_2.Attributes["IoAdr"].Value = proverka5.InnerText;
                                            }
                                            if (proverka5.GetAttribute("name") == "Count")
                                            {
                                                length = Convert.ToInt32(proverka5.InnerText);
                                            }
                                            if (proverka5.GetAttribute("name") == "DataClass")
                                            {
                                                if (proverka5.InnerText == "1") REGUL_IEC104_DATA_node_2.Attributes["Cycle"].Value = "0";
                                                if (proverka5.InnerText == "2") REGUL_IEC104_DATA_node_2.Attributes["Cycle"].Value = "1";
                                            }
                                            if (true)
                                            {
                                                if (checkBox_AutoTime.Checked)
                                                {
                                                    REGUL_IEC104_DATA_node_2.Attributes["AutoTime"].Value = "true";
                                                }
                                                else
                                                {
                                                    REGUL_IEC104_DATA_node_2.Attributes["AutoTime"].Value = "false";
                                                }
                                            }
                                        }    // Изменяем атрибуты канала
                                        foreach (XmlElement proverka5 in proverka3)
                                        {
                                            if (proverka5.GetAttribute("name") == "SignalsStartID")
                                            {
                                                SignalsStartID = proverka5.InnerText;
                                                XmlNodeList proverka_MAPPING = proverka1;
                                                foreach (XmlElement proverka_MAPPING1 in proverka_MAPPING)                                  // Поиск каналов по выборке
                                                {                                                    
                                                    if (proverka_MAPPING1.GetAttribute("ParameterId") == SignalsStartID)
                                                    {
                                                        int nuber_items = proverka_MAPPING1.ChildNodes.Count;
                                                        REGUL_IEC104_DATA_node_2.Attributes["Name"].Value = proverka_MAPPING1.ChildNodes.Item(nuber_items - 3).InnerText;
                                                        REGUL_IEC104_DATA_node_2.Attributes["Descr"].Value = proverka_MAPPING1.ChildNodes.Item(nuber_items - 2).InnerText;
                                                        REGUL_IEC104_DATA_node_2.Attributes["MapVarName"].Value = proverka_MAPPING1.ChildNodes.Item(nuber_items - 1).InnerText;                         
                                                        break;
                                                    }
                                                }
                                                REGUL_IEC104_DATA_node_1.AppendChild(REGUL_IEC104_DATA_node_2);
                                                int ID = Convert.ToInt32(SignalsStartID) + 1;
                                                string IoAdr = REGUL_IEC104_DATA_node_2.Attributes["IoAdr"].Value;
                                                string smal_buf = short_name_apr.Replace("USO", "").Replace(".xml", "") + " " + REGUL_IEC104_DATA_node_2.Attributes["IoAdr"].Value + " " + REGUL_IEC104_DATA_node_2.Attributes["Descr"].Value;
                                                output_file_descr.WriteLine(smal_buf);
                                                int sIoAdr = Convert.ToInt32(IoAdr) + 1;
                                                int count = 0;
                                                foreach (XmlElement proverka_MAPPING3 in proverka_MAPPING)                   // Поиск каналов по выборке
                                                {
                                                    string sID = ID.ToString();
                                                    if (proverka_MAPPING3.GetAttribute("ParameterId") == sID && proverka_MAPPING3.GetAttribute("type").Contains("localTypes"))
                                                    {
                                                        REGUL_IEC104_DATA_node_3 = REGUL_IEC104_DATA_node_2.Clone();
                                                        count++;                                                      
                                                        int nuber_items = proverka_MAPPING3.ChildNodes.Count;
                                                        REGUL_IEC104_DATA_node_3.Attributes["Name"].Value = proverka_MAPPING3.ChildNodes.Item(nuber_items - 3).InnerText;
                                                        REGUL_IEC104_DATA_node_3.Attributes["Descr"].Value = proverka_MAPPING3.ChildNodes.Item(nuber_items - 2).InnerText;
                                                        REGUL_IEC104_DATA_node_3.Attributes["MapVarName"].Value = proverka_MAPPING3.ChildNodes.Item(nuber_items - 1).InnerText;
                                                        ID++;
                                                        REGUL_IEC104_DATA_node_3.Attributes["IoAdr"].Value = sIoAdr.ToString();
                                                        smal_buf = short_name_apr.Replace("USO","").Replace(".xml","") + " " + sIoAdr.ToString() + " " + REGUL_IEC104_DATA_node_3.Attributes["Descr"].Value;
                                                        output_file_descr.WriteLine(smal_buf);
                                                        sIoAdr++;                                                
                                                        
                                                        if (count != length)                                                      
                                                            REGUL_IEC104_DATA_node_1.AppendChild(REGUL_IEC104_DATA_node_3);                                                      
                                                        else
                                                            break;
                                                    }                     
                                                }
                                            }
                                        }    // Mapping канала
                                    }
                                    if (flag_type == "CMD")
                                    {
                                        int length = 1;
                                        {
                                            REGUL_IEC104_CMD_node_2 = REGUL_IEC_CMD.CreateElement("Item");
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("Name"));
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("Descr"));
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("TypeId"));
                                            REGUL_IEC104_CMD_node_2.Attributes["TypeId"].Value = proverka4.InnerText;
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("CustomTypeId"));
                                            REGUL_IEC104_CMD_node_2.Attributes["CustomTypeId"].Value = "0";
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("AutoTime"));
                                            REGUL_IEC104_CMD_node_2.Attributes["AutoTime"].Value = "False";
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("HighBound"));
                                            REGUL_IEC104_CMD_node_2.Attributes["HighBound"].Value = "0";
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("LowBound"));
                                            REGUL_IEC104_CMD_node_2.Attributes["LowBound"].Value = "0";
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("Scale"));
                                            REGUL_IEC104_CMD_node_2.Attributes["Scale"].Value = "0";
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("IoAdr"));
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("MapVarName"));
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("MirrorAdr"));
                                            REGUL_IEC104_CMD_node_2.Attributes["MirrorAdr"].Value = "0";
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("SelectPeriod"));
                                            if (name_IEC == "IEC104s_EDC")
                                            {
                                                REGUL_IEC104_CMD_node_2.Attributes["SelectPeriod"].Value = textBox_CMD_2.Text;
                                            }
                                            if (name_IEC == "IEC104s")
                                            {
                                                REGUL_IEC104_CMD_node_2.Attributes["SelectPeriod"].Value = textBox_CMD_1.Text;
                                            }
                                            REGUL_IEC104_CMD_node_2.Attributes["SelectPeriod"].Value = textBox_CMD_1.Text; 
                                            REGUL_IEC104_CMD_node_2.Attributes.Append(REGUL_IEC_CMD.CreateAttribute("ExecTimeout"));
                                            REGUL_IEC104_CMD_node_2.Attributes["ExecTimeout"].Value = "5";
                                        }// Создаем Канал Iec104s CMD
                                        foreach (XmlElement proverka5 in proverka3)
                                        {
                                            if (proverka5.GetAttribute("name") == "Address")
                                            {
                                                REGUL_IEC104_CMD_node_2.Attributes["IoAdr"].Value = proverka5.InnerText;
                                            }
                                            if (proverka5.GetAttribute("name") == "Count")
                                            {
                                                length = Convert.ToInt32(proverka5.InnerText);
                                            }
                                            if (proverka5.GetAttribute("name") == "SignalsStartID")
                                            {   
                                                SignalsStartID = proverka5.InnerText;
                                                XmlNodeList proverka_MAPPING = proverka1;
                                                foreach (XmlElement proverka_MAPPING1 in proverka_MAPPING)                                  // Поиск каналов по выборке
                                                {
                                                    if (proverka_MAPPING1.GetAttribute("ParameterId") == SignalsStartID)
                                                    {
                                                        int nuber_items = proverka_MAPPING1.ChildNodes.Count;
                                                        REGUL_IEC104_CMD_node_2.Attributes["Name"].Value = proverka_MAPPING1.ChildNodes.Item(nuber_items - 3).InnerText;
                                                        REGUL_IEC104_CMD_node_2.Attributes["Descr"].Value = proverka_MAPPING1.ChildNodes.Item(nuber_items - 2).InnerText;
                                                        REGUL_IEC104_CMD_node_2.Attributes["MapVarName"].Value = proverka_MAPPING1.ChildNodes.Item(nuber_items - 1).InnerText;                                                
                                                    }
                                                }
                                                REGUL_IEC104_CMD_node_1.AppendChild(REGUL_IEC104_CMD_node_2);
                                                int ID = Convert.ToInt32(SignalsStartID) + 1;
                                                string IoAdr = REGUL_IEC104_CMD_node_2.Attributes["IoAdr"].Value;
                                                string smal_buf = short_name_apr.Replace("USO", "").Replace(".xml", "") + " " + REGUL_IEC104_CMD_node_2.Attributes["IoAdr"].Value + " " + REGUL_IEC104_CMD_node_2.Attributes["Descr"].Value;
                                                output_file_descr.WriteLine(smal_buf);
                                                int sIoAdr = Convert.ToInt32(IoAdr) + 1;
                                                int count = 0;
                                                foreach (XmlElement proverka_MAPPING3 in proverka_MAPPING)                   // Поиск каналов по выборке
                                                {
                                                    string sID = ID.ToString();
                                                    if (proverka_MAPPING3.GetAttribute("ParameterId") == sID && proverka_MAPPING3.GetAttribute("type").Contains("localTypes"))
                                                    {
                                                        REGUL_IEC104_CMD_node_3 = REGUL_IEC104_CMD_node_2.Clone();
                                                        count++;
                                                        int nuber_items = proverka_MAPPING3.ChildNodes.Count;
                                                        REGUL_IEC104_CMD_node_3.Attributes["Name"].Value = proverka_MAPPING3.ChildNodes.Item(nuber_items - 3).InnerText;
                                                        REGUL_IEC104_CMD_node_3.Attributes["Descr"].Value = proverka_MAPPING3.ChildNodes.Item(nuber_items - 2).InnerText;
                                                        REGUL_IEC104_CMD_node_3.Attributes["MapVarName"].Value = proverka_MAPPING3.ChildNodes.Item(nuber_items - 1).InnerText;
                                                        ID++;
                                                        REGUL_IEC104_CMD_node_3.Attributes["IoAdr"].Value = sIoAdr.ToString();
                                                        smal_buf = short_name_apr.Replace("USO", "").Replace(".xml", "") + " " + sIoAdr.ToString() + " " + REGUL_IEC104_CMD_node_3.Attributes["Descr"].Value;
                                                        output_file_descr.WriteLine(smal_buf);
                                                        sIoAdr++;
                                                        if (count != length)
                                                            REGUL_IEC104_CMD_node_1.AppendChild(REGUL_IEC104_CMD_node_3);
                                                        else
                                                            break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }                                                                                 
                        }                       
                    }
                }
            }
            REGUL_IEC_CMD.AppendChild(REGUL_IEC104_CMD_node_1);
            REGUL_IEC_DATA.AppendChild(REGUL_IEC104_DATA_node_1);
            output_file_descr.Close();
            if (REGUL_IEC_DATA.FirstChild.FirstChild == null) REGUL_IEC_DATA.RemoveAll();
            if (REGUL_IEC_CMD.FirstChild.FirstChild == null) REGUL_IEC_CMD.RemoveAll();
            if (REGUL_IEC_DATA.FirstChild != null)
            {
                sumname_XML = path + "\\" + short_name_apr.Replace(".xml","") + name_XML + "DATA.iec104data.xml";
                REGUL_IEC_DATA.Save(sumname_XML);
                REGUL_IEC_DATA.RemoveAll();
            }
            else
            {
                if (checkBox_IEC.Checked)
                    MessageBox.Show("Ошибка создания XML REGUL_IEC104_ST_DATA", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (REGUL_IEC_CMD.FirstChild != null)
            {
                sumname_XML = path + "\\" + short_name_apr.Replace(".xml", "") + name_XML + "CMD.iec104cmd.xml";
                REGUL_IEC_CMD.Save(sumname_XML);
                REGUL_IEC_CMD.RemoveAll();
            }
            else
            {
                if (checkBox_IEC.Checked)
                    MessageBox.Show("Ошибка создания  XML REGUL_IEC104_ST_CMD", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  // Генерация XML Iec104_SLAVE        
        private void Task_Iec104()
        {
            if (checkBox_IEC.Checked)
            {                                
                Search_Iec104s("\\REGUL_IEC104_ST_", "IEC104s");
            }
            if (checkBox_IEC_EDC.Checked)
            {
                Search_Iec104s("\\REGUL_IEC104_EDC_", "IEC104s_EDC");
            }
        }                                     // Задача для Iec104

        private void Search_ModBus_TCP()
        {
            string name_GVL = "MBS_GVL";
            ArrayList MBS_freelist = new ArrayList();
            XmlNode REGUL_ModBus_node_1, REGUL_ModBus_node_2, REGUL_ModBus_node_3;
            string MBS_freestring;          
            XmlNode true_ParameterSection;
            XmlNodeList lists_ParameterSections = APR_Corrected.GetElementsByTagName("ParameterSection");         // Получаем выборку узлов по имени ParameterSection
            XmlDocument buffer = new XmlDocument();
            buffer.AppendChild(buffer.CreateElement("title"));
            foreach (XmlElement XmlElement_ParameterSection in lists_ParameterSections)
            {
                if (XmlElement_ParameterSection.FirstChild.InnerText == "Channels" && XmlElement_ParameterSection.FirstChild.Name == "Name")
                {
                    true_ParameterSection = XmlElement_ParameterSection;
                    foreach (XmlElement XmlElement_lists_Parameters in true_ParameterSection.ChildNodes)
                    {
                        if (XmlElement_lists_Parameters.Name == "Parameter")
                            buffer.DocumentElement.AppendChild(buffer.ImportNode(XmlElement_lists_Parameters, true));
                    }
                }
            }                       // Нашли ParameterSection с каналами ModBus
            XmlNodeList lists_Parameters = buffer.GetElementsByTagName("Parameter");                             // Получаем выборку узлов по имени Parameter
            ////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            REGUL_ModBus_node_1 = REGUL_ModBus_TCP.CreateElement("ModbusSlaveDirectChannels");
            foreach (XmlElement XmlElement_Parametr in lists_Parameters)                                         
            {
                if (XmlElement_Parametr.GetAttribute("type") == "localTypes:MODBUS_SLAVE_CHANNEL")               // Поиск каналов по выборке
                {
                    foreach (XmlElement Channels in XmlElement_Parametr)     
                    {
                        if (Channels.Name == "Value")                                                             // Поиск узлов "Value" в канале
                        {
                            string SignalsStartID;
                            int length = 1;
                            int count = 1;
                            int start_address = 0;
                            {
                                REGUL_ModBus_node_2 = REGUL_ModBus_TCP.CreateElement("DirectSlaveCh");
                                REGUL_ModBus_node_2.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Name"));
                                REGUL_ModBus_node_2.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Descr"));
                                REGUL_ModBus_node_2.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Length"));
                                REGUL_ModBus_node_2.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Offset"));
                                REGUL_ModBus_node_2.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Type"));
                                REGUL_ModBus_node_2.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("VarName"));
                            }   // Создаем Канал
                            string DType = "";
                            foreach (XmlElement Chanel in Channels)
                            {                      
                                if (Chanel.GetAttribute("name") == "ModBusSegment")
                                {
                                    if (Chanel.InnerText == "1") REGUL_ModBus_node_2.Attributes["Type"].Value = "Нужно править в C#";
                                    if (Chanel.InnerText == "2") REGUL_ModBus_node_2.Attributes["Type"].Value = "InputRegisters";
                                    if (Chanel.InnerText == "3") REGUL_ModBus_node_2.Attributes["Type"].Value = "HoldingRegisters";
                                    if (Chanel.InnerText == "4") REGUL_ModBus_node_2.Attributes["Type"].Value = "Нужно править в C#";
                                }
                                if (Chanel.GetAttribute("name") == "DType")
                                {
                                    DType = Chanel.InnerText;
                                    DType = DType.Substring(1, DType.Length - 2);
                                    if (DType == "DINT" | DType == "DWORD" | DType == "UDINT" | DType == "REAL")
                                    {
                                        length = 2;
                                        REGUL_ModBus_node_2.Attributes["Length"].Value = "2";
                                    }
                                    else
                                    {
                                        length = 1;
                                        REGUL_ModBus_node_2.Attributes["Length"].Value = "1";
                                    }
                                }
                                if (Chanel.GetAttribute("name") == "ModBusAddress")
                                {
                                    REGUL_ModBus_node_2.Attributes["Offset"].Value = Chanel.InnerText;
                                    start_address = Convert.ToInt32(Chanel.InnerText);
                                }
                                if (Chanel.GetAttribute("name") == "Count")
                                {
                                    count = Convert.ToInt32(Chanel.InnerText);
                                }
                                if (Chanel.GetAttribute("name") == "SignalsStartID")
                                {   // MAPPING
                                    SignalsStartID = Chanel.InnerText;
                                    XmlNodeList Parameters = lists_Parameters;                                            // Получаем выборку узлов по имени
                                    foreach (XmlElement proverka_MAPPING1 in Parameters)                                  // Поиск каналов по выборке
                                    {
                                        if (proverka_MAPPING1.GetAttribute("ParameterId") == SignalsStartID)
                                        {
                                            foreach (XmlElement proverka_MAPPING2 in proverka_MAPPING1)
                                            {
                                                if (proverka_MAPPING2.Name == "Name")
                                                {
                                                    REGUL_ModBus_node_2.Attributes["Name"].Value = proverka_MAPPING2.InnerText;
                                                }
                                                if (proverka_MAPPING2.Name == "Description")
                                                {
                                                    REGUL_ModBus_node_2.Attributes["Descr"].Value = proverka_MAPPING2.InnerText;
                                                    if (checkBox_ARDEV.Checked)
                                                        REGUL_ModBus_node_2.Attributes["Descr"].Value = REGUL_ModBus_node_2.Attributes["Descr"].Value + " " + DType;
                                                }
                                                if (proverka_MAPPING2.Name == "Mapping")
                                                {
                                                    REGUL_ModBus_node_2.Attributes["VarName"].Value = proverka_MAPPING2.InnerText;
                                                }
                                            }
                                            break;
                                        }
                                    }
                                    REGUL_ModBus_node_1.AppendChild(REGUL_ModBus_node_2);
                                    for (int i = 1; i < count; i++)
                                    {
                                        REGUL_ModBus_node_3 = REGUL_ModBus_node_2.Clone();
                                        int ID = Convert.ToInt32(SignalsStartID) + i;
                                        string sID = ID.ToString();
                                        foreach (XmlElement proverka_MAPPING3 in Parameters)                                  // Поиск каналов по выборке
                                        {
                                            if (proverka_MAPPING3.GetAttribute("ParameterId") == sID)
                                            {
                                                foreach (XmlElement proverka_MAPPING4 in proverka_MAPPING3)
                                                {
                                                    if (proverka_MAPPING4.Name == "Name")
                                                    {
                                                        REGUL_ModBus_node_3.Attributes["Name"].Value = proverka_MAPPING4.InnerText;
                                                    }
                                                    if (proverka_MAPPING4.Name == "Description")
                                                    {
                                                        REGUL_ModBus_node_3.Attributes["Descr"].Value = proverka_MAPPING4.InnerText;
                                                        if (checkBox_ARDEV.Checked)
                                                            REGUL_ModBus_node_3.Attributes["Descr"].Value = REGUL_ModBus_node_3.Attributes["Descr"].Value + " " + DType;
                                                    }
                                                    if (proverka_MAPPING4.Name == "Mapping")
                                                    {
                                                        REGUL_ModBus_node_3.Attributes["VarName"].Value = proverka_MAPPING4.InnerText;
                                                    }
                                                }
                                                break;
                                            }
                                        }
                                        int sIoAdr = start_address + i * length;
                                        REGUL_ModBus_node_3.Attributes["Offset"].Value = sIoAdr.ToString();
                                        REGUL_ModBus_node_1.AppendChild(REGUL_ModBus_node_3);
                                        REGUL_ModBus_node_3 = REGUL_ModBus_TCP.CreateElement("DirectSlaveCh");
                                    }
                                }
                            }
                            break;
                        }
                    }                  
                }
            }
            ////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////
            REGUL_ModBus_TCP.AppendChild(REGUL_ModBus_node_1);
            if (REGUL_ModBus_TCP.FirstChild.FirstChild == null) REGUL_ModBus_TCP.RemoveAll();
            else
            {
                foreach (XmlElement proverkalists in REGUL_ModBus_TCP.FirstChild)
                {
                    //var_string: name(string);array(bool);type_var(string);value_var(int);dscr_var(word);offset(int);
                    string var_type ="";
                    string var_name = proverkalists.GetAttribute("VarName");
                    string var_dscr = proverkalists.GetAttribute("Descr");
                    string var_offset = proverkalists.GetAttribute("Offset");
                    if (var_name.Contains("DINT") | var_name.Contains("DWORD") | var_name.Contains("UDINT") |
                        var_name.Contains("REAL"))
                    {
                        var_type = "DWORD;";
                    }
                    else
                    {
                        var_type = "WORD;";
                    }
                    if (checkBox_ARDEV.Checked)
                    {
                        var_type = proverkalists.GetAttribute("Descr").Split(' ')[1];
                        var_dscr = proverkalists.GetAttribute("Descr").Split(' ')[0];
                    }                   
                    MBS_freestring = var_name + ";" + "false" + ";" + var_type + ";" + "" + ";" + var_dscr + ";" + var_offset + ";";
                    MBS_freelist.Add(MBS_freestring);
                }
                GVL_Bilding_Epsilon(name_GVL, "", 1, MBS_freelist, checkBox_ARDEV.Checked);
            }
            if (REGUL_ModBus_TCP.FirstChild != null)
            {
                if (checkBox_ARDEV.Checked)
                {
                    REGUL_ModBus_TCP = new XmlDocument();
                    REGUL_ModBus_TCP.AppendChild(REGUL_ModBus_TCP.CreateXmlDeclaration("1.0", "UTF-8", null));               
                    REGUL_ModBus_TCP.AppendChild(REGUL_ModBus_TCP.CreateElement("ModbusSlaveDirectChannels"));
                    REGUL_ModBus_node_3 = REGUL_ModBus_TCP.CreateElement("DirectSlaveCh");
                    REGUL_ModBus_node_3.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Name"));
                    REGUL_ModBus_node_3.Attributes["Name"].Value = "Data area 1";
                    REGUL_ModBus_node_3.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Descr"));
                    REGUL_ModBus_node_3.Attributes["Descr"].Value = "United data area";
                    REGUL_ModBus_node_3.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Type"));
                    REGUL_ModBus_node_3.Attributes["Type"].Value = "HoldingRegisters";
                    REGUL_ModBus_node_3.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Offset"));
                    REGUL_ModBus_node_3.Attributes["Offset"].Value = "0";
                    REGUL_ModBus_node_3.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("Length"));
                    REGUL_ModBus_node_3.Attributes["Length"].Value = size_var(MBS_freelist).ToString();
                    REGUL_ModBus_node_3.Attributes.Append(REGUL_ModBus_TCP.CreateAttribute("VarName"));
                    REGUL_ModBus_node_3.Attributes["VarName"].Value = name_GVL + "." + "Slave_Dev";
                    REGUL_ModBus_TCP.LastChild.AppendChild(REGUL_ModBus_node_3);
                }
                string sumname_XML = path + "\\" + short_name_apr.Replace(".xml", "") + "\\REGUL_Modbus_TCP.mb_direct_channels.xml";
                
                REGUL_ModBus_TCP.Save(sumname_XML);
            }
            else
            {
                if (checkBox_MBTCP.Checked)
                    MessageBox.Show("Ошибка создания XML REGUL_Modbus_TCP", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }                               // Генерация XML ModBus_TCP_SLAVE и GVL MBS для Application
        private void Task_ModBus_TCP()
        {
            if (checkBox_MBTCP.Checked)
            {
                Search_ModBus_TCP();
            }
        }                                 // Поток для работы с ModBus_TCP


        private void Calc_Point(string[] array_string, int[] arr_int)
        {         
            if (array_string != null)
            {
                int number_TS = 0, number_TU = 0;
                int number_TR = 0, number_TI = 0;
                string USO = array_string[1].Split('.')[0];
                for (int i = 0; i < array_string.Length; i++)
                {
                    if (array_string[i].Contains(",8823,"))
                    {
                        number_TS = number_TS + Convert.ToInt32(array_string[i].Split(',')[array_string[i].Split(',').Length - 1]);
                    }
                    if (array_string[i].Contains(",8824,"))
                    {
                        number_TI = number_TI + Convert.ToInt32(array_string[i].Split(',')[array_string[i].Split(',').Length - 1]);
                    }
                    if (array_string[i].Contains(",8825,"))
                    {
                        number_TU = number_TU + Convert.ToInt32(array_string[i].Split(',')[array_string[i].Split(',').Length - 1]);
                    }
                    if (array_string[i].Contains(",8826,"))
                    {
                        number_TR = number_TR + Convert.ToInt32(array_string[i].Split(',')[array_string[i].Split(',').Length - 1]);
                    }
                }
                textBox_TI.Text = textBox_TI.Text + USO + " : " + number_TI.ToString() + " ";
                textBox_TU.Text = textBox_TU.Text + USO + " : " + number_TU.ToString() + " ";
                textBox_TS.Text = textBox_TS.Text + USO + " : " + number_TS.ToString() + " ";
                textBox_TR.Text = textBox_TR.Text + USO + " : " + number_TR.ToString() + " ";
                arr_int[0] = arr_int[0] + number_TS;
                arr_int[1] = arr_int[1] + number_TU;
                arr_int[2] = arr_int[2] + number_TR;
                arr_int[3] = arr_int[3] + number_TI;
            }
        }  // Подсчет сигналов
        private void IO_Bilding_1(string[] array_string, string path)
        {            
            // Порядок Листа: (Номер УСО;Тег сигнала;Адрес сигнала;Протокольный тип;)
            ArrayList io_list = new ArrayList();
            ArrayList N_io_list = new ArrayList();            
            string name_XML;
            if (array_string != null)
            {
                for (int i = 0; i < array_string.Length; i++)
                    {
                        if (array_string[i].Contains(",7050,") && !array_string[i].Contains("Address=\"0\""))
                        {
                            string Station = "";
                            string Address = "";
                            string ProtocolType = "";
                            string tag = "";
                            string summa;
                            string[] words = array_string[i].Split(',');
                            tag = words[0] + ";";
                            foreach (string proverka1 in words)
                            {
                                string[] words2 = proverka1.Split(' ');
                                foreach (string proverka2 in words2)
                                {
                                    if (proverka2.Contains("Station"))
                                    {
                                        string[] words3 = proverka2.Split('"');
                                        Station = words3[1] + ";";
                                        if (!N_io_list.Contains(words3[1]))
                                        {
                                            N_io_list.Add(words3[1]);
                                        }
                                    }
                                    if (proverka2.Contains("Address"))
                                    {
                                        string[] words3 = proverka2.Split('"');
                                        Address = words3[1] + ";";
                                    }
                                    if (proverka2.Contains("ProtocolType"))
                                    {
                                        string[] words3 = proverka2.Split('"');
                                        ProtocolType = words3[1] + ";";
                                    }
                                }
                            }
                            summa = Station + tag + Address + ProtocolType;
                            io_list.Add(summa);
                        }
                    }
                for (int i = 0; i < N_io_list.Count; i++)
                    {
                        XmlNode IO_node_1, IO_node_2, IO_node_3, IO_node_4, IO_node_5, IO_node_6;
                        XmlDocument IO = new XmlDocument();
                        IO_node_1 = IO.CreateElement("root");
                        IO_node_1.Attributes.Append(IO.CreateAttribute("format-version"));
                        IO_node_1.Attributes["format-version"].Value = "0";
                        IO_node_2 = IO.CreateElement("item");
                        IO_node_2.Attributes.Append(IO.CreateAttribute("Binding"));
                        IO_node_2.Attributes["Binding"].Value = "Introduced";
                        IO_node_4 = IO.CreateElement("node-path");
                        IO_node_5 = IO.CreateElement("address");
                        IO_node_6 = IO.CreateElement("protocoltype");
                        IO_node_2.AppendChild(IO_node_4);
                        IO_node_2.AppendChild(IO_node_5);
                        IO_node_2.AppendChild(IO_node_6);
                        // Порядок Листа: (Номер УСО;Тег сигнала;Адрес сигнала;Протокольный тип;)
                        for (int j = 0; j < io_list.Count; j++)
                        {
                            string[] str = io_list[j].ToString().Split(';');
                            if (N_io_list[i].ToString() == str[0])
                            {
                                IO_node_3 = IO_node_2.Clone();
                                IO_node_3.FirstChild.InnerText = str[1];
                                IO_node_3.FirstChild.NextSibling.InnerText = str[2];
                                IO_node_3.LastChild.InnerText = str[3];
                                IO_node_1.AppendChild(IO_node_3);
                            }
                        }
                        IO.AppendChild(IO_node_1);
                        name_XML = "\\IEC104_USO" + N_io_list[i].ToString() + ".xml";
                        if (IO.FirstChild != null)
                        {
                            string sumname_XML = path + name_XML;
                            IO.Save(sumname_XML);
                        }
                        else
                        {
                            if (checkBox_MBTCP.Checked)
                                MessageBox.Show("Ошибка создания XML IO", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (IO != null) IO.RemoveAll();
                    }
            }
        }  // Генерация простанства имен карты адресов для ИО Alppha
        private void NU_Bilding(string[] array_string, string path)
        {
            ArrayList path_list = new ArrayList();
            ArrayList folder_list = new ArrayList();
            ArrayList property_8812_arr = new ArrayList();
            ArrayList property_8819_arr = new ArrayList();
            ArrayList property_8830_arr = new ArrayList();
            ArrayList property_8836_arr = new ArrayList();
            ArrayList property_8914_arr = new ArrayList();

            // Порядок Листа: (Номер УСО;Тег сигнала;Адрес сигнала;Протокольный тип;)
            if (array_string != null)
            {
                int last_ind = 0;
                for (int i = 0; i < array_string.Length; i++)
                {
                    bool reseting = false;
                    string tag;
                    string USO;
                    if (array_string[i].Contains(",8815,"))
                    {                                                        
                        tag = array_string[i].Split(',')[0];
                        USO = tag.Split('.')[0];
                        ArrayList array_short = new ArrayList();
                        for (int j = last_ind; j < array_string.Length; j++)
                        {
                            if (array_string[j].Contains(tag+".") || array_string[j].Contains(tag + ","))
                            {
                                array_short.Add(array_string[j]);
                                last_ind++;
                            }
                        }
                        bool right = true;
                        foreach (Object obj in array_short)
                        {
                            if (obj.ToString().Contains(",8815,vt_bstr,1"))
                            {
                                right = false;
                                break;
                            }
                        }    
                        if (right)
                        {
                            foreach (Object obj in array_short)
                            {
                                if (obj.ToString().Contains(",8821,"))
                                {
                                    string temp_path = Environment.CurrentDirectory;
                                    string property_8810 = "", property_8811 = "", property_8812 = "", property_8821 = "", property_8888 = "";
                                    property_8821 = obj.ToString().Split(',')[obj.ToString().Split(',').Length-1];                                   
                                    if (File.Exists(temp_path + "\\templates\\" + property_8821 + ".xml"))
                                    {
                                        foreach (Object obj2 in array_short)
                                        {
                                            if (obj2.ToString().Contains(",8810,"))
                                                property_8810 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8811,"))
                                                property_8811 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8812,"))
                                            {
                                                property_8812 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                                foreach (Object obj8812 in property_8812_arr)
                                                {
                                                    if (obj8812.ToString().Contains(property_8812))
                                                    {
                                                        reseting = true;
                                                        break;
                                                    }
                                                }
                                                if (!reseting)
                                                    property_8812_arr.Add(property_8812);
                                            }                                         
                                            if (obj2.ToString().Contains(",8888,"))
                                                property_8888 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (reseting)
                                                break;
                                        }
                                        if (reseting)
                                            break;
                                        DirectoryInfo dir = new DirectoryInfo(path + "\\" + USO + "\\modules" + "\\Модуль "+ property_8810);                                        
                                        if (!dir.Exists)
                                        {
                                            dir.Create();
                                        }
                                        dir.CreateSubdirectory(@"Канал "+ property_8811);
                                        string newPath = path + "\\" + USO + "\\modules" + "\\Модуль " + property_8810 + "\\Канал " + property_8811 + "\\" + property_8812 + ".xml";
                                        FileInfo file_buf = new FileInfo(temp_path + "\\templates\\" + property_8821 + ".xml");
                                        file_buf.CopyTo(newPath, true);
                                        string str = string.Empty;
                                        using (StreamReader reader = File.OpenText(newPath))
                                        {
                                            str = reader.ReadToEnd();
                                        }
                                        str = str.Replace(property_8821, property_8812);                                        
                                        str = Regex.Replace(str, @"""Адрес ведомого устройства"" onlineaccess=""read"">[0-9]{3}", "\"Адрес ведомого устройства\" onlineaccess=\"read\">" + property_8888);
                                        using (StreamWriter file = new StreamWriter(newPath))
                                        {
                                            file.Write(str);
                                        }
                                        path_list.Add(newPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Прототип " + property_8821 + " не найден \nПодсчет сигналов не верен", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                                {
                                    //if (obj.ToString().Contains(",8822,"))
                                    //{
                                    //    string temp_path = Environment.CurrentDirectory;
                                    //    string property_8822 = "", property_8817 = "", property_8818 = "", property_8819 = "", property_8816 = "";
                                    //    property_8822 = obj.ToString().Split(',')[obj.ToString().Split(',').Length - 1];
                                    //    if (File.Exists(temp_path + "\\templates\\" + property_8822 + ".xml"))
                                    //    {
                                    //        foreach (Object obj2 in array_short)
                                    //        {
                                    //            if (obj2.ToString().Contains(",8817,"))
                                    //                property_8817 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                    //            if (obj2.ToString().Contains(",8818,"))
                                    //                property_8818 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                    //            if (obj2.ToString().Contains(",8819,"))
                                    //                property_8819 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                    //            if (obj2.ToString().Contains(",8816,"))
                                    //                property_8816 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];                                          
                                    //        }
                                    //        DirectoryInfo dir = new DirectoryInfo(path + "\\" + USO + "\\Модуль " + property_8817);
                                    //        if (!dir.Exists)
                                    //        {
                                    //            dir.Create();
                                    //        }
                                    //        dir.CreateSubdirectory(@"Канал " + property_8818);
                                    //        string newPath = path + "\\" + USO + "\\Модуль " + property_8817 + "\\Канал " + property_8818 + "\\" + property_8819 + ".xml";
                                    //        FileInfo file_buf = new FileInfo(temp_path + "\\templates\\" + property_8822 + ".xml");
                                    //        file_buf.CopyTo(newPath, true);
                                    //        string str = string.Empty;
                                    //        using (StreamReader reader = File.OpenText(newPath))
                                    //        {
                                    //            str = reader.ReadToEnd();
                                    //        }
                                    //        str = str.Replace(property_8822, property_8819);
                                    //        str = Regex.Replace(str, @"""Адрес ведомого устройства"" onlineaccess=""read"">[0-9]{3}", "\"Адрес ведомого устройства\" onlineaccess=\"read\">" + property_8816);                                        
                                    //        using (StreamWriter file = new StreamWriter(newPath))
                                    //        {
                                    //            file.Write(str);
                                    //        }
                                    //        path_list.Add(newPath);
                                    //    }
                                    //    else
                                    //    {
                                    //        MessageBox.Show("Прототип " + property_8822 + " не найден", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //        break;
                                    //    }
                                    //}
                                }
                                if (obj.ToString().Contains(",8822,"))
                                {
                                    string temp_path = Environment.CurrentDirectory;
                                    string property_8817 = "", property_8818 = "", property_8819 = "", property_8822 = "", property_8816 = "";
                                    property_8822 = obj.ToString().Split(',')[obj.ToString().Split(',').Length - 1];
                                    if (File.Exists(temp_path + "\\templates\\" + property_8822 + ".xml"))
                                    {
                                        foreach (Object obj2 in array_short)
                                        {
                                            if (obj2.ToString().Contains(",8817,"))
                                                property_8817 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8818,"))
                                                property_8818 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8819,"))
                                            {
                                                property_8819 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                                foreach (Object obj8819 in property_8819_arr)
                                                {
                                                    if (obj8819.ToString().Contains(property_8819))
                                                    {
                                                        reseting = true;
                                                        break;
                                                    }
                                                }
                                                if (!reseting)
                                                    property_8819_arr.Add(property_8819);
                                            }
                                            if (obj2.ToString().Contains(",8816,"))
                                                property_8816 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (reseting)
                                                break;
                                        }
                                        if (reseting)
                                            break;
                                        DirectoryInfo dir = new DirectoryInfo(path + "\\" + USO + "\\modules" + "\\Модуль " + property_8817);
                                        if (!dir.Exists)
                                        {
                                            dir.Create();
                                        }
                                        dir.CreateSubdirectory(@"Канал " + property_8818);
                                        string newPath = path + "\\" + USO + "\\modules" + "\\Модуль " + property_8817 + "\\Канал " + property_8818 + "\\" + property_8819 + ".xml";
                                        FileInfo file_buf = new FileInfo(temp_path + "\\templates\\" + property_8822 + ".xml");
                                        file_buf.CopyTo(newPath, true);
                                        string str = string.Empty;
                                        using (StreamReader reader = File.OpenText(newPath))
                                        {
                                            str = reader.ReadToEnd();
                                        }
                                        str = str.Replace(property_8822, property_8819);
                                        str = Regex.Replace(str, @"""Адрес ведомого устройства"" onlineaccess=""read"">[0-9]{3}", "\"Адрес ведомого устройства\" onlineaccess=\"read\">" + property_8816);
                                        using (StreamWriter file = new StreamWriter(newPath))
                                        {
                                            file.Write(str);
                                        }
                                        path_list.Add(newPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Прототип " + property_8822 + " не найден \nПодсчет сигналов не верен", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                                if (obj.ToString().Contains(",8832,"))
                                {
                                    string temp_path = Environment.CurrentDirectory;
                                    string property_8828 = "", property_8829 = "", property_8830 = "", property_8832 = "", property_8827 = "";
                                    property_8832 = obj.ToString().Split(',')[obj.ToString().Split(',').Length - 1];
                                    if (File.Exists(temp_path + "\\templates\\" + property_8832 + ".xml"))
                                    {
                                        foreach (Object obj2 in array_short)
                                        {
                                            if (obj2.ToString().Contains(",8828,"))
                                                property_8828 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8829,"))
                                                property_8829 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8830,"))
                                            {
                                                property_8830 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                                foreach (Object obj8830 in property_8830_arr)
                                                {
                                                    if (obj8830.ToString().Contains(property_8830))
                                                    {
                                                        reseting = true;
                                                        break;
                                                    }
                                                }
                                                if (!reseting)
                                                    property_8830_arr.Add(property_8830);
                                            }
                                            if (obj2.ToString().Contains(",8827,"))
                                                property_8827 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (reseting)
                                                break;
                                        }
                                        if (reseting)
                                            break;
                                        DirectoryInfo dir = new DirectoryInfo(path + "\\" + USO + "\\modules" + "\\Модуль " + property_8828);
                                        if (!dir.Exists)
                                        {
                                            dir.Create();
                                        }
                                        dir.CreateSubdirectory(@"Канал " + property_8829);
                                        string newPath = path + "\\" + USO + "\\modules" + "\\Модуль " + property_8828 + "\\Канал " + property_8829 + "\\" + property_8830 + ".xml";
                                        FileInfo file_buf = new FileInfo(temp_path + "\\templates\\" + property_8832 + ".xml");
                                        file_buf.CopyTo(newPath, true);
                                        string str = string.Empty;
                                        using (StreamReader reader = File.OpenText(newPath))
                                        {
                                            str = reader.ReadToEnd();
                                        }
                                        str = str.Replace(property_8832, property_8830);
                                        str = Regex.Replace(str, @"""Адрес ведомого устройства"" onlineaccess=""read"">[0-9]{3}", "\"Адрес ведомого устройства\" onlineaccess=\"read\">" + property_8827);
                                        using (StreamWriter file = new StreamWriter(newPath))
                                        {
                                            file.Write(str);
                                        }
                                        path_list.Add(newPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Прототип " + property_8832 + " не найден \nПодсчет сигналов не верен", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                                if (obj.ToString().Contains(",8838,"))
                                {
                                    string temp_path = Environment.CurrentDirectory;
                                    string property_8834 = "", property_8835 = "", property_8836 = "", property_8838 = "", property_8833 = "";
                                    property_8838 = obj.ToString().Split(',')[obj.ToString().Split(',').Length - 1];
                                    if (File.Exists(temp_path + "\\templates\\" + property_8838 + ".xml"))
                                    {
                                        foreach (Object obj2 in array_short)
                                        {
                                            if (obj2.ToString().Contains(",8834,"))
                                                property_8834 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8835,"))
                                                property_8835 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8836,"))
                                            {
                                                property_8836 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                                foreach (Object obj8836 in property_8836_arr)
                                                {
                                                    if (obj8836.ToString().Contains(property_8836))
                                                    {
                                                        reseting = true;
                                                        break;
                                                    }
                                                }
                                                if (!reseting)
                                                    property_8836_arr.Add(property_8836);
                                            }
                                            if (obj2.ToString().Contains(",8833,"))
                                                property_8833 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (reseting)
                                                break;
                                        }
                                        if (reseting)
                                            break;
                                        DirectoryInfo dir = new DirectoryInfo(path + "\\" + USO + "\\modules" + "\\Модуль " + property_8834);
                                        if (!dir.Exists)
                                        {
                                            dir.Create();
                                        }
                                        dir.CreateSubdirectory(@"Канал " + property_8835);
                                        string newPath = path + "\\" + USO + "\\modules" + "\\Модуль " + property_8834 + "\\Канал " + property_8835 + "\\" + property_8836 + ".xml";
                                        FileInfo file_buf = new FileInfo(temp_path + "\\templates\\" + property_8838 + ".xml");
                                        file_buf.CopyTo(newPath, true);
                                        string str = string.Empty;
                                        using (StreamReader reader = File.OpenText(newPath))
                                        {
                                            str = reader.ReadToEnd();
                                        }
                                        str = str.Replace(property_8838, property_8836);
                                        str = Regex.Replace(str, @"""Адрес ведомого устройства"" onlineaccess=""read"">[0-9]{3}", "\"Адрес ведомого устройства\" onlineaccess=\"read\">" + property_8833);
                                        using (StreamWriter file = new StreamWriter(newPath))
                                        {
                                            file.Write(str);
                                        }
                                        path_list.Add(newPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Прототип " + property_8838 + " не найден \nПодсчет сигналов не верен", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                                if (obj.ToString().Contains(",8916,"))
                                {
                                    string temp_path = Environment.CurrentDirectory;
                                    string property_8912 = "", property_8913 = "", property_8914 = "", property_8916 = "", property_8911 = "";
                                    property_8916 = obj.ToString().Split(',')[obj.ToString().Split(',').Length - 1];
                                    if (File.Exists(temp_path + "\\templates\\" + property_8916 + ".xml"))
                                    {
                                        foreach (Object obj2 in array_short)
                                        {
                                            if (obj2.ToString().Contains(",8912,"))
                                                property_8912 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8913,"))
                                                property_8913 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (obj2.ToString().Contains(",8914,"))
                                            {
                                                property_8914 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                                foreach (Object obj8914 in property_8914_arr)
                                                {
                                                    if (obj8914.ToString().Contains(property_8914))
                                                    {
                                                        reseting = true;
                                                        break;
                                                    }
                                                }
                                                if (!reseting)
                                                    property_8914_arr.Add(property_8914);
                                            }
                                            if (obj2.ToString().Contains(",8911,"))
                                                property_8911 = obj2.ToString().Split(',')[obj2.ToString().Split(',').Length - 1];
                                            if (reseting)
                                                break;
                                        }
                                        if (reseting)
                                            break;
                                        DirectoryInfo dir = new DirectoryInfo(path + "\\" + USO + "\\modules" + "\\Модуль " + property_8912);
                                        if (!dir.Exists)
                                        {
                                            dir.Create();
                                        }
                                        dir.CreateSubdirectory(@"Канал " + property_8913);
                                        string newPath = path + "\\" + USO + "\\modules" + "\\Модуль " + property_8912 + "\\Канал " + property_8913 + "\\" + property_8914 + ".xml";
                                        FileInfo file_buf = new FileInfo(temp_path + "\\templates\\" + property_8916 + ".xml");
                                        file_buf.CopyTo(newPath, true);
                                        string str = string.Empty;
                                        using (StreamReader reader = File.OpenText(newPath))
                                        {
                                            str = reader.ReadToEnd();
                                        }
                                        str = str.Replace(property_8916, property_8914);
                                        str = Regex.Replace(str, @"""Адрес ведомого устройства"" onlineaccess=""read"">[0-9]{3}", "\"Адрес ведомого устройства\" onlineaccess=\"read\">" + property_8911);
                                        using (StreamWriter file = new StreamWriter(newPath))
                                        {
                                            file.Write(str);
                                        }
                                        path_list.Add(newPath);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Прототип " + property_8916 + " не найден \nПодсчет сигналов не верен", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        break;
                                    }
                                }
                            }
                        }
                    } 
                }
                for (int i = 0; i < path_list.Count; i++)
                {
                    string  dev, module, kanal, patch_main;
                    dev = path_list[i].ToString().Split('\\')[path_list[i].ToString().Split('\\').Length - 1];
                    kanal = path_list[i].ToString().Split('\\')[path_list[i].ToString().Split('\\').Length - 2];
                    module = path_list[i].ToString().Split('\\')[path_list[i].ToString().Split('\\').Length - 3];                    
                    patch_main = path_list[i].ToString().Replace(dev, "");
                    if (!folder_list.Contains(patch_main)) folder_list.Add(patch_main);                    
                }
                for (int i = 0; i < folder_list.Count; i++)
                {
                    XmlDocument DEV = new XmlDocument();
                    DEV.LoadXml(Properties.Resources.DEV_SHB);
                    for (int j = 0, ID = 1; j < path_list.Count; j++, ID++)
                    {                        
                        if (path_list[j].ToString().Contains(folder_list[i].ToString()))
                        {
                            string sID;
                            int k = ID % 10;
                            sID = k.ToString();
                            k = ID / 10 % 10;
                            sID = k.ToString() + sID;
                            k = ID / 10 % 10;
                            sID = k.ToString() + sID;
                            sID = "aee2fe06-f677-434c-8c3d-69670ehui" + sID;
                            XmlDocument DEV_buf = new XmlDocument();
                            XmlNode Node_buf;
                            DEV_buf.Load(path_list[j].ToString());
                            DEV_buf.GetElementsByTagName("ObjectId")[0].InnerText = sID;
                            DEV.GetElementsByTagName("configurations")[0].AppendChild(DEV.ImportNode(DEV_buf.GetElementsByTagName("configuration")[0],true));
                            Node_buf = DEV.CreateElement("Object");
                            Node_buf.Attributes.Append(DEV.CreateAttribute("Name"));
                            Node_buf.Attributes.Append(DEV.CreateAttribute("ObjectId"));
                            Node_buf.Attributes["Name"].Value = DEV_buf.GetElementsByTagName("configuration")[0].Attributes["name"].Value;
                            Node_buf.Attributes["ObjectId"].Value = sID;
                            DEV.GetElementsByTagName("ProjectStructure")[0].AppendChild(Node_buf);
                            XmlNodeList Version1 = DEV.GetElementsByTagName("Version");
                            foreach (XmlElement Version2 in Version1)
                            {
                                Version2.InnerText = textBox_version.Text;
                            }
                            XmlNodeList isOS = DEV.GetElementsByTagName("Type");
                            foreach (XmlElement isOS2 in isOS)
                            {
                                if (checkBox_MB_OS.Checked)
                                {
                                    isOS2.InnerText = "50096";
                                }
                                else
                                {
                                    isOS2.InnerText = "40096";
                                }
                            }
                            if (checkBox_MBS_RTU_2.Checked)
                                File.Delete(path_list[j].ToString());
                        }                        
                    }
                    if (DEV.FirstChild != null)
                    {
                        DEV.Save(folder_list[i].ToString()+"DEV_ALL.XML");
                    }
                }             
            }
            
        }    // Генерация простанства имен карты адресов для ModBus НУ

        async void   Main_Soft(object sender, EventArgs e)
        {                     
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            button3.Enabled = false;
            openFileDialog1.Filter = "XML files (*.xml)|*.xml";
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите ЭЛСИ-ТМК_Application.xml";
            openFileDialog1.Multiselect = true;
            ArrayList list_triggers = new ArrayList();
            DialogResult dialogResult = MessageBox.Show("Выберите ЭЛСИ-ТМК.xml и ЭЛСИ-ТМК_Application.xml,\nкоторые формируются из ACS кнопкой \"Экспорт ПО\"", "Создание ПО", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);           
            if (dialogResult == DialogResult.OK)
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string name_application;
                    string name_apr;
                    string[] readText;
                    string[] names_XML;

                    if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                    {
                        path = folderBrowserDialog1.SelectedPath;
                        names_XML = openFileDialog1.FileNames;
                        TextBox_apr.Text = "";
                        TextBox_apllication.Text = "";
                        //IProgress<int> progress1 = new Progress<int>((p) => progressBar1.Value = p);
                        //Thread thread_Progressbar = new Thread(Thread_Progressbar);
                        //thread_Progressbar.Start(progress1);
                        //timer1.Interval = 50;
                        //timer1.Start();
                        //uptime.Start();
                        foreach (string name_XML in names_XML)
                        {
                            name_application = name_XML;
                            short_name_application = name_application.Split('\\')[name_application.Split('\\').Length - 1];
                            name_apr = name_application.Replace("_application", "");
                            short_name_apr = short_name_application.Replace("_application", "");
                            DirectoryInfo dirInfo = new DirectoryInfo(path + "\\" + short_name_apr.Replace(".xml", ""));
                            if (!dirInfo.Exists)
                            {
                                dirInfo.Create();
                            }
                            readText = File.ReadAllLines(name_application);
                            if (readText != null)
                            {
                                Search_triggers(readText);
                                File.WriteAllLines(name_application, readText);
                                readText = null;
                            }
                            else
                            {
                                MessageBox.Show("XML Application оказался пустым", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            if (name_application.Contains("application"))
                            {
                                Application_IN.Load(name_application);
                                TextBox_apllication.Text = TextBox_apllication.Text + short_name_application + "\n";
                                TextBox_apllication.BackColor = Color.Green;
                                if (File.Exists(name_apr))
                                {
                                    APR_Corrected.Load(name_apr);
                                    TextBox_apr.Text = TextBox_apr.Text + short_name_apr + "\n";
                                    TextBox_apr.BackColor = Color.Green;
                                }
                                else
                                {
                                    TextBox_apr.Text = TextBox_apr.Text + short_name_apr;
                                    TextBox_apr.BackColor = Color.Red;
                                    MessageBox.Show("Отсутствует файл apr-а", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    break;
                                }
                            }
                            else
                            {
                                TextBox_apllication.Text = TextBox_apllication.Text + short_name_application;
                                TextBox_apllication.BackColor = Color.Red;
                                MessageBox.Show("Название файла не содержит \"application\"", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                            if (APR_Corrected.FirstChild != null)
                            {
                                XML.LoadXml(Properties.Resources.Application_SHB);  //Подгрузка ресурса-шаблона XML
                                GVL.LoadXml(Properties.Resources.GVL_SHB);                  //Подгрузка ресурса-шаблона XML
                                if (GVL.FirstChild != null & APR_Corrected.FirstChild != null)
                                {
                                    if (Application_IN.FirstChild != null)
                                    {
                                        var task0 = Task.Run(Task_ModBus_TCP);
                                        await Task.WhenAll(task0);
                                        var task1 = Task.Run(Task_Iec104);
                                        var task2 = Task.Run(Task_Application);
                                        await Task.WhenAll(task1, task2);
                                    }
                                    if (GVL != null) GVL.RemoveAll();
                                    if (XML != null) XML.RemoveAll();
                                    if (Application_IN != null) Application_IN.RemoveAll();
                                    if (APR != null) APR.RemoveAll();
                                    if (APR_Corrected != null) APR_Corrected.RemoveAll();
                                    if (REGUL_ModBus_TCP != null) REGUL_ModBus_TCP.RemoveAll();
                                    if (REGUL_IEC_DATA != null) REGUL_IEC_DATA.RemoveAll();
                                    if (REGUL_IEC_CMD != null) REGUL_IEC_CMD.RemoveAll();
                                }
                            }
                            else
                            {
                                MessageBox.Show("XML APR оказался пустым", "Ошибка файла", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                break;
                            }
                        }
                        timer1.Stop();
                        //uptime.Reset();
                        //uptime.Stop();
                        MessageBox.Show("Генерация завершена", "Отчет о готовности ПО", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }         
            {
                TextBox_apr.BackColor = Color.FromArgb(255, 200, 200, 200);
                TextBox_apllication.BackColor = Color.FromArgb(255, 200, 200, 200);
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button3.Enabled = true;
                //progressBar1.Visible = false;
            }                 
        }       
        private void Main_IO(object sender, EventArgs e)
        {
            int[] number_sum = { 0, 0, 0, 0 };
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            button3.Enabled = false;
            string[] names, readText;
            MessageBox.Show("Выберите все CSV для формирования карты адресов", "Экспорт ИО", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            openFileDialog1.Multiselect = true;            
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv"; //|XML files (*.xml)|*.xml;
            openFileDialog1.FileName = "";
            openFileDialog1.Title = "Выберите CSV";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox_TI.Text = "";       textBox_TU.Text = "";       textBox_TS.Text = "";       textBox_TR.Text = "";
                textBox_TI_sum.Text = "";   textBox_TU_sum.Text = "";   textBox_TS_sum.Text = "";   textBox_TR_sum.Text = "";
                names = openFileDialog1.FileNames;
                TextBox3.Text = "";
                for (int i = 0; i < names.Length; i++)
                {
                    TextBox3.Text = TextBox3.Text + names[i].Split('\\')[names[i].Split('\\').Length - 1] + "\n";
                }
                TextBox3.BackColor = Color.Green;

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    foreach (string name in names)
                    {
                        readText = File.ReadAllLines(name);
                        if (readText != null)
                        {
                            if (checkBox_IO.Checked) IO_Bilding_1(readText, folderBrowserDialog1.SelectedPath);
                            if (checkBox_MBS_RTU_1.Checked) NU_Bilding(readText, folderBrowserDialog1.SelectedPath);
                            Calc_Point(readText, number_sum);
                        }
                    }
                    textBox_TS_sum.Text = number_sum[0].ToString();
                    textBox_TU_sum.Text = number_sum[1].ToString();
                    textBox_TR_sum.Text = number_sum[2].ToString();
                    textBox_TI_sum.Text = number_sum[3].ToString();                                                    
                    MessageBox.Show("Генерация завершена", "Отчет о выполнении", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            {
                TextBox3.BackColor = Color.FromArgb(255, 200, 200, 200);
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                button3.Enabled = true;
                //progressBar1.Visible = false;
            }
        }     
    }
}
