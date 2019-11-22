using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinApp
{
    public partial class TimeToRead : Form
    {
        Stopwatch stopWatch = new Stopwatch();
        String timeToRead;
        String timePerWord;
        public TimeToRead()
        {
            InitializeComponent();
            
            stopWatch.Start();
            
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            timeToRead = (stopWatch.ElapsedMilliseconds).ToString();
            timePerWord = ((stopWatch.ElapsedMilliseconds) / 233).ToString();//time per word in miliseconds

            MessageBox.Show("You took "+timeToRead+" miliseconds to read the above article i.e "+timePerWord+" miliseconds per word on average", "Time taken to read");

            //MessageBox.Show(user.name+"\n"+user.userId+"\n"+ timePerWord, "SignedUp");


            /* 
             //Insert details in database
                user.name
                user.userId
                user.pass
             
             */



            this.Close();
            return;
        }

        private void TimeToRead_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }
    }
}
