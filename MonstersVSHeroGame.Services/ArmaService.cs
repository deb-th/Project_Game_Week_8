using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Services
{
    public class ArmaService
    {
        private IArmaRepository _repo;

        public ArmaService(IArmaRepository repo)
        {
            _repo = repo;
        }

        public Arma GetArma(string name)
        {
            if (name != null)
            {
                var arma = _repo.GetByName(name);
                return arma;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Arma> GetAllArmi()
        {
            return _repo.GetAll();
        }
    }
}
