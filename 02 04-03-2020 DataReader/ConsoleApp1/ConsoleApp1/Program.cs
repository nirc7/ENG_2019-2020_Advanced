using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertT2DB();
            UpdateinDb();
            SelectFromDB();
        }

        private static void SelectFromDB()
        {
            ExecuteQ(
                " SELECT * " + 
                " FROM TBUsers " + 
                " ORDER BY NAME ");
        }

        private static void UpdateinDb()
        {
            int res = ExecuteNonQ(
                  " UPDATE TBUsers Set Name='dora55', Family='bora55' " +
                  " WHERE Id=5");

            Console.WriteLine(res == 1 ? ":)" : ":(");
        }

        private static int ExecuteNonQ(string command)
        {
            string conStr = @"Data Source=LAB-30-400;Initial Catalog=UsersDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand(command, con);
            con.Open();
            int res = comm.ExecuteNonQuery();
            con.Close();

            return res;
        }

        private static void ExecuteQ(string command)
        {
            string conStr = @"Data Source=LAB-30-400;Initial Catalog=UsersDB;Integrated Security=True";
            SqlConnection con = new SqlConnection(conStr);
            SqlCommand comm = new SqlCommand(command, con);
            con.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["Name"].ToString() + "\t" + reader[2] + "\n");
            }
            con.Close();
        }

        private static void InsertT2DB()
        {
            int res = ExecuteNonQ("INSERT INTO TBUsers(Name, Family) VALUES('dora2','bora2') ");
            Console.WriteLine(res == 1 ? ":)" : ":(");
        }
    }
}
