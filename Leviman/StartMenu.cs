using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leviman
{
    public partial class StartMenu : Form
    {
        
        public StartMenu()
        {
            InitializeComponent();
           
        }

        private void StartMenu_Load(object sender, EventArgs e)
        {
            
            
            
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void Button1_Click(object sender, EventArgs e)
        {
            Form secondForm = new Form1();

            // Set the title of the form.
            secondForm.Text = "Leviman Edgerunners 0.8";

            Hide();
            // Show the form.
            secondForm.Show();

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //the "Are you sure you wanna quit?" box when you hit Quit.

            DialogResult result = MessageBox.Show("Are you sure you want to quit?", "Leave Game", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
