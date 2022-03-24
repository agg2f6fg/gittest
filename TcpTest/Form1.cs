using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace TcpTest
{
    public partial class Form1 : Form
    {
        private event EventHandler OnRecieveData;

        private TcpClient m_Client;
        private NetworkStream stream;
        private string m_IP;
        private string m_Port;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            m_IP = textIP.Text;
            m_Port = textPort.Text;
            m_Client = new TcpClient( m_IP, Convert.ToInt16(m_Port) );
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.Encoding.ASCII.GetBytes(textBox1.Text);
            try
            {
                stream = m_Client.GetStream();
                stream.Write(data, 0, data.Length);
            }
            catch(Exception)
            {
                MessageBox.Show("未連線");
            }
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            byte[] data = System.Text.Encoding.Unicode.GetBytes("disconnect");

            stream = m_Client.GetStream();
            stream.Write(data, 0, data.Length);
            stream.Close();
            m_Client.Close();  
        }
        
        void client_OnRecieveData( object Sender, EventArgs e)
        {

        }

    }
}
