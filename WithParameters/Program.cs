using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WithParameters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Participant City");
            var city = Console.ReadLine();
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
                //2 open the connection
                con.Open();
                SqlDataReader sqlDataReader = null;
                //3  define parameters used in command object
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@City";
                param.Value = city;


                // 3. Pass the connection to a command object


                SqlCommand cmd = new SqlCommand("select * from [dbo].[Participants] where City=@City", con);
                cmd.Parameters.Add(param);
                //SqlDatareader will be returned when query will be fired
                sqlDataReader = cmd.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Console.WriteLine($"ID ={sqlDataReader["ID"]} FirstName={sqlDataReader["FirstName"]}" +
                                        $" LastName   ={sqlDataReader["LastName"]} Profile={sqlDataReader["Profile"]}  City={sqlDataReader["City"]}     ");
                }
            }
            catch (Exception exception)
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
