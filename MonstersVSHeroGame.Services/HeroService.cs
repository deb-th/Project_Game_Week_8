using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace MonstersVSHeroGame.Services
{
    public class HeroService
    {
        private IHeroRepository _repo;

        public HeroService(IHeroRepository repo)
        {
            _repo = repo;
        }

        public Hero CreateHero(Hero hero)
        {
            
            if (hero != null)
            {
                _repo.Create(hero);
                return hero;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Hero> GetAllHeros()
        {
            return _repo.GetAll();
        }

        public bool DeleteHero(Hero hero)
        {
            return _repo.Delete(hero);
        }

        public Hero GetHero(string nome)
        {
            if (nome != null)
            {
                var hero = _repo.GetByName(nome);
                return hero;
            }
            else
            {
                return null;
            }
        }

        public bool UpdateHero(Hero hero)
        {
            return _repo.Update(hero);
        }
    }
}
