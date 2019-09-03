using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Web;
using System.Collections.Specialized;
using System.Security.Principal;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Net.Sockets;
using Memory;//External reference
using System.Runtime.InteropServices;
using System.Globalization;




namespace PatchDataTime


{

    public struct SYSTEMTIME
    {
        public short wYear;
        public short wMonth;
        public short wDayOfWeek;
        public short wDay;
        public short wHour;
        public short wMinute;
        public short wSecond;
        public short wMilliseconds;

        //
        
        
    }

    

    public partial class Form1 : Form
    {
        [DllImport("coredll.dll")]
        private extern static void GetSystemTime(ref SYSTEMTIME lpSystemTime);

       

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

       



       

        public Form1()
        {
            InitializeComponent();

            timer1.Start();


        }

        public Mem m = new Mem();

        

        private void Form1_Load(object sender, EventArgs e)

        {
           
            // do something when Form Start
        }


        

      

        private void button1_Click(object sender, EventArgs e)
        {            


            short a = Convert.ToInt16(textBox9.Text);
             a--;
            
            
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = Convert.ToInt16(textBox6.Text); // must be short
            st.wMonth = Convert.ToInt16(textBox5.Text);
            st.wDay = Convert.ToInt16(textBox4.Text);
            st.wHour = a;
            st.wMinute = Convert.ToInt16(textBox8.Text);
            st.wSecond = Convert.ToInt16(textBox7.Text);

            SetSystemTime(ref st); // invoke this method.
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
            var response = myHttpWebRequest.GetResponse();
            string todaysDates = response.Headers["date"];
            DateTime dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
            //textBox2.Text = dateTime.ToString();
            response.Close();

        }


        private void button3_Click(object sender, EventArgs e)
        {
            float a;
            float m;
            float g;

            a = float.Parse(textBox4.Text);
            m = float.Parse(textBox5.Text);
            g = float.Parse(textBox6.Text);
           // textBox3.Text = string.Concat(a, "/", m, "/", g);
        }

        private void TrueDataTime()
            {

            
                var myHttpWebRequest = (HttpWebRequest)WebRequest.Create("http://www.microsoft.com");
                var response = myHttpWebRequest.GetResponse();
                string todaysDates = response.Headers["date"];
                DateTime dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'", CultureInfo.InvariantCulture.DateTimeFormat, DateTimeStyles.AssumeUniversal);
            label5.ForeColor = Color.YellowGreen;
            label5.Text = dateTime.ToString();
            response.Close();
                   }

        private void timer1_Tick(object sender, EventArgs e)
        {  
            TrueDataTime();
        }
    }
    }
