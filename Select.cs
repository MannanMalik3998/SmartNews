using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class Select : Form
    {
        public Select()
        {
            InitializeComponent();
        }

        private void Select_FormClosing(object sender, FormClosingEventArgs e)
        {
            //user.userId = "";//if closed, the user details are erased
            user.pass = "";
            user.cat = "";
            user.name = "";
            user.freeTime = 0;

            return;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            user.freeTime = int.Parse(comboBox1.Text);//free time specified
            user.cat = comboBox2.Text;//category specified

            new MainScreen().Show();
            this.Close();
        }
    }
}
