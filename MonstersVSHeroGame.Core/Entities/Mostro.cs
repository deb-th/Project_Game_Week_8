using MonstersVSHeroGame.Core.Entities.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Entities
{
    public class Mostro : Personaggio
    {
        //Costruttore
        public Mostro(string nome, string classe, string arma) : base(nome, classe, arma)
        {

        }
        public Mostro(string nome, string classe, string arma, int puntiVita, int livello) : base(nome, classe, arma)
        {
            PuntiVita = puntiVita;
            Livello = livello;
        }

        public void attack(Hero hero)
        {
            //hero.PuntiVita -= Arma.PuntiDanno;
        }
    }
}