using Caritas2.Models;
using Caritas2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.Mappers
{
    public class UserMapper
    {
        public UserView MapUserToUserView(KorisnikModel user)
        {
            var result = new UserView
            {
                Id = user.Id,
                Name = user.ImeKorisnika,
                Surname = user.PrezimeKorisnika,
                Username = user.Username,
                Birthday = user.DatumRodjenja,
                Email = user.EmailKorisnika,
                OIB = user.OIB,
                PostalCode = user.PostanskiBroj,

                Behaviour = new BehaviourView
                {
                    Id = user.Ponasanje.Id,
                    Activity = user.Ponasanje.AktivnostPonasanja,
                    Name = user.Ponasanje.NazivPonasanja
                },


                Sex = new SexView
                {
                    Id = user.Spol.Id,
                    Activity = user.Spol.AktivnostSpola,
                    Name = user.Spol.NazivSpola
                }
            };
            return result;
        }
        public KorisnikModel MapUserViewToUserModel(UserView userView)
        {
            var result = new KorisnikModel
            {
                Id = userView.Id,
                ImeKorisnika = userView.Name,
                PrezimeKorisnika = userView.Surname,
                DatumRodjenja = userView.Birthday,
                OIB = userView.OIB,
                EmailKorisnika = userView.Email,
                PostanskiBroj = userView.PostalCode,
                Username = userView.Username, 
                PonasanjeID = userView.Behaviour.Id,
                SpolID = userView.Sex.Id
                
            };
            return result;
        }

        public IEnumerable<UserView> MapUserCollectionToUserViewCollection(IEnumerable<KorisnikModel> users)
        {
            List<UserView> list = new List<UserView>();
            foreach(KorisnikModel user in users)
            {
                list.Add(MapUserToUserView(user));
            }
            return list;
        }
    }
}