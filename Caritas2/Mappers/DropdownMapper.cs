using Caritas2.Models;
using Caritas2.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.Mappers
{
    public class DropdownMapper
    {

        public SexView MapSexModelToSexView(SpolModel sex)
        {
            var result = new SexView
            {
                Id = sex.Id,
                Name = sex.NazivSpola,
                Activity = sex.AktivnostSpola
            };

            return result;
        }

        public BehaviourView MapBehaviourModelToBehaviourView(PonasanjeModel behaviour)
        {
            var result = new BehaviourView
            {
                Id = behaviour.Id,
                Name = behaviour.NazivPonasanja,
                Activity = behaviour.AktivnostPonasanja
            };
            return result;
        }

        public IEnumerable<SexView> MapSexModelCollectionToSexViewCollection(IEnumerable<SpolModel> sexes)
        {
            var result = new List<SexView>();
            foreach(var sex in sexes)
            {
                result.Add(MapSexModelToSexView(sex));
            }
            return result;
        }

        public IEnumerable<BehaviourView> MapBehaviourModelCollectionToBehaviourViewCollection(IEnumerable<PonasanjeModel> behs)
        {
            var result = new List<BehaviourView>();
            foreach (var beh in behs)
            {
                result.Add(MapBehaviourModelToBehaviourView(beh));
            }
            return result;
        }

        //public SpolModel MapSexViewToSexModel(SexView view)
        //{
        //    var result = new SexView
        //    {
        //        Id = view.Id,
        //        Name = view.Name,
        //        Activity = view.Activity

        //    };
        //    return result;
        //}
    }
}