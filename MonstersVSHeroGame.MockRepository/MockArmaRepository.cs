using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.MockRepository
{
    public class MockArmaRepository : IArmaRepository
    {
        public List<Arma> armi = new List<Arma>()
        {
            new Arma() { Classe = "Guerriero", Nome = "Fucile", PuntiDanno = 20 },
            new Arma() { Classe = "Mago", Nome = "Spada", PuntiDanno = 10 },
            new Arma() { Classe = "Orco", Nome = "Clava", PuntiDanno = 10 },
            new Arma() { Classe = "SignoreDelMale", Nome = "Spadone", PuntiDanno = 10 }
        };

        public void Create(Arma obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAll()
        {
            return armi;
        }

        public Arma GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Arma GetByName(string name)
        {
            foreach (var arma in armi)
            {
                if (arma.Nome == name)
                {
                    return arma;
                }
            }
            return null;
        }

        public bool Update(Arma obj)
        {
            throw new NotImplementedException();
        }
    }
}
