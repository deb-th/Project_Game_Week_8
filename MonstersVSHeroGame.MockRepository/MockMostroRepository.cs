using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.MockRepository
{
    public class MockMostroRepository : IMostroRepository
    {
        public List<Mostro> mostri = new List<Mostro>()
        {
            new Mostro("Azuk", "Orco", "Clava"),
            new Mostro("Strong", "SignoreDelMale", "Spadone")
        };
        public void Create(Mostro obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Mostro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mostro> GetAll()
        {
            return mostri;
        }

        public Mostro GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Mostro GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Mostro obj)
        {
            throw new NotImplementedException();
        }
    }
}