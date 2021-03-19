using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Services
{
    public class GiocatoreService
    {
        private IGiocatoreRepository _repo;

        public GiocatoreService(IGiocatoreRepository repo)
        {
            _repo = repo;
        }
        public Giocatore CreateGiocatore(Giocatore giocatore)
        {

            if (giocatore != null)
            {
                _repo.Create(giocatore);
                return giocatore;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Giocatore> GetAllGiocatori()
        {
            return _repo.GetAll();
        }

        public Giocatore GetGiocatore(string nome)
        {
            if (nome != null)
            {
                var giocatore = _repo.GetByName(nome);
                return giocatore;
            }
            else
            {
                return null;
            }
        }
    }
}
