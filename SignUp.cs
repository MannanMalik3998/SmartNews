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
    public partial class SignUp : Form
    {
        String username = "";
        String password= "";
        String name = "";
        public SignUp()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            name = textBox3.Text;
            username = textBox1.Text;
            password = textBox2.Text;

            if ((name == ""|| username == ""|| password == "")) {//Ensures non empty input
                MessageBox.Show("Please enter Name, username and password","Empty field");
                this.Close();
                new SignUp().Show();
                return;
            }

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            user.name = name;
            user.userId = username;
            user.pass = password;
            /*
             Insert into database
             */
            MessageBox.Show("You will be displayed a sample article. Kindly read it completely" +
                " in your normal reading speed. Once you have read it completely, press the Continue button","Note");
            new TimeToRead().Show();
            //this.Hide();
            this.Close();
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void SignUp_FormClosing(object sender, FormClosingEventArgs e)
        {
           // this.Close();
            return;
            //new LoginPage().Show();
            
        }
    }
}
