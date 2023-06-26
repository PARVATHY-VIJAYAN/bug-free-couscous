using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace register
{
    public partial class Form1 : Form
    {
        String name, address, gender, email;
        String phn,str;
        public Form1()
        {
            InitializeComponent();
            str = textBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            address = textBox3.Text;
            email = textBox2.Text;
            phn = textBox4.Text;
            gender=(radioButton1.Checked)?radioButton1.Text:radioButton2.Text;
            OleDbConnection con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\paruv\OneDrive - Amrita university\Desktop\C#\C#_database\register.accdb");
            con.Open();
            OleDbCommand cmd = new OleDbCommand("select * from Table1", con);
            OleDbDataReader rd = cmd.ExecuteReader();
            if (textBox1.Text.Equals(str))            {
                MessageBox.Show("Cannot insert");
            }
            else            {
                OleDbCommand cmdin = new OleDbCommand("insert into [Table1] (fullname,Address,Email,Phone_number,Gender)values('" + name + "','" + address + "','" + email + "','" + phn + "','" + gender + "')");
                cmdin.Connection = con;
                cmdin.ExecuteNonQuery();
            }

            DataTable dt = new DataTable();
            dt.Load(rd);
            dataGridView1.DataSource = dt;

            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
 }}}
