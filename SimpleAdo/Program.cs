﻿using System;
using System.Data.SqlClient;

namespace SimpleAdo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Sql Connection object
            //(LocalDb)\MSSQLLocalDB
            //TO do in case forgot
            //show how to get connection string from serve explorer
            // 1. Instantiate the connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=NetTraining;Integrated Security=True");
            //other connection string with userid and password
            //@ feature
            //open the connection

            try
            { 
            con.Open();
            SqlDataReader sqlDataReader = null;
            // 3. Pass the connection to a command object
            SqlCommand cmd = new SqlCommand("select * from [dbo].[Participants]", con);

            //SqlDatareader will be returned when query will be fired
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Console.WriteLine($"ID ={sqlDataReader[0]} FirstName={sqlDataReader[1]}" +
                                    $" LastName   ={sqlDataReader[2]} Profile={sqlDataReader[3]}  City={sqlDataReader[4]}     ");
            }
            }
            catch(Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                //necessary to close connection
                con.Close();

            }
            

            Console.ReadLine();
        }
    }
}
