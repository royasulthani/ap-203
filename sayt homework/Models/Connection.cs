using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace sayt_homework.Models
{
    class Connection
    {
        private static SqlConnection con;

        internal static void InsertData()
        {
        }

        public static string ConnectionString = @"Server=DESKTOP-UFPEISL\SQLEXPRESS01;DATABASE=BLOGG;Trusted_Connection=TRUE";
        private static object title;
        private static object content;
        private static string _conString;

        public static void InsertBlogg()
        {
            Console.WriteLine("TITLE deyerini daxil edin");
            string name = Console.ReadLine();
            Console.WriteLine("CONTENT deyerini daxil edin");
            string description = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(ConnectionString)) ;
            {
                con.Open();
                string query = $"INSERT INTO Blogg(TITLE,CONTENT) VALUES('{title}',{content})";
                SqlCommand cmd = new SqlCommand(query, con);
                var res = cmd.ExecuteNonQuery();
            }

        }
        public static void DeleteBloggs()
        {
            Console.WriteLine("TITLE deyerini silin");
            string name = Console.ReadLine();
            Console.WriteLine("CONTENT deyerini silin");
            string description = Console.ReadLine();
            using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-UFPEISL\SQLEXPRESS01;Trusted_Connection=TRUE")) ;
        }
        static void ShowBloggs()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "SELECT *FROM BLOGGS";
            SqlCommand sqlCommand = new SqlCommand(query, con);
            SqlDataReader sql = sqlCommand.ExecuteReader();
            while (sql.Read())
            {
                Console.WriteLine($"{sql["TITLE"]},{sql["CONTENT"]}");
            }
            con.Close();
        }
        static List<Blogg> GetAllBloggs()
        {
            List<Blogg> bloggs = new List<Blogg>();

            using (SqlConnection con = new SqlConnection(_conString))
            {
                con.Open();

                string query = "SELECT * FROM Bloggs";

                SqlCommand cmd = new SqlCommand(query, con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Blogg blogg = new Blogg
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            Title = dr.GetString(2),
                            Content = dr.GetString(3)
                        };

                        bloggs.Add(blogg);
                    }
                }
                return bloggs;
            }
        }
    }
}
    




    

