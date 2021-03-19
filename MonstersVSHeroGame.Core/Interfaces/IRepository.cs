using MonstersVSHeroGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Interfaces
{
    public interface IRepository<T>
    {
        void Create(T obj);
        T GetByID(int ID);
        T GetByName(string name);
        IEnumerable<T> GetAll();
        bool Update(T obj);
        bool Delete(T obj);
    }
}