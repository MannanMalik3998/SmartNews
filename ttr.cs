using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        HttpClient client = new HttpClient();//remove if wrong
        private void Button1_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            timeToRead = (stopWatch.ElapsedMilliseconds).ToString();
            timePerWord = ((stopWatch.ElapsedMilliseconds) / 233).ToString();//time per word in miliseconds

            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
            #region Post APi

            input inp = new input();
            inp.EmailAddress = user.name;//email
            inp.Password = user.pass;//password
            inp.UserName = user.userId;//username
            inp.TimeTakenForReading = 2.0;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://3dbdf7b4.ngrok.io/api/SmartNews");
            request.Method = "POST";
            request.Credentials = CredentialCache.DefaultCredentials;
            ((HttpWebRequest)request).UserAgent =
                              "Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 7.1; Trident/5.0)";
            request.Accept = "/";
            request.UseDefaultCredentials = true;
            request.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
            request.ContentType = "application/json";
            
            byte[] byteArray = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(inp));
            request.ContentLength = byteArray.Length;

            Stream dataStream = request.GetRequestStream();
            dataStream.Write(byteArray, 0, byteArray.Length);
            dataStream.Close();
            string responseFromServer = "";
            WebResponse response = request.GetResponse();
            dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            responseFromServer = reader.ReadToEnd();
            reader.Close();
            dataStream.Close();
            response.Close();
            MessageBox.Show(responseFromServer, "Response");
            #endregion

            //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&


            MessageBox.Show("You took "+timeToRead+" miliseconds to read the above article i.e "+timePerWord+" miliseconds per word on average", "Time taken to read");



            //erase user.cs data
            user.freeTime = 0;
            user.name = "";
            user.pass = "";
            user.cat = "";
            user.userId = "";
            this.Close();
            return;
        }

        private void TimeToRead_FormClosing(object sender, FormClosingEventArgs e)
        {
            return;
        }
    }

    public class input
    {
        public string UserName;
        public string Password;
        public string EmailAddress;
        public double TimeTakenForReading;
    }
}
