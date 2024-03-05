using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WordleSolver.views;

namespace WordleSolver.views
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Program.SwitchView(new Views.RandomWordView());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.SwitchView(new Views.PartialGameView());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Program.CloseApplication();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.SwitchView(new Views.HistoryView());
        }
    }
}
