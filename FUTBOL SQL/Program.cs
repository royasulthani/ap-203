using System;
using System.Data.SqlClient;

namespace FUTBOL_SQL
{
    class Program
    {
        static string ConnectionString = @"Server=DESKTOP-UFPEISL\SQLEXPRESS01;Database,Trusted_Connection=TRUE";
        static void Main(string[] args)
        {
            static void InsertFutbol()
            {

                Console.WriteLine("NAME deyerini daxil edin");
                string name = Console.ReadLine();
                Console.WriteLine("HOURPRICE deyerini daxil edin");
                string hourprice = Console.ReadLine();
                Console.WriteLine("CAPACITY deyerini daxil edin");
                string capacity = Console.ReadLine();
                using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-UFPEISL\SQLEXPRESS01;Trusted_Connection=TRUE")) 
                {
                    con.Open();
                    string query = $"INSERT INTO FUTBOLS(NAME,HOURPRICE,CAPACITY) VALUES('{name}',{hourprice},{capacity})";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }

            }
                static void ShowFutbols()
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                string query = "SELECT *FROM FUTBOLS";
                SqlCommand sqlCommand = new SqlCommand(query, con);
                SqlDataReader sql = sqlCommand.ExecuteReader();
                while (sql.Read())
                {
                    Console.WriteLine($"{sql["NAME"]},{sql["HOURPRICE"]},{sql["CAPACITY"]});
                }
                con.Close();

            }

        }
    }
}
