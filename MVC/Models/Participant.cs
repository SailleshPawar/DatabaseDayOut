using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
   public class Participant
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Profile { get; set; }
        public string City { get; set; }
    }
}