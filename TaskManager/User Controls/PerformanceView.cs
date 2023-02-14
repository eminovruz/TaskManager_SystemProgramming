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
    public partial class PerformanceView : UserControl
    {
        List<Process> Processes = new List<Process>();
        private int threadCount = 0;

        public PerformanceView()
        {
            InitializeComponent();
            Processes = Process.GetProcesses().ToList();
        }

        private void button1_Click(object sender, EventArgs e)
            => this.Dispose();

        private void PerformanceView_Load(object sender, EventArgs e)
        {
            foreach (var item in Processes)
            {
                threadCount += item.Threads.Count;
            }
            textBox1.Text = threadCount.ToString();
            textBox2.Text = Processes.Count.ToString();
            textBox3.Text = Processes[0].MachineName;
        }
    }
}
