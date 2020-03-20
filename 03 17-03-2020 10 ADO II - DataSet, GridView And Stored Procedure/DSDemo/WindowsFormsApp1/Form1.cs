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
        string strCon = @"Data Source=E440\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=True";
        SqlConnection con;
        SqlDataAdapter adtr;
        DataSet ds = new DataSet();
        DataTable table = null;

        public Form1()
        {
            InitializeComponent();
            con = new SqlConnection(strCon);
            adtr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
        }

        private void btnSelectFromDB2DS_Click(object sender, EventArgs e)
        {
            ds.Clear();
            adtr.Fill(ds, "Users");
            table = ds.Tables[0]; //ds.Tables["Users"];
            dataGridView1.DataSource = table;            
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            DataRow dr = table.NewRow();
            dr["ID"] = txtID.Text;
            dr["Name"] = txtName.Text;
            dr[2] = txtFamily.Text;
            table.Rows.Add(dr);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["ID"].ToString() == txtID.Text)
                {
                    table.Rows[i]["Name"] = txtName.Text;
                    table.Rows[i]["Family"] = txtFamily.Text;
                    break;
                }
            }
            UpdateDBFromDS();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i]["ID"].ToString() == txtID.Text)
                {
                    table.Rows[i].Delete();
                }
            }
            UpdateDBFromDS();
        }

        private void btnUpdateDBFromDS_Click(object sender, EventArgs e)
        {
            UpdateDBFromDS();
        }

        private void UpdateDBFromDS()
        {
            new SqlCommandBuilder(adtr);
            adtr.Update(ds, "Users");
        }
    }
}
