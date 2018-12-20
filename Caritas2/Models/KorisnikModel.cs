using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Caritas2.Models
{
    public class KorisnikModel
    {

        public int Id { get; set; }
        public string Username { get; set; }
        public string ImeKorisnika { get; set; }
        public string PrezimeKorisnika { get; set; }
        public string OIB { get; set; }
        public string EmailKorisnika { get; set; }
        public int? PostanskiBroj { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        

        public virtual PonasanjeModel Ponasanje { get; set; }
        public int? PonasanjeID { get; set; }

        
        public virtual SpolModel Spol { get; set; }
        public Nullable<int> SpolID { get; set; }
    }
}