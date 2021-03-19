using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.MockRepository
{
    public class MockGiocatoreRepository : IGiocatoreRepository
    {
        public List<Giocatore> giocatori = new List<Giocatore>()
        {
            new Giocatore("Luca"),
            new Giocatore("Mario")
        };

        public void Create(Giocatore obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Giocatore obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giocatore> GetAll()
        {
            throw new NotImplementedException();
        }

        public Giocatore GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Giocatore GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Giocatore obj)
        {
            throw new NotImplementedException();
        }
    }
}
