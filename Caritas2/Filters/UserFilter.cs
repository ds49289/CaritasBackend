using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.Filters
{
    public class UserFilter
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Oib { get; set; }
        public DateTime? Birthday { get; set; }
        public int? PostalCode { get; set; }
        public int? BehaviourId { get; set; }
        public int? SexId { get; set; }
        public string Email { get; set; }
    }
}