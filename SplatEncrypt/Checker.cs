using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using static System.Convert;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplatEncrypt
{
    public partial class Checker : Form
    {
        public Form1 main;
        public int ver;
        public string data;
        public WebClient vers = new WebClient();
        public Checker()
        {
            InitializeComponent();
        }


        public int getdata()
        { 
            try
            {
                ver = ToInt32(vers.DownloadString("https://mcminers9.github.io/SplatEncrypt/version.txt"));
                return 0;

            }
            catch
            {
                return 1;
            }

            
        }

        private void Update_Load(object sender, EventArgs e)
        {
            updateBox.Text = vers.DownloadString("https://mcminers9.github.io/SplatEncrypt/changelog.txt");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void githubButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MCMiners9/SplatEncrypt/releases");
            Close();
        }
    }
}
