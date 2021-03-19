using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.MockRepository
{
    public class MockClasseRepository : IClasseRepository
    {
        public List<Classe> classi = new List<Classe>()
        {
            new Classe() { Nome = "Guerriero", Hero = true },
            new Classe() { Nome = "Mago", Hero = true },
            new Classe() { Nome = "Orco", Hero = false },
            new Classe() { Nome = "SignoreDelMale", Hero = false }
        };

        public void Create(Classe classe)
        {
            classi.Add(classe);
        }

        public bool Delete(Classe obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Classe> GetAll()
        {
            return classi;
        }

        public Classe GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Classe GetByName(string name)
        {
            foreach(var classe in classi)
            {
                if(classe.Nome == name)
                {
                    return classe;
                }
            }
            return null;
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
