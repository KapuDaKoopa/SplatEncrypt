using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Security;

namespace SplatEncrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // design begun
            textBox3.PasswordChar = '*';
            textBox3.MaxLength = 8;
            this.richTextBox1.Visible = false;
            this.richTextBox2.Visible = false;
            this.button4.Visible = false;
            this.label3.Visible = false;
            this.textBox4.Visible = false;
            // end design
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // desing begun
            if (checkBox1.Checked == true)
            {
                checkBox2.Enabled = false;
                this.button3.Text = "Encryption";
                this.button3.Image = global::SplatEncrypt.Resources.locked_lock;
                this.button4.Text = "Encryption";
                this.button4.Image = global::SplatEncrypt.Resources.locked_lock;
                this.label2.Text = "Encryption operation was chosen";

            }
            else if (checkBox1.Checked == false)
            {
                checkBox2.Enabled = true;
            }
            // end desing
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // desing begun
            if (checkBox2.Checked == true)
            {
                checkBox1.Enabled = false;
                this.button3.Text = "Decryption";
                this.button3.Image = global::SplatEncrypt.Resources.unlocked_lock;
                this.button4.Text = "Decryption";
                this.button4.Image = global::SplatEncrypt.Resources.unlocked_lock;
                this.label2.Text = "Decryption operation was chosen";

            }
            else if (checkBox1.Checked == false)
            {
                checkBox1.Enabled = true;
            }
            // end desing
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                // design begun
                textBox4.PasswordChar = '*';
                textBox4.MaxLength = 8;
                this.richTextBox1.Visible = true;
                this.richTextBox2.Visible = true;
                this.button4.Visible = true;
                this.label3.Visible = true;
                this.textBox4.Visible = true;
                //**********************************
                this.button1.Visible = false;
                this.button2.Visible = false;
                this.button3.Visible = false;
                this.textBox1.Visible = false;
                this.textBox2.Visible = false;
                this.textBox3.Visible = false;
                this.label1.Visible = false;
                // end design
            }
            else if (checkBox3.Checked == false)
            {
                textBox4.PasswordChar = '*';
                this.richTextBox1.Visible = false;
                this.richTextBox2.Visible = false;
                this.button4.Visible = false;
                this.label3.Visible = false;
                this.textBox4.Visible = false;
                //**********************************
                this.button1.Visible = true;
                this.button2.Visible = true;
                this.button3.Visible = true;
                this.textBox1.Visible = true;
                this.textBox2.Visible = true;
                this.textBox3.Visible = true;
                this.label1.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = openFileDialog1.FileName;
                textBox1.Text = path;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (button3.Text)
            {
                default: break;
                case "Encryption":
                    {
                        try
                        {
                            string password = textBox3.Text;
                            UnicodeEncoding UE = new UnicodeEncoding();
                            byte[] key = UE.GetBytes(password)
                                   ; string cryptedFile = textBox2.Text;
                            FileStream FsCrypt = new FileStream(cryptedFile, FileMode.Create);
                            RijndaelManaged RMCrypt = new RijndaelManaged();
                            CryptoStream CS = new CryptoStream(FsCrypt, RMCrypt.CreateEncryptor(key, key), CryptoStreamMode.Write);
                            FileStream FSIN = new FileStream(textBox1.Text, FileMode.Open);
                            int data;
                            while ((data = FSIN.ReadByte()) != -1)
                                CS.WriteByte((byte)data);
                            FSIN.Close();
                            CS.Close();
                            FsCrypt.Close();
                        }
                        catch (Exception ex)
                        {
                            label2.Text = "The encryption operation failed";
                            MessageBox.Show("Error" + ex);
                        }
                        break;
                    }
                case "Decryption":
                    {
                        try
                        {
                            string password = textBox3.Text;
                            UnicodeEncoding UE = new UnicodeEncoding();
                            byte[] key = UE.GetBytes(password)
                                   ; string cryptedFile = textBox2.Text;
                            FileStream FsCrypt = new FileStream(cryptedFile, FileMode.Create);
                            RijndaelManaged RMCrypt = new RijndaelManaged();
                            CryptoStream CS = new CryptoStream(FsCrypt, RMCrypt.CreateDecryptor(key, key), CryptoStreamMode.Write);
                            FileStream FSout = new FileStream(textBox1.Text, FileMode.Open);
                            int data;
                            while ((data = CS.ReadByte()) != -1)
                                CS.WriteByte((byte)data);
                            FSout.Close();
                            CS.Close();
                            FsCrypt.Close();
                        }
                        catch (Exception ex)
                        {
                            label2.Text = "Operation failed";
                            MessageBox.Show("Error" + ex);
                        }


                        break;
                        }
                    }
            }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog Savefile = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                textBox2.Text = path;
            }
        }
    }
    }