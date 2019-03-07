using MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVC.DATA
{
    public class ParticipantReository
    {
        public List<Participant> GetAllParticipants()
        {
            try
            {
                var participants = new List<Participant>();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("sp_getParticipants", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            participants.Add(new Participant()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("ID")),
                                FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                City= reader.GetString(reader.GetOrdinal("City")),
                                Profile= reader.GetString(reader.GetOrdinal("Profile"))
                            });
                        }
                    }
                }
                return participants;
            }
            catch (Exception e)
            {
                
                throw;
            }
        }


    }
}