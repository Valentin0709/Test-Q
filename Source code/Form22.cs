﻿using System;
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
    public partial class Form22 : Form
    {
        string username;
        public Form22(string u)
        {
            InitializeComponent();
            username = u;
            label1.Text = username;

            SqlConnection sqlcon = new SqlConnection(Globals.con);
            SqlCommand cmd = new SqlCommand("SELECT Scor, Username FROM [Joc3]", sqlcon);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet dt = new DataSet();
            da.Fill(dt);

            dataGridView1.DataSource = dt.Tables[0];
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);

            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.HeaderCell.Style.Font = new Font("Century Gothic", 19F, FontStyle.Bold, GraphicsUnit.Pixel);
                c.HeaderCell.Style.ForeColor = Color.DarkGray;
                c.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            for (int i = 0; i < dataGridView1.Columns.Count - 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dataGridView1.Columns[dataGridView1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16(username);
            this.Hide();
            f16.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(username);
            this.Hide();
            f3.Show();
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
    }
}
