using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhatsAppApi;

namespace WhatsAppTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string from = "919540545484";
            string to = textBox1.Text;
            string message = richTextBox1.Text;
            //pass= 8jmNEWtk5f4XLUuTXCINwc+P5mak=,8jmNEWtk5f4XLUuTXCINwc+P5mk=
            WhatsApp wa = new WhatsApp(from, "8jmNEWtk5f4XLUuTXCINwc+P5mk=","Kundan",false,false);

            wa.OnConnectSuccess += () => 
            {
                richTextBox2.AppendText("\nConnected To WA...");
                wa.OnLoginSuccess += (phoneNumber, Data) =>
                 {
                     wa.SendMessage(to, message);
                     richTextBox2.AppendText("\nMessage sent...");
                     MessageBox.Show("Message sent...");

                 };

                wa.OnLoginFailed += (data) =>
                {
                    richTextBox2.AppendText("\nLogin Failed "+data+"...");
                    MessageBox.Show("Login Failed {1}...",data);

                };
                wa.Login();

            };

            wa.OnConnectFailed += (ex) =>
              {
                  richTextBox2.AppendText("\nConnection Failed...");
                  MessageBox.Show("Connection Failed...");

              };
            wa.Connect();
        }
    }
}
