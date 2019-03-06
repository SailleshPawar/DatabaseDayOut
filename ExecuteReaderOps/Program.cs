using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ExecuteReaderOps
{
    internal class Program
    {
        private static  void Main(string[] args)
        {
             InsertData().Wait();
             UpdateData().Wait();
             DeleteData().Wait();
            Console.WriteLine($"The id  is {GetSingleValue().Result}");
            Console.ReadLine();
        }


        public static async Task<int> GetSingleValue()
        {
            int returnedValue = 0;
            Participant participant = new Participant();
            Console.WriteLine("Ënter participants details");
            Console.WriteLine("Ënter Participant firstname and i will retrieve the Id of the user");
            participant.FirstName = Console.ReadLine();



            //show how to get connection string from serve explorer
            // 1. Instantiate the connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=NetTraining;Integrated Security=True");
            string insertString = $@"
                     select Id from [Participants]
                     where FirstName='{participant.FirstName}'";
            try
            {
                con.Open();
                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand();
                //assign connection to cmd object not in constructor
                cmd.Connection = con;
                //assigning command to be executing in command object
                cmd.CommandText = insertString;
                //execute insert query against database to send command
                 returnedValue = (int)  await  cmd.ExecuteScalarAsync();
              
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

            return returnedValue;
            
        }

        public static async Task DeleteData()
        {
            Participant participant = new Participant();
            Console.WriteLine("Ënter participants details");
            Console.WriteLine("Ënter Participant Id to be Deleted");
            participant.Id = Convert.ToInt32(Console.ReadLine());
         


            //show how to get connection string from serve explorer
            // 1. Instantiate the connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=NetTraining;Integrated Security=True");
            string insertString = $@"
                     Delete from [Participants]
                     where id={participant.Id}";
            try
            {
                con.Open();
                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand();
                //assign connection to cmd object not in constructor
                cmd.Connection = con;
                //assigning command to be executing in command object
                cmd.CommandText = insertString;
                //execute insert query against database to send command
                await cmd.ExecuteNonQueryAsync();
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

        }

        public static async Task UpdateData()
        {
            Participant participant = new Participant();
            Console.WriteLine("Ënter participants details");
            Console.WriteLine("Ënter Participant Id to be updated and new FirstName");
            participant.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ënter new FirstName");
            participant.FirstName = Console.ReadLine();
           
            
            //show how to get connection string from serve explorer
            // 1. Instantiate the connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=NetTraining;Integrated Security=True");
            string insertString = $@"
                     update  [Participants]
                     set FirstName='{participant.FirstName}'
                     where id={participant.Id}";
            try
            {
                con.Open();
                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(insertString);
                //assign connection to cmd object not in constructor
                cmd.Connection = con;
                //execute insert query against database to send command
                await cmd.ExecuteNonQueryAsync();
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

        }

        public static async Task InsertData()
        {
            Participant participant = new Participant();
            Console.WriteLine("Ënter participants details");
            Console.WriteLine("Ënter Participant Id number");
            participant.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ënter FirstName");
            participant.FirstName = Console.ReadLine();
            Console.WriteLine("Ënter LastName");
            participant.LastName = Console.ReadLine();
            Console.WriteLine("Ënter Profile");
            participant.Profile = Console.ReadLine();
            Console.WriteLine("Ënter City");
            participant.City = Console.ReadLine();
            //show how to get connection string from serve explorer
            // 1. Instantiate the connection
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=NetTraining;Integrated Security=True");
            string insertString = @"
                     insert into [Participants]
                     (Id, FirstName,LastName,Profile,City)
                     values ('" + participant.Id + "','" + participant.FirstName + "','" + participant.LastName + "','" + participant.Profile
                     + "','" + participant.City + "')";
            try
            {
                con.Open();
                // 3. Pass the connection to a command object
                SqlCommand cmd = new SqlCommand(insertString, con);
                //execute insert query against database to send command
                await cmd.ExecuteNonQueryAsync();
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

        }

    }
}
