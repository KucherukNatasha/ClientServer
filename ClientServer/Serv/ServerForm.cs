using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serv
{
    public partial class ServerForm : Form
    {
        int clickCount = 0;
        public ServerForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {   if(clickCount==0)
            { 
            SocketServer socketServ = new SocketServer();
            socketServ.ServerListen();
                clickCount++;
            }
            else
            {
                return;
            }
          
        }

       


    }
}
