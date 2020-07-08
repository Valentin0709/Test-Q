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
    public partial class Form14 : Form
    {
        string username;
        string[] cuv = {"curcubeu", "oaie", "unicorn", "Israel", "informatica", "servetel", "mitocondrie", "telefon", "ureche", "elefant", "cer", "camila", "portocaliu", "matematica", "legatura", "caracatita", "luna", "soare","munte", "val", "circuit", "rezistor", "dioda", "maimuta", "electron", "abreviere", "recalcitrant", "condamnat", "atent", "restaurant", "fazan", "spectroscop", "ambulanta", "cerc", "patrat", "cavaler", "bacterie", "apostrof", "cratima", "cercetator", "minge", "sfera", "doctor", "dinte", "vopsea", "geam", "creion", "rezerva", "pantof", "litera", "furculita", "copac", "sticla", "suc", "apa", "pepene", "pisica", "picatura", "ochelari", "nucleu", "avalansa", "testoasa", "ghiozdan", "Matei", "ecran", "plastic"};
        int[] vaz = new int[66];
        int nr = 35, v = 3, scor = 0, nrc, ok = 0;
        string s;

        public Form14(string u)
        {
            InitializeComponent();
            username = u;
            label1.Text = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (vaz[nrc] == 1)
            {
                scor += 10;
                genereaza();
            }
            else {
                vaz[nrc] = 1;
                v--;
                if (v > 0) genereaza();
                else {
                    button6.Visible = true;
                    button5.Visible = false;
                    button7.Visible = false;
                    label5.Visible = true;
                    label6.Visible = false;
                    label8.Visible = false;

                    label5.Text = "Testul s-a terminat";
                    this.BackColor = Color.Red;
                    label5.BackColor = Color.Red;
                    button6.Text = "VEZI REZULTATE";
                    ok = 1;
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void Form14_Load(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (vaz[nrc] == 0)
            {
                scor += 10;
                vaz[nrc] = 1;
                genereaza();
            }
            else
            {
                v--;
                if (v > 0) genereaza();
                else
                {
                    button6.Visible = true;
                    button5.Visible = false;
                    button7.Visible = false;
                    label5.Visible = true;
                    label6.Visible = false;
                    label8.Visible = false;

                    label5.Text = "Testul s-a terminat";
                    this.BackColor = Color.Red;
                    label5.BackColor = Color.Red;
                    button6.Text = "VEZI REZULTATE";
                    ok = 1;
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (ok == 0)
            {
                button6.Visible = false;
                button5.Visible = true;
                button7.Visible = true;
                label5.Visible = false;
                label6.Visible = true;
                label8.Visible = true;
                for (int i = 0; i <= 65; i++) vaz[i] = 0;
                genereaza();
            }
            else {
                string commString = "INSERT INTO [" + username + " joc3" + "](Date, Scor) VALUES(@val1, @val2)";
                string conString = Globals.con;
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commString;
                        comm.Parameters.AddWithValue("@val1", DateTime.Now);
                        comm.Parameters.AddWithValue("@val2", scor);
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                }

                commString = "INSERT INTO [Joc3](Scor, Date, Username) VALUES(@val1, @val2, @val3)";
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commString;
                        comm.Parameters.AddWithValue("@val1", scor);
                        comm.Parameters.AddWithValue("@val2", DateTime.Now);
                        comm.Parameters.AddWithValue("@val3", username);
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                }

                Form15 f15 = new Form15(username);
                this.Hide();
                f15.Show();
            }
        }

        private void genereaza() {
            Random rand = new Random();
            nrc = rand.Next(0, nr);
            s = cuv[nrc];
            label6.Text = s;
            label8.Text = "Vieti ramase| " + Convert.ToString(v) + "         Scor| " + Convert.ToString(scor);
        }
    }
}
