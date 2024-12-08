using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prismProject
{
    public partial class clientHelpSimulation : Form
    {
        private string getOption;
        public clientHelpSimulation(string optionGot)
        {
            InitializeComponent();
            this.getOption = optionGot;
        }
        // simulate connecting to pc and resolving the issues
        private void clientHelpSimulation_Load(object sender, EventArgs e)
        {

            this.lblStatus.Text = "Connecting to Employee PC...";
            this.progressBar1.Value = 0;
            this.progressBar1.Maximum = 100;

            timer1 = new Timer();
            timer1.Interval = 150;
            timer1.Tick += new EventHandler(Timer_Tick);
            timer1.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value < this.progressBar1.Maximum)
            {
                this.progressBar1.Value += 5; 
                this.lblStatus.Text = $"Progress: {this.progressBar1.Value}%";
            }
            else
            {
                timer1.Stop();
                this.lblStatus.Text = "Finished!";
                MessageBox.Show($"{getOption} Complete!");
                this.Close();
            }
        }
    }
}
