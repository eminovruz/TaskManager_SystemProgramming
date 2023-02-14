using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager.User_Controls
{
    public partial class BlackListView : UserControl
    {
        List<Process> processes = new List<Process>();
        public BlackListView(List<string> blackList)
        {
            InitializeComponent();
            listBox1.DataSource = blackList;

            processes = Process.GetProcesses().ToList();
        }


        private void CloseBlackListItems()
        {
            foreach (var item in processes)
            {
                if (listBox1.Items.Contains(item.ProcessName))
                {
                    item.Kill();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
            => listBox1.Items.Remove(listBox1.SelectedItem);

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
