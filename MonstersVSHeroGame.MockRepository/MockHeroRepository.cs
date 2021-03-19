using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.MockRepository
{
    public class MockHeroRepository : IHeroRepository
    {

        public List<Hero> heros = new List<Hero>()
        {
            new Hero("Cagliostro", "Guerriero", "Fucile", new Giocatore("Luca")),
            new Hero("Merlino", "Mago", "Spada", new Giocatore("Mario"))
        };

        public void Create(Hero obj)
        {
            heros.Add(obj);
        }

        public bool Delete(Hero obj)
        {
            try
            {
                foreach (var hero in heros)
                {
                    if (hero.Nome == obj.Nome)
                    {
                        heros.Remove(obj);
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Eliminazione Fallita", e);
            }
            return false;
        }

        public IEnumerable<Hero> GetAll()
        {
            return heros;
        }

        public Hero GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Hero GetByName(string name)
        {
            foreach (var hero in heros)
            {
                if (hero.Nome == name)
                {
                    return hero;
                }
            }
            return null;
        }

        public bool Update(Hero obj)
        {
            throw new NotImplementedException();
        }
    }
}
