using System.Diagnostics;
using TaskManager.Enums;
using TaskManager.User_Controls;

namespace TaskManager
{
    public partial class Form1 : Form
    {
        Tab currentTab = Tab.Processes;
        List<string> blackList = new List<string>();

        public Form1()
        {
            InitializeComponent();
            FillProcesses();
        }

        private void FillProcesses()
        {
            foreach (var item in Process.GetProcesses())
            {
                listBox2.Items.Add(item.Id);
                listBox1.Items.Add(item.ProcessName);
                listBox3.Items.Add(item.MachineName);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedProcesses = Process.GetProcessesByName(listBox1.SelectedItem.ToString()).ToList();

                foreach (var item in selectedProcesses)
                {
                    item.Kill();
                    listBox1.Items.Remove(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unexpected error!");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (blackList.Contains(textBox1.Text) == false)
            {
                Process.Start(textBox1.Text);
                textBox1.Text = string.Empty;
                return;
            }
            MessageBox.Show("BLACK LIST ITEM!");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (currentTab == Tab.Processes)
            {
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                listBox3.Items.Clear();

                FillProcesses();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PerformanceView? performanceView = new();
            panel2.Controls.Add(performanceView);
            performanceView.BringToFront();
            currentTab = Tab.Performance;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            BlackListView? blackListView = new BlackListView(blackList);
            panel2.Controls.Add(blackListView);
            blackListView.BringToFront();
            currentTab = Tab.BlackList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != string.Empty)
            {
                blackList.Add(textBox1.Text);
                return; 
            }

            blackList.Add(listBox1.SelectedItem.ToString());
            MessageBox.Show("Process Added To BlackList!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}