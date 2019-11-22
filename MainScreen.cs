using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class MainScreen : Form
    {
        //Stopwatch stopWatch = new Stopwatch();
        Timer timer1 = new Timer();
        
        public MainScreen()
        {
            InitializeComponent();

            label1.Text = "User: " + user.userId;
            label2.Text = "Category: "+user.cat;

            displayNews(user.cat,user.freeTime);

            timer1.Interval = user.freeTime * 60 * 1000;//converting to milliseconds
            
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);
            
        }

        public void displayNews(string category, int freeTime) {
            try
            {
                //this api will be replaced
                var url = "https://newsapi.org/v2/top-headlines?" +
                           "country=us&" +
                          //"q=trump&" +
                          "category="+category +"&" +
                          "apiKey=cc42647f4d544c518ec402db610f2833";

                var json = new WebClient().DownloadString(url);

                richTextBox1.Text = json;
            }
            catch (Exception)
            {
                richTextBox1.Text = "Api Not working";
            }
        }
        public  void OnTimerEvent(object source, EventArgs e)//user entered time passed
        {
            MessageBox.Show("Time has passed","Time Passed");
           timer1.Enabled = false;
        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void SignOut_Click(object sender, EventArgs e)
        {
            user.userId = "";//if signed out, the user details are erased
            user.pass = "";
            user.cat = "";
            user.name = "";
            user.freeTime = 0;
            timer1.Enabled = false;
            this.Close();
            return;//signout will return back to login screen
        }

        private void MainScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            //user.userId = "";//if closed, the user details are erased
            user.pass = "";
            user.cat = "";
            user.name = "";
            user.freeTime = 0;
            timer1.Enabled = false;
            return;//back to login screen
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            user.freeTime = 0;
            user.cat = "";
            timer1.Enabled = false;
            this.Close();//User wants to read more news of same or different category
            new Select().Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
