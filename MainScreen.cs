using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
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

            label1.Text = "User: " + user.nameUser;
            label2.Text = "Category: "+user.cat;

            displayNews(user.cat,user.freeTime);

            timer1.Interval = user.freeTime * 60 * 1000;//converting to milliseconds
            
            timer1.Enabled = true;
            timer1.Tick += new System.EventHandler(OnTimerEvent);
            
        }

        public void displayNews(string category, int freeTime) {
            try
            {
                string neaNews = "";
                string news = "";

                //&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&
                try
                {
                    #region Fetch news
                    input2 inp = new input2();
                    inp.category = category;
                    inp.freeTime = freeTime;
                    inp.EmailAddress = user.nameUser;
                    //MessageBox.Show(inp.EmailAddress,"Email");

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(user.url + "api/FetchNews");
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
                    
                    var newsObj = JsonConvert.DeserializeObject<object>(responseFromServer);
                    reader.Close();
                    dataStream.Close();
                    response.Close();
                    news = responseFromServer;
                    neaNews = newsObj.ToString();

                    string[] neaNewsArray = neaNews.Split('}');

                    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||
                    string show2 = "";

                    for (int i = 0; i < neaNewsArray.Length ; i++)//-1 tha yahan
                    {
                        if (i > 0)
                        {
                            neaNewsArray[i] = neaNewsArray[i].Replace(",{", "{");
                        }

                        neaNewsArray[i] = neaNewsArray[i].Insert((neaNewsArray[i].Length), "}");
                        //Console.WriteLine(neaNewsArray[i]);
                    }

                    List<JObject> JObjectList = new List<JObject>();

                    for (int i = 0; i < neaNewsArray.Length - 1; i++)
                    {
                        JObject jobject = JObject.Parse(neaNewsArray[i]);
                        JObjectList.Add(jobject);
                    }
                    int c = 1;
                    foreach (var newss in JObjectList)
                    {
                        
                        //"Url:\t" + newss["ImageInNews"]
                        show2 += "News: \t" + newss["NewsID"] + "\n" + "Source:\t" + newss["Source"] + "\n" + "Title:\t" + newss["NewsTitle"]
                     + "\nDescription:\t" + newss["NewsDescription"] +"\nPublish Date:\t" + newss["PublishedDate"]
                     + "\n" + "\n***************************************************************\n";
                    }
                    neaNews = show2;

                    //|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||

                    #endregion
                }
                catch (Exception e) {
                    MessageBox.Show("Not responding\n\n"+e.Message, "Response from api");
                }
                
                richTextBox1.Text = neaNews;
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
            user.nameUser = "";
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
            //user.nameUser = "";

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
    public class input2
    {
        public double freeTime;
        public string category;
        public string EmailAddress;
    }
    public class news
    {
        public int NewsID;
        public string NewsTitle;
        public string Source;
        public string NewsDescription;
        public string Genre;
        public string PublishedDate;
        public string ImageInNews;


    }
}
