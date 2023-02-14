using System.Configuration;
using System.Diagnostics;

namespace TaskManager_SysProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            FindProcesses();
        }


        private void FindProcesses()
        {
            foreach (var item in Process.GetProcesses())
            {
                listBox1.Items.Add(item.ProcessName);
            }
        }

    }
}