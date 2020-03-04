using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        string conStr = @"Data Source=LAB-30-400;Initial Catalog=UsersDB;Integrated Security=True";
        SqlConnection con = null;
        SqlCommand comm = null;

        public Form1()
        {
            InitializeComponent();

            con = new SqlConnection(conStr);
            comm = new SqlCommand();
            comm.Connection = con;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        private void UpdateTable()
        {
            lblTable.Text = ExecuteQ(
                            " SELECT * " +
                            " FROM TBUsers " +
                            " ORDER BY NAME ");
        }

        private string ExecuteQ(string command)
        {
            string output = "";
            comm.CommandText = command;
            con.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                output += reader["ID"] + " , " + reader["Name"].ToString() + " , " + reader[2] + "\n";
            }
            con.Close();
            return output;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            int res = ExecuteNonQ(
                $" INSERT INTO TBUsers(Name, Family)" +
                 " VALUES('" + txtName.Text + $"','{txtFamily.Text}') ");
        }

        private int ExecuteNonQ(string command)
        {
            comm.CommandText = command;
            con.Open();
            int res = comm.ExecuteNonQuery();
            con.Close();

            UpdateTable();

            return res;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int res = ExecuteNonQ(
                  $" UPDATE TBUsers Set Name='{txtName.Text}', Family='{txtFamily.Text}' " +
                  $" WHERE Id={txtId.Text}");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int res = ExecuteNonQ(
                  $" DELETE TBUsers " +
                  $" WHERE Id={txtId.Text}");
        }
    }
}
