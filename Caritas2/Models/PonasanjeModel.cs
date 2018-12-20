using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.Models
{
    public class PonasanjeModel
    {
        public int Id { get; set; }
        public string NazivPonasanja { get; set; }
        public Boolean AktivnostPonasanja { get; set; }

        public ICollection<KorisnikModel> Korisnici { get; set; }


    }
}