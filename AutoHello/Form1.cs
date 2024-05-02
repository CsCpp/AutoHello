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
            SetAutoRunValue(true, Assembly.GetExecutingAssembly().Location);
            MessageBox.Show("Это автоматическое сообщение", "Hello", MessageBoxButtons.OK,MessageBoxIcon.Asterisk); 
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
