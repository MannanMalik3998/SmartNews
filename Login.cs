using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            user.nameUser = username;

            textBox1.Text = "";//empty the text box
            textBox2.Text = "";

            if (username == "" || password == "") {//if empty input
                MessageBox.Show("Please enter username and password", "Empty field");
                return;
            }


            //*******************************************************************************************************************************
            #region Authenticate user from API
            bool chk = false;
            try
            {
             
                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                String strResponseValue = "";
 
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(user.url+"api/SmartNews");
                webRequest.Method = "GET";
                webRequest.Headers.Add("Authorization", "Basic " + System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(username + ":" + password)));
                //webRequest.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password)));

                HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                using (Stream responseStream = response.GetResponseStream())
                {
                    if (responseStream != null)
                    {
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            strResponseValue = reader.ReadToEnd();
                        }
                    }
                }
                if (strResponseValue.Contains("UserFound"))
                {
                    MessageBox.Show("Approved","Validated");
                    chk = true;
                }
#endregion
                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&



                if (chk)
                {//validated user
                 
                    user.name = "Manan";
                    //obtain the free time and categories
                    new Select().Show();
                }
                else
                {
                    MessageBox.Show("Invalid Username or password");
                }
            }
            catch (Exception y) {
                MessageBox.Show(y.Message,"Error");
            }

            //*******************************************************************************************************************************

            #region Hard Coded form validation
            /*
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
            */
            #endregion
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

        private void Button3_Click(object sender, EventArgs e)
        {
            user.nameUser="";
            //user.cat;
            //obtain the free time and categories
            new Select().Show();

        }
    }
}
