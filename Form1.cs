using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Drawing.Drawing2D;
using System.IO;

namespace LoginScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        
        public void check()
        {

            using (System.IO.StreamWriter file =
                     new System.IO.StreamWriter(@"C:\Users\bbayrakli\Desktop\" + DateTime.UtcNow.ToString("yyyy_MM_dd") + "_" + UserName.Text + ".txt", true))

                if (File.Exists(@"C:\Users\bbayrakli\Desktop\" + DateTime.UtcNow.ToString("yyyy_MM_dd") + "_" + UserName.Text + ".txt"))
                {

                    {
                        file.WriteLine(DateTime.Now.ToString("hh:mm:ss")+" - Giriş Yapıldı");
                    }
                }
                else
                {

                    System.IO.File.WriteAllText(@"C:\Users\bbayrakli\Desktop\" + DateTime.UtcNow.ToString("yyyy_MM_dd") + "_"
                        + UserName.Text + ".txt", "Giriş Yapıldımı.\n");
                }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Form1.ActiveForm.Activate();

            

                string strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Users.mdb";
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                string select = "select * from Users where Username='" + UserName.Text + "'";
                string find = "select * from Users where Password='" + Password.Text + "'";
                using (OleDbCommand cmd = new OleDbCommand(select, conn))
                    

                {
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    if (count > 0)
                    {
                        using (OleDbCommand komut = new OleDbCommand(find, conn))

                        {
                            int say = Convert.ToInt32(komut.ExecuteScalar());
                            if (say > 0)
                            {
                                OleDbDataReader reader = komut.ExecuteReader();
                                MessageBox.Show("Giriş Başarılı");
                                while (reader.Read())
                                {
                                    string UserName = reader["Ad_Soyad"].ToString();
                                    label1.Text = UserName;
                                }

                                check(); 
                                    
                                    
                                

                            }
                            else
                            {
                                MessageBox.Show("Kullanıcı Adı veya Parola Hatalı.");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı Adı veya Parola Hatalı");
                    }
                }
            }
            
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Password.PasswordChar = '\0';
            }
            if (checkBox1.Checked == false)
            {
                Password.PasswordChar = '*';
            }
        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics graphics = e.Graphics;
            System.Drawing.Rectangle gradient_rectangle = new System.Drawing.Rectangle(0, 0, this.Width, this.Height);
            System.Drawing.Drawing2D.LinearGradientBrush b = new System.Drawing.Drawing2D.LinearGradientBrush(gradient_rectangle, color1:Color.FromArgb(0,100,80), color2: Color.FromArgb(100,0,100), 225f);
            graphics.FillRectangle(b, gradient_rectangle);
        }


        // WINDOW RESIZING WITH RATIO's
       /* private void Form1_Resize(object sender, EventArgs e)
        {
            panel1.Location = new System.Drawing.Point((this.Width/2 - 175 / 2-11), (this.Height/2 - 149 / 2+74));
            pictureBox1.Location = new System.Drawing.Point((this.Width / 2 - 228 / 2 - 9), (this.Height / 2 - 149 / 2 - 92)); 
        }*/


    }
}
