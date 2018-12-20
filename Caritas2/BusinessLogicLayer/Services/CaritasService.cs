using Caritas2.Filters;
using Caritas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caritas2.BusinessLogicLayer.Models
{
    public class CaritasService
    {
        public CaritasDbContext context;
        public CaritasService()
        {
            this.context = new CaritasDbContext();
        }


        #region Spol

        public List<SpolModel> GetAllSpolovi()
        {
            var query = context.Spolovi.OrderBy(x => x.NazivSpola);
            return query.ToList();
        }
        
        public SpolModel GetSpolForId(int SpolId)
        {
            var query = context.Spolovi.SingleOrDefault(x => x.Id == SpolId);
            if (query == null)
            {
                throw new Exception("Spol traženog Id-a nije pronađen");
            }
            return query;
        }

        public bool UpdateSpol(SpolModel spolModel)
        {
            var query = context.Spolovi.SingleOrDefault(x => x.Id == spolModel.Id);
            if (query != null)
            {
                query.NazivSpola = spolModel.NazivSpola;
                query.AktivnostSpola = spolModel.AktivnostSpola;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean InsertSpol(SpolModel spolModel)
        {
            var query = context.Spolovi.SingleOrDefault(x => x.Id == spolModel.Id);
            if (query != null)
            {
                return false;
            }
            context.Spolovi.Add(spolModel);
            context.SaveChanges();
            return true;
        }

        public Boolean DeleteSpol(int Id)
        {
            var query = context.Spolovi.SingleOrDefault(x => x.Id == Id);
            if (query != null)
            {
                context.Spolovi.Remove(query);
                context.SaveChanges();
                return true;
            }
            return false;
        }
        #endregion

        #region Ponasanje

        public List<PonasanjeModel> GetAllPonasanja()
        {
            var query = context.Ponasanja.OrderBy(x=>x.NazivPonasanja);
            return query.ToList();
        }

        public PonasanjeModel GetPonasanjeForId(int Id)
        {
            var query = context.Ponasanja.SingleOrDefault(x => x.Id == Id);
            if(query != null)
            {
                return query;
            }
            throw new Exception("Ponasanje za trazeni Id nije pronađeno.");
        }

        public Boolean UpdatePonasanje(PonasanjeModel ponasanjeModel)
        {
            var query = context.Ponasanja.SingleOrDefault(x => x.Id == ponasanjeModel.Id);
            if (query != null)
            {
                query.NazivPonasanja = ponasanjeModel.NazivPonasanja;
                query.AktivnostPonasanja = ponasanjeModel.AktivnostPonasanja;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean InsertPonasanje(PonasanjeModel ponasanjeModel)
        {
            var query = context.Ponasanja.SingleOrDefault(x => x.Id == ponasanjeModel.Id);
            if(query == null)
            {
                context.Ponasanja.Add(ponasanjeModel);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean DeletePonasanje(int Id)
        {
            var query = context.Ponasanja.SingleOrDefault(x => x.Id == Id);
            if(query != null)
            {
                context.Ponasanja.Remove(query);
                context.SaveChanges();
                return true;
            }
            return false;
        }


        #endregion

        #region Korisnik

        public List<KorisnikModel> GetAllKorisnici(int pageIndex, int pageSize, string sortColumn, string sortOrder)
        {
            var sortedQuery = SortUserCollection(sortColumn, sortOrder);

            var paginatedQuery = sortedQuery.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IEnumerable<KorisnikModel> GetFilteredUsers(UserFilter filter, int pageIndex, int pageSize, string sortColumn, string sortOrder, out int filterCount)
        {
            var filteredQuery = FilterQuery(filter);

            var sortedQuery = SortQuery(filteredQuery,sortColumn, sortOrder);

            filterCount = sortedQuery.Count();

            var paginatedQuery = sortedQuery.Skip(pageIndex * pageSize).Take(pageSize);

            return paginatedQuery.ToList();
        }

        public IQueryable<KorisnikModel> FilterQuery(UserFilter filter)
        {
            var filteredQuery = context.Korisnici.Where(v => true);

            if(filter.Name != null)
            {
                filteredQuery = filteredQuery.Where(v => v.ImeKorisnika.Contains(filter.Name));
            }
            if (filter.Surname != null)
            {
                filteredQuery = filteredQuery.Where(v => v.PrezimeKorisnika.Contains(filter.Surname));
            }
            if (filter.Oib != null)
            {
                filteredQuery = filteredQuery.Where(v => v.OIB.Contains(filter.Oib));
            }
            if (filter.Username != null)
            {
                filteredQuery = filteredQuery.Where(v => v.Username.Contains(filter.Username));
            }
            if (filter.PostalCode != null)
            {
                filteredQuery = filteredQuery.Where(v => v.PostanskiBroj.ToString().Contains(filter.PostalCode.ToString()));
            }
            if (filter.Birthday != null)
            {
                filteredQuery = filteredQuery.Where(v => v.DatumRodjenja == filter.Birthday);
            }
            if (filter.SexId != null)
            {
                filteredQuery = filteredQuery.Where(v => v.SpolID == filter.SexId);
            }
            if (filter.BehaviourId != null)
            {
                filteredQuery = filteredQuery.Where(v => v.PonasanjeID== filter.BehaviourId);
            }
            if (filter.Email != null)
            {
                filteredQuery = filteredQuery.Where(v => v.EmailKorisnika.Contains(filter.Email));
            }
            return filteredQuery;
        }

        public IQueryable<KorisnikModel> SortQuery(IQueryable<KorisnikModel> filteredQuery, string sortColumn, string sortOrder)
        {
            if (sortOrder == null || sortColumn == null)
            {
                return filteredQuery.OrderBy(x => x.Id);
            }
            switch (sortColumn)
            {
                case "name":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.ImeKorisnika) : filteredQuery.OrderByDescending(x => x.ImeKorisnika);
                case "surname":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.PrezimeKorisnika) : filteredQuery.OrderByDescending(x => x.PrezimeKorisnika);
                case "oib":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.OIB) : filteredQuery.OrderByDescending(x => x.OIB);
                case "email":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.EmailKorisnika) : filteredQuery.OrderByDescending(x => x.EmailKorisnika);
                case "postalCode":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.PostanskiBroj) : filteredQuery.OrderByDescending(x => x.PostanskiBroj);
                case "birthday":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.DatumRodjenja) : filteredQuery.OrderByDescending(x => x.DatumRodjenja);
                case "username":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.Username) : filteredQuery.OrderByDescending(x => x.Username);
                case "sex":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.Spol.NazivSpola) : filteredQuery.OrderByDescending(x => x.Spol.NazivSpola);
                case "behaviour":
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.Ponasanje.NazivPonasanja) : filteredQuery.OrderByDescending(x => x.Ponasanje.NazivPonasanja);
                default:
                    return sortOrder.Equals("asc") ? filteredQuery.OrderBy(x => x.Id) : filteredQuery.OrderByDescending(x => x.Id);

            }
        }

        public IOrderedQueryable<KorisnikModel> SortUserCollection(string sortColumn, string sortOrder)
        {
            if(sortOrder == null || sortColumn == null)
            {
                return context.Korisnici.OrderBy(x => x.Id);
            }
            switch (sortColumn)
            {
                case "name":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.ImeKorisnika) : context.Korisnici.OrderByDescending(x => x.ImeKorisnika);
                case "surname":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.PrezimeKorisnika) : context.Korisnici.OrderByDescending(x => x.PrezimeKorisnika);
                case "oib":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.OIB) : context.Korisnici.OrderByDescending(x => x.OIB);
                case "email":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.EmailKorisnika) : context.Korisnici.OrderByDescending(x => x.EmailKorisnika);
                case "postalCode":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.PostanskiBroj) : context.Korisnici.OrderByDescending(x => x.PostanskiBroj);
                case "birthday":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.DatumRodjenja) : context.Korisnici.OrderByDescending(x => x.DatumRodjenja);
                case "username":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.Username) : context.Korisnici.OrderByDescending(x => x.Username);
                case "sex":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.Spol.NazivSpola) : context.Korisnici.OrderByDescending(x => x.Spol.NazivSpola);
                case "behaviour":
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.Ponasanje.NazivPonasanja) : context.Korisnici.OrderByDescending(x => x.Ponasanje.NazivPonasanja);
                default:
                    return sortOrder.Equals("asc") ? context.Korisnici.OrderBy(x => x.Id) : context.Korisnici.OrderByDescending(x => x.Id);
            }
        }

        public int GetUserCount()
        {
            var query = context.Korisnici.Count();
            return query;
        }

        public KorisnikModel GetKorisnikForId(int Id)
        {
            var query = context.Korisnici.SingleOrDefault(x => x.Id == Id);
            if (query != null)
            {
                return query;
            }
            throw new Exception("Nije pronađen korisnik za Id " + Id);
        }

        public Boolean UpdateKorisnik(KorisnikModel korisnikModel)
        {
            var query = context.Korisnici.SingleOrDefault(x => x.Id == korisnikModel.Id);
            if (query != null)
            {
                query.ImeKorisnika = korisnikModel.ImeKorisnika;
                query.PrezimeKorisnika = korisnikModel.PrezimeKorisnika;
                query.PostanskiBroj = korisnikModel.PostanskiBroj;
                query.OIB = korisnikModel.OIB;
                query.DatumRodjenja = korisnikModel.DatumRodjenja;
                query.EmailKorisnika = korisnikModel.EmailKorisnika;
                query.Spol.NazivSpola = korisnikModel.Spol.NazivSpola;
                query.Spol.AktivnostSpola = korisnikModel.Spol.AktivnostSpola;
                query.Ponasanje.NazivPonasanja = korisnikModel.Ponasanje.NazivPonasanja;
                query.Ponasanje.AktivnostPonasanja = korisnikModel.Ponasanje.AktivnostPonasanja;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean InsertKorisnik(KorisnikModel korisnikModel)
        {
            var query = context.Korisnici.SingleOrDefault(x => x.Id == korisnikModel.Id);
            var exist = context.Korisnici.SingleOrDefault(x => x.ImeKorisnika == korisnikModel.ImeKorisnika && x.PrezimeKorisnika == korisnikModel.PrezimeKorisnika && x.OIB == korisnikModel.OIB);
            if (query == null && exist == null)
            {
                context.Korisnici.Add(korisnikModel);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public Boolean DeleteKorisnik(int Id)
        {
            var query = context.Korisnici.SingleOrDefault(x => x.Id == Id);
            if(query == null)
            {
                return false;
            }
            context.Korisnici.Remove(query);
            context.SaveChanges();
            return true;
        }
        #endregion
    }
}