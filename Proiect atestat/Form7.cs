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
    public partial class Form7 : Form
    {

        string username;
        int n = 0, t = -1, ok = 0;
        string nr;

        public Form7(string u)
        {
            InitializeComponent();
            username = u;
            label1.Text = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ok == 0)
            {
                genereaza_numar();
            }
            else {
                if (ok == 1)
                {
                    string nr2 = textBox1.Text;
                    button6.Visible = false;
                    label8.Visible = false;
                    label7.Visible = false;
                    label6.Visible = false;
                    textBox1.Visible = false;
                    button6.Visible = true;
                    if (nr.Equals(nr2))
                    {
                        button6.Text = "CONTINUA";
                        label5.Text = "Raspuns corect!";
                        ok = 0;
                        n++;
                        label5.BackColor = Color.Green;
                        this.BackColor = Color.Green;
                        button6.BackColor = Color.Green;
                    }
                    else
                    {
                        button6.Text = "VEZI REZULTATUL";
                        label5.Text = "Raspuns gresit! :(";
                        label8.Visible = true;
                        label8.Font = new Font("Century Gothic", 20, FontStyle.Bold);
                        label8.ForeColor = Color.White;
                        label8.Text = "Raspunsul corect este " + nr + ", tu ai introdus " + nr2;
                        ok = 2;
                        label5.BackColor = Color.Red;
                        this.BackColor = Color.Red;
                        button6.BackColor = Color.Red;
                        label8.BackColor = Color.Red;
                    }
                }
                else {
                    if (ok == 2) {
                        string commString = "INSERT INTO [" + username + " joc2" + "](Date, Scor) VALUES(@val1, @val2)";
                        string conString = Globals.con;
                        using (SqlConnection conn = new SqlConnection(conString))
                        {
                            using (SqlCommand comm = new SqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = commString;
                                comm.Parameters.AddWithValue("@val1", DateTime.Now);
                                comm.Parameters.AddWithValue("@val2", n);
                                conn.Open();
                                comm.ExecuteNonQuery();
                            }
                        }

                        commString = "INSERT INTO [Joc2](Scor, Date, Username) VALUES(@val1, @val2, @val3)";
                        using (SqlConnection conn = new SqlConnection(conString))
                        {
                            using (SqlCommand comm = new SqlCommand())
                            {
                                comm.Connection = conn;
                                comm.CommandText = commString;
                                comm.Parameters.AddWithValue("@val1", n);
                                comm.Parameters.AddWithValue("@val2", DateTime.Now);
                                comm.Parameters.AddWithValue("@val3", username);
                                conn.Open();
                                comm.ExecuteNonQuery();
                            }
                        }

                        Form8 f8 = new Form8(username);
                        this.Hide();
                        f8.Show();
                    }
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (t > 0) t--;
            else {
                label8.Visible = false;
                label7.Visible = false;
                label6.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                button6.Visible = true;
                button6.Text = "VERIFICA";
                ok = 1;
                textBox1.Visible = true;
                label5.Text = "Introduceti numarul pe care l-ati vazut";
                timer1.Stop();

            }
            label6.Text = Convert.ToString(t);
            label9.Text = Convert.ToString(n);
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(username);
            this.Hide();
            f3.Show();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void genereaza_numar() {
            button6.Visible = false;
            label5.Text = "";
            label8.Visible = true;
            label7.Visible = true;
            label6.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            textBox1.Visible = false;
            textBox1.Text = "";
            label5.BackColor = Color.Orange;
            this.BackColor = Color.Orange;
            button6.BackColor = Color.Orange;


            nr = null;
            Random rand = new Random();
            for (int i = 1; i <= n + 1; i++)
            {
                int x = rand.Next(0, 9);
                nr = string.Concat(nr, Convert.ToString(x));
                Console.WriteLine(x);
                Console.WriteLine(nr);
            }

            label8.Text = nr;

            t = 30;
            timer1.Start();


        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

    }
}
