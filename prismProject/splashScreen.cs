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

    public partial class splashScreen : Form
    {
        public splashScreen()
        {
            InitializeComponent();
        }

        private void tmrSplash_Tick_1(object sender, EventArgs e)
        {
            loginScreen f = new loginScreen();
            tmrSplash.Stop();
            f.Show();
            this.Hide();
        }
    }
}
