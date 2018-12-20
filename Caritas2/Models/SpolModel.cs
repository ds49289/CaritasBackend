using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.Models
{
    public class SpolModel
    {
        public int Id { get; set; }
        public string NazivSpola { get; set; }
        public Boolean AktivnostSpola { get; set; }

        public ICollection<KorisnikModel> Korisnici { get; set; }
    }
}