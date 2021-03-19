using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Services
{
    public class ClasseService
    {
        private IClasseRepository _repo;

        public ClasseService(IClasseRepository repo)
        {
            _repo = repo;
        }

        public Classe CreateClasse(Classe c)
        {
            if (c != null)
            {
                _repo.Create(c);
                return c;
            }
            else
            {
                return null;
            }
        }

        public IEnumerable<Classe> GetAllClassi()
        {
            return _repo.GetAll();
        }

        public Classe GetClasse(string nome)
        {
            if (nome != null)
            {
                var classe = _repo.GetByName(nome);
                return classe;
            }
            else
            {
                return null;
            }
        }
    }
}
