using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.MockRepository
{
    public class MockLevelRepository : ILevelRepository
    {
        public List<Level> livelli = new List<Level>()
        {
            new Level() { Livello = 1, PuntiVita = 20 },
            new Level() { Livello = 2, PuntiVita = 40 },
        };

        public void Create(Level obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Level obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Level> GetAll()
        {
            throw new NotImplementedException();
        }

        public Level GetByID(int ID)
        {
            foreach (var livello in livelli)
            {
                if (livello.Livello == ID)
                {
                    return livello;
                }
            }
            return null;
        }

        public Level GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Level obj)
        {
            throw new NotImplementedException();
        }
    }
}
