using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DisconnectedData
{
    class Program
    {
        static void Main(string[] args)
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
                DataSet dsParticipants = new DataSet();   
                    // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand("select * from [dbo].[Participants]", con);
                //assign command to sqlDataAdaptor
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                sqlDataAdapter.Fill(dsParticipants, "Participants");
                if (dsParticipants.Tables["Participants"].Rows.Count > 1)
                {
                    foreach (DataRow item in dsParticipants.Tables["Participants"].Rows)
                    {
                        Console.WriteLine($"Id= {item["Id"]} FirstName={item["FirstName"]} LastName={item["LastName"]} Profile={item["Profile"]} City={item["City"]}");
                       
                    }
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
