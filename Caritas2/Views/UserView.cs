using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.Views
{
    public class UserView
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string OIB { get; set; }
        public string Email { get; set; }
        public int? PostalCode { get; set; }
        public DateTime? Birthday { get; set; }
        public SexView Sex { get; set; }
        public BehaviourView Behaviour { get; set; }
    }
}