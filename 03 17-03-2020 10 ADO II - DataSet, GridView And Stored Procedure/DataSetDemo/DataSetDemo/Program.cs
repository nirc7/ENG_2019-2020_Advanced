using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string strCon = @"Data Source=E440\SQLEXPRESS;Initial Catalog=UsersDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(strCon);
            SqlDataAdapter adtr = new SqlDataAdapter("SELECT * FROM TBUsers", con);
            DataSet ds = new DataSet();
            adtr.Fill(ds, "T1");
            Console.WriteLine(ds.Tables["T1"].Rows[0]["Name"]);
            DataTable tab1 = ds.Tables["T1"];

            //Insert
            Random rnd = new Random();
            int num = rnd.Next(1, 20);
            DataRow dr = tab1.NewRow();
            dr["ID"] = num;
            dr["Name"] = "dora" + num;
            dr[2] = "bora" + num;
            tab1.Rows.Add(dr);

            //Update
            tab1.Rows[1]["Family"] = "first family";

            //Delete
            tab1.Rows[0].Delete();
            //tab1.AcceptChanges();

            
            //update DB
            SqlCommandBuilder comb = new SqlCommandBuilder(adtr);
            adtr.Update(ds, "T1");
            //adtr.Update(tab1);

            //show the table on console
            ShowTable(tab1);
        }

        private static void ShowTable(DataTable table)
        {
            string output = "";
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //output += table.Rows[i]["ID"] + "\t" + table.Rows[i]["Name"] + "\t" + table.Rows[i]["Family"] + "\n";
                output += $"{table.Rows[i]["ID"]}\t{table.Rows[i]["Name"].ToString().Trim()}\t{table.Rows[i]["Family"]} \n";
            }
            Console.WriteLine("__________ my TABLE __________");
            Console.WriteLine(output);
            Console.WriteLine();
        }
    }
}
