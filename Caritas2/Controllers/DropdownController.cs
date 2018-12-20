using Caritas2.BusinessLogicLayer.Models;
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
    public class DropdownController: ApiController
    {
        private CaritasService service;
        private DropdownMapper mapper;

        private DropdownController()
        {
            this.service = new CaritasService();
            this.mapper = new DropdownMapper();
        }


        //public IHttpActionResult 
        //return Ok(response)
        //return NotFound, return InternalServerError()
        [HttpGet]
        [Route("Spolovi")]
        public IEnumerable<SexView> GetAllSpolovi()
        {

            var result = service.GetAllSpolovi();
            var response = mapper.MapSexModelCollectionToSexViewCollection(result);
            return response;
        }

        [HttpGet]
        [Route("Spol/{id}")]
        public SpolModel GetSpolForId(int ID)
        {
            var result = service.GetSpolForId(ID);

            return result;
        }

        [HttpGet]
        [Route("Ponasanja")]
        public IEnumerable<BehaviourView> GetAllPonasanja()
        {
            var result = service.GetAllPonasanja();
            var response = mapper.MapBehaviourModelCollectionToBehaviourViewCollection(result);
            return response;
        }

        [HttpGet]
        [Route("Ponasanje")]
        public PonasanjeModel GetPonasanjeForId(int ID)
        {
            var result = service.GetPonasanjeForId(ID);

            return result;
        }

    }
}