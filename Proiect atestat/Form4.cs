using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proiect_atestat
{
    public partial class Form4 : Form
    {
        string username;
        Random rand = new Random();
        int j, i, n, ok, scor;

        public Form4(string u)
        {
            InitializeComponent();
            username = u;
            label5.Text = username;
            i = 0;  n = 0; ok = 0; j = 0; scor = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(username);
            this.Hide();
            f3.Show();
        }
        
        private void label1_Click_1(object sender, EventArgs e)
        {
            decizie();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            decizie();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            decizie();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            decizie();
        }

        private void label9_Click(object sender, EventArgs e)
        {
            decizie();
        }

        private void label8_Click(object sender, EventArgs e)
        {
            decizie();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
            decizie();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(username);
            this.Hide();
            f6.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 f13 = new Form13(username);
            this.Hide();
            f13.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(username, username);
            this.Hide();
            f12.Show();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            j++;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            decizie();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i > 0) i--;
            if (i == 0 && ok == 1) {
                ok = 2;
                button7.BackColor = Color.Green;
                label1.BackColor = Color.Green;
                label6.BackColor = Color.Green;
                label7.BackColor = Color.Green;
                label8.BackColor = Color.Green;
                label9.BackColor = Color.Green;
                label10.BackColor = Color.Green;
                label11.BackColor = Color.Green;

                label1.Text = "Click!";
                label10.Text = "";
                label9.Text = Convert.ToString(n);
                if(n != 0) label11.Text = Convert.ToString(scor / n) + " ms";
                    else label11.Text = "0 ms";
                 
                j = 0;
                timer1.Stop();
                timer2.Start();
            }
        }

        private void decizie() {
            if (ok == 0)
            {
                button7.BackColor = Color.Red;
                label1.BackColor = Color.Red;
                label6.BackColor = Color.Red;
                label7.BackColor = Color.Red;
                label8.BackColor = Color.Red;
                label9.BackColor = Color.Red;
                label10.BackColor = Color.Red;
                label11.BackColor = Color.Red;

                label1.Text = "Asteapta verde";
                label9.Text = Convert.ToString(n);
                label10.Text = "";
                if (n != 0) label11.Text = Convert.ToString(scor / n) + " ms";
                else label11.Text = "0 ms";

                i = rand.Next(50, 200);
                timer1.Start();
                ok = 1;
            }
            else
            {
                if (ok == 1)
                {
                    button7.BackColor = Color.Blue;
                    label1.BackColor = Color.Blue;
                    label6.BackColor = Color.Blue;
                    label7.BackColor = Color.Blue;
                    label8.BackColor = Color.Blue;
                    label9.BackColor = Color.Blue;
                    label10.BackColor = Color.Blue;
                    label11.BackColor = Color.Blue;

                    label1.Text = "Ai apasat prea devreme :(";
                    label10.Text = "";
                    label9.Text = Convert.ToString(n);
                    if (n != 0) label11.Text = Convert.ToString(scor / n) + " ms";
                    else label11.Text = "0 ms";

                    ok = 0;
                }
                else
                {
                    if (ok == 2)
                    {
                        button7.BackColor = Color.Blue;
                        label1.BackColor = Color.Blue;
                        label6.BackColor = Color.Blue;
                        label7.BackColor = Color.Blue;
                        label8.BackColor = Color.Blue;
                        label9.BackColor = Color.Blue;
                        label10.BackColor = Color.Blue;
                        label11.BackColor = Color.Blue;

                        n++; scor += j * 10;

                        label10.Text = Convert.ToString(j * 10) + " ms";
                        label9.Text = Convert.ToString(n);
                        if (n != 0) label11.Text = Convert.ToString(scor / n) + " ms";
                        else label11.Text = "0 ms";

                        timer2.Stop();
                        if (n < 5)
                        {
                            ok = 0;
                            label1.Text = "Click pentru a continua";
                        }
                        else
                        {
                            ok = 3;
                            label1.Text = "Click pentru rezultate";
                        }
                    }
                    else
                    {
                        if (ok == 3) {
                            string commString = "INSERT INTO ["+username+" joc1"+"](Date, Scor) VALUES(@val1, @val2)";
                            string conString = Globals.con;
                            using (SqlConnection conn = new SqlConnection(conString))
                            {
                                using (SqlCommand comm = new SqlCommand())
                                {
                                    comm.Connection = conn;
                                    comm.CommandText = commString;
                                    comm.Parameters.AddWithValue("@val1", DateTime.Now);
                                    comm.Parameters.AddWithValue("@val2", scor / n);
                                    conn.Open();
                                    comm.ExecuteNonQuery();
                                }
                            }

                            commString = "INSERT INTO [Joc1](Scor, Date, Username) VALUES(@val1, @val2, @val3)";
                            using (SqlConnection conn = new SqlConnection(conString))
                            {
                                using (SqlCommand comm = new SqlCommand())
                                {
                                    comm.Connection = conn;
                                    comm.CommandText = commString;
                                    comm.Parameters.AddWithValue("@val1", scor/n);
                                    comm.Parameters.AddWithValue("@val2", DateTime.Now);
                                    comm.Parameters.AddWithValue("@val3",username);
                                    conn.Open();
                                    comm.ExecuteNonQuery();
                                }
                            }

                            Form5 f5 = new Form5(username);
                            this.Hide();
                            f5.Show();
                        }
                    }

                }
            }
        }
    }
}
