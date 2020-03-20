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
            dr[2] = txtFamily.Text; //dr["Family"]
            table.Rows.Add(dr);

            UpdateDBFromDS();
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
            adtr.Update(ds, "Users");//opt1
            //adtr.Update(table);//opt2
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            UpdateDBFromDS();
        }

        private void btnUpdateWithParams_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand(
                " UPDATE TBUsers SET Name=@ParName , Family=@ParFamily " +
                " WHERE Id=@ParID ", con2);
            SqlParameter parN = new SqlParameter("@ParName", txtName.Text);
            comm.Parameters.Add(parN);
            comm.Parameters.Add(new SqlParameter("@ParFamily", txtFamily.Text));
            comm.Parameters.Add(new SqlParameter("@ParID", int.Parse(txtID.Text)));
            comm.Connection.Open(); //opt1
            //con2.Open(); //opt2
            int res = comm.ExecuteNonQuery();
            comm.Connection.Close();
            MessageBox.Show(res.ToString());
        }

        private void btnSPFamilyByID_Click(object sender, EventArgs e)
        {
            SqlConnection con3 = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand("SearchUser", con3);
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter ParId = new SqlParameter("@MyID", DbType.Int32);
            ParId.Direction = ParameterDirection.Input;
            ParId.Value = int.Parse(txtID.Text);
            comm.Parameters.Add(ParId);

            SqlParameter ParFamily = new SqlParameter("@FamilyName", SqlDbType.VarChar,20);
            ParFamily.Direction = ParameterDirection.Output;
            comm.Parameters.Add(ParFamily);

            SqlParameter ParReturn = new SqlParameter();
            ParReturn.Direction = ParameterDirection.ReturnValue;
            comm.Parameters.Add(ParReturn);

            con3.Open();
            comm.ExecuteNonQuery();
            con3.Close();

            if ((int)ParReturn.Value == 0)
            {
                MessageBox.Show(ParFamily.Value.ToString());
            }
            else
                MessageBox.Show("ERROR SP!!!");
        }

        private void btnGetUsersGreaterThanID_Click(object sender, EventArgs e)
        {
            SqlConnection con3 = new SqlConnection(strCon);
            SqlCommand comm = new SqlCommand("SearchUserTable", con3);
            comm.CommandType = CommandType.StoredProcedure;

            SqlParameter ParId = new SqlParameter("@MyID", DbType.Int32);
            ParId.Direction = ParameterDirection.Input;
            ParId.Value = int.Parse(txtID.Text);
            comm.Parameters.Add(ParId);

            DataSet dsUsers = new DataSet();
            SqlDataAdapter usersAdptr = new SqlDataAdapter(comm);
            usersAdptr.Fill(dsUsers,"usersTB");
            dataGridView1.DataSource = dsUsers.Tables[0];

        }
    }
}
