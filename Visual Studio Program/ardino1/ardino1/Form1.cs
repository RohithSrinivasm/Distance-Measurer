using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IOT_Library;
using System.Data.SqlClient;
using System.Configuration;
namespace ardino1
{
    public partial class Form1 : Form
    {
        System.Timers.Timer t;
        int dist = 0;
        int m = 0, n = 0;
        private System.Timers.ElapsedEventHandler OnTimeEventt;
        public Form1()
        {
            InitializeComponent();
            serialPort1.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            t = new System.Timers.Timer();
            t.Interval = 1000;
            t.Elapsed += OnTimeEvent;
        }
        private void OnTimeEvent(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                textBox1.Text = string.Format("{0}:{1}:{2}", dist.ToString().PadLeft(2, '0'), m.ToString().PadLeft(2, '0'), n.ToString().PadLeft(2, '0'));
            }));
        }
        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {

            // System.Diagnostics.Debug.WriteLine(a);
            
            SqlConnection con = new SqlConnection(@"Data Source=PC-PC\SQLEXPRESS ; Integrated Security = true; Initial Catalog = master");
            con.Open();
             
            for (int i = 0; i < 3; i++)
             {
                 string a =serialPort1.ReadLine() ;
                 dist = Convert.ToInt32(a); 

                 SqlCommand cmd = new SqlCommand(@"insert into aaardx values('"+ a +"')", con);
                 cmd.ExecuteNonQuery();
             }

            con.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            t.Stop();
        }





       
    }
}
