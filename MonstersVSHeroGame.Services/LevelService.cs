using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Services
{
    public class LevelService
    {
        private ILevelRepository _repo;

        public LevelService(ILevelRepository repo)
        {
            _repo = repo;
        }

        public Level GetLevel(int ID)
        {
            if (ID != null)
            {
                var level = _repo.GetByID(ID);
                return level;
            }
            else
            {
                return null;
            }
        }
    }
}
