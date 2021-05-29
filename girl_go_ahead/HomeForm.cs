using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace girl_go_ahead
{
    public partial class HomeForm : Form
    {
        public HomeForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OpenFirst_Click(object sender, EventArgs e)
        {
            HomeForm Var = this;
            this.Hide();
            Form1 form2 = new Form1();
            form2.Show();

        }

        private void LoadL1_Click(object sender, EventArgs e)
        {
            HomeForm Var = this;
            this.Hide();
            Form1 form2 = new Form1();
            form2.load = true;
            form2.Show();
        }
    }
}
