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
using System.Net.Mail;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proiect_atestat
{
    public partial class Form12 : Form
    {
        string username, pr, email;
        public Form12(string u, string p)
        {
            username = u; pr = p;
            InitializeComponent();
            label1.Text = username;

            if (username.Equals(pr)) button4.BackColor = Color.FromArgb(0, 93, 200);
            else
            {
                button3.BackColor = Color.FromArgb(0, 93, 200);
                button5.Visible = false;
                button6.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
            }

            label5.Text = "Profilul lui " + p;
            SqlConnection sqlcon = new SqlConnection(Globals.con);
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Users]", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                if (pr.Equals(dr["Username"].ToString())) {
                    label6.Text = "Nume: " + dr["Last_Name"].ToString();
                    label7.Text = "Prenume: " + dr["First_Name"].ToString();
                    DateTime bd = Convert.ToDateTime(dr["Birthday"].ToString());
                    label8.Text = "Data nasterii: " + bd.ToString("yyyy-MM-dd");
                    label9.Text = "Adresa de email: " + dr["Email"].ToString();
                    email = dr["Email"].ToString();
                }

            }

            cmd = new SqlCommand("SELECT * FROM [" + p + " joc1]", sqlcon);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int x = Int32.Parse(dr["Scor"].ToString());
                DateTime d = Convert.ToDateTime(dr["Date"].ToString());
                chart1.Series["Scor"].Points.AddXY(d, x);
            }

            cmd = new SqlCommand("SELECT * FROM [" + p + " joc2]", sqlcon);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int x = Int32.Parse(dr["Scor"].ToString());
                DateTime d = Convert.ToDateTime(dr["Date"].ToString());
                chart2.Series["Scor"].Points.AddXY(d, x);
            }

            cmd = new SqlCommand("SELECT * FROM [" + p + " joc3]", sqlcon);
            da = new SqlDataAdapter(cmd);
            dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                int x = Int32.Parse(dr["Scor"].ToString());
                DateTime d = Convert.ToDateTime(dr["Date"].ToString());
                chart3.Series["Scor"].Points.AddXY(d, x);
            }

        }

        private void Form12_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17(username, pr);
            this.Hide();
            f17.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
        try
        {
        string commString = "DELETE FROM [Users] WHERE Username='" + username + "'";
        string conString = Globals.con;
        using (SqlConnection conn = new SqlConnection(conString))
         {
         using (SqlCommand comm = new SqlCommand())
                        {
                            comm.Connection = conn;
                            comm.CommandText = commString;
                            conn.Open();
                            comm.ExecuteNonQuery();
                        }
                    }
                }
                catch { MessageBox.Show("A avut loc o eroare :("); }

            try
            {
                string commString = "DROP TABLE [" + username + " joc1]";
                string conString = Globals.con;
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commString;
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("A avut loc o eroare :("); }

            try
            {
                string commString = "DROP TABLE [" + username + " joc2]";
                string conString = Globals.con;
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commString;
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("A avut loc o eroare :("); }

            try
            {
                string commString = "DROP TABLE [" + username + " prieteni]";
                string conString = Globals.con;
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commString;
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("A avut loc o eroare :("); }

            try
            {
                string commString = "DROP TABLE [" + username + " joc3]";
                string conString = Globals.con;
                using (SqlConnection conn = new SqlConnection(conString))
                {
                    using (SqlCommand comm = new SqlCommand())
                    {
                        comm.Connection = conn;
                        comm.CommandText = commString;
                        conn.Open();
                        comm.ExecuteNonQuery();
                    }
                }
            }
            catch { MessageBox.Show("A avut loc o eroare :("); }

            Form1 f1 = new Form1();
             this.Hide();
             f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("testq.statistics@gmail.com", "vali070900");

            MailMessage mm = new MailMessage("testq.statistics@gmail.com", email, "Statistici Test Q", "Multumim pentru ca folositi servicile oferite de Test Q. In acest mail, va atasam graficele de evolutie pentru testele pe care le-ati efectuat recent. Speram sa va bucurati de progresul dumneavoastra!");
            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            MemoryStream s1 = new MemoryStream();
            chart1.SaveImage(s1, ChartImageFormat.Png);
            s1.Position = 0;

            MemoryStream s2 = new MemoryStream();
            chart2.SaveImage(s2, ChartImageFormat.Png);
            s2.Position = 0;

            MemoryStream s3 = new MemoryStream();
            chart3.SaveImage(s3, ChartImageFormat.Png);
            s3.Position = 0;

            mm.Attachments.Add(new Attachment(s1, "grafic_test_timp_de_reactie.png", "image/png"));
            mm.Attachments.Add(new Attachment(s2, "grafic_test_memorie_numerica", "image/png"));
            mm.Attachments.Add(new Attachment(s3, "grafic_test_memorie_verbala.png", "image/png"));

            client.Send(mm);

            MessageBox.Show("Email-ul a fost trimis cu succes!");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12(username, username);
            this.Hide();
            f12.Show();
        }
    }
}
