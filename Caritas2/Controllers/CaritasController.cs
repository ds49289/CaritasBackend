using Caritas2.BusinessLogicLayer.Models;
using Caritas2.Filters;
using Caritas2.Mappers;
using Caritas2.Models;
using Caritas2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Caritas2.Controllers
{
    public class CaritasController: ApiController
    {
        private CaritasService service;
        private UserMapper mapper ;

        public CaritasController()
        {
            this.service = new CaritasService();
            this.mapper = new UserMapper();
        }

        #region Spol
        //[HttpGet]
        //[Route("Spolovi")]
        //public List<SpolModel> GetAllSpolovi()
        //{
        //    var result = service.GetAllSpolovi();

        //    return result;
        //}

        //[HttpGet]
        //[Route("Spol")]
        //public SpolModel GetSpolForId(int ID)
        //{
        //    var result = service.GetSpolForId(ID);

        //    return result;
        //}

        //[HttpPost]
        //[Route("Spol")]
        //public Boolean InsertSpol(SpolModel spolModel)
        //{
        //    var result = service.InsertSpol(spolModel);

        //    return result;
        //}

        //[HttpPut]
        //[Route("Spol")]
        //public Boolean UpdateSpol(SpolModel spolModel)
        //{
        //    var result = service.UpdateSpol(spolModel);

        //    return result;
        //}

        //[HttpDelete, Route("Spol/{ID}")]
        //public Boolean DeleteSpol(int ID)
        //{
        //    var result = service.DeleteSpol(ID);

        //    return result;
        //}
        #endregion

        #region Ponasanje
        //[HttpGet]
        //[Route("Ponasanja")]
        //public List<PonasanjeModel> GetAllPonasanja()
        //{
        //    var result = service.GetAllPonasanja();

        //    return result;
        //}

        //[HttpGet]
        //[Route("Ponasanje")]
        //public PonasanjeModel GetPonasanjeForId(int ID)
        //{
        //    var result = service.GetPonasanjeForId(ID);

        //    return result;
        //}

        //[HttpPost]
        //[Route("Ponasanje")]
        //public Boolean InsertPonasanje(PonasanjeModel ponasanjeModel)
        //{
        //    var result = service.InsertPonasanje(ponasanjeModel);

        //    return result;
        //}

        //[HttpPut]
        //[Route("Ponasanje")]
        //public Boolean UpdatePonasanje(PonasanjeModel ponasanjeModel)
        //{
        //    var result = service.UpdatePonasanje(ponasanjeModel);

        //    return result;
        //}

        //[HttpDelete, Route("Ponasanje/{ID}")]
        //public Boolean DeletePonasanje(int ID)
        //{
        //    var result = service.DeletePonasanje(ID);

        //    return result;
        //}
        #endregion

        #region Korisnik
        [HttpGet]
        [Route("Korisnici")]
        public IEnumerable<UserView> GetAllKorisnici(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var result = service.GetAllKorisnici(pageIndex, pageSize, sortColumn, sortOrder);
            var response = mapper.MapUserCollectionToUserViewCollection(result);

            return response;
        }

        [HttpGet]
        [Route("Korisnici/Count")]
        public int GetUserCount()
        {
            var result = service.GetUserCount();
            return result;
        }

        [HttpGet]
        [Route("Korisnik")]
        public UserView GetKorisnikForId(int ID)
        {
            var result = service.GetKorisnikForId(ID);
            var response = mapper.MapUserToUserView(result);

            return response;
        }

        [HttpGet]
        [Route("Korisnici/Filter")]
        public UserFilterResponse GetFilteredUsers([FromUri] UserFilter filter, int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var filterCount = 0;
            var result = service.GetFilteredUsers(filter, pageIndex,pageSize, sortColumn, sortOrder, out filterCount);
            var data = mapper.MapUserCollectionToUserViewCollection(result);
            var response = new UserFilterResponse()
            {
                FilterCount = filterCount,
                UserData = data
            };

            return response;
        }

        [HttpPost]
        [Route("Korisnik")]
        public Boolean InsertKorisnik([FromBody] UserView userView)
        {
            var map = mapper.MapUserViewToUserModel(userView);
            var result = service.InsertKorisnik(map);

            return result;
        }

        [HttpPut]
        [Route("Korisnik")]
        public Boolean UpdateKorisnik(KorisnikModel korisnikModel)
        {
            var result = service.UpdateKorisnik(korisnikModel);

            return result;
        }

        [HttpDelete, Route("Korisnik/{ID}")]
        public Boolean DeleteKorisnik(int ID)
        {
            var result = service.DeleteKorisnik(ID);

            return result;
        }


        #endregion 
    }
}