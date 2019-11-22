using Microsoft.VisualBasic;
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
    public partial class LoginPage : Form
    {
        String username = "";
        String password = "";

        public LoginPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

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
            username = textBox1.Text;//Obtained id pass
            password = textBox2.Text;

            textBox1.Text = "";//empty the text box
            textBox2.Text = "";

            if (username == "" || password == "") {//if empty input
                MessageBox.Show("Please enter username and password", "Empty field");
                return;
            }


            /*
                connect api and check for username and pass in the database, If user present then proceed else show invalid pass   
            */

            //Will obtain from api
            user.userId = "Manan";//hardcoded id pass
            user.pass = "Manan";
            user.name = "Manan";

            if (username.Contains(user.userId) && password.Contains(user.pass))//if user authenticated
            {
                //obtain the free time and categories
                new Select().Show();
            }
            else {
                MessageBox.Show("Invalid Username or password");
            }
            
        }

        private void Label3_Click_1(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)//signup button
        {
            new SignUp().Show();
        }

        private void LoginPage_FormClosing(object sender, FormClosingEventArgs e)//cross button
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
