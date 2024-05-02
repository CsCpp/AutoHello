//using Microsoft.Win32;
using Microsoft.Win32;
using System.Reflection;

namespace AutoHello
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
          var result=  MessageBox.Show("Запускать меня при старте ПК?", "Hello", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk); 
        if (result == DialogResult.Yes) 
            {
                SetAutoRunValue(true, Application.ExecutablePath);
                Application.Exit();
            }
        else if(result == DialogResult.No) 
            {
                SetAutoRunValue(false, Application.ExecutablePath);
                Application.Exit();
            }
        else
            {
                Application.Exit();
            }
        }
        private bool SetAutoRunValue(bool autorun, string path)
        {
            const string name = "PrivetMir";
            string ExePath = path;
            RegistryKey reg;
          
                reg=Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run\\");
            try
            {
                if (autorun)
                {
                    reg.SetValue(name, ExePath);
                }
                else
                {
                    reg.DeleteValue(name);
                }

                reg.Flush();
                reg.Close();
            }

            catch (Exception)
            {
                return false;
            }

                return true;

        }

    }
}
