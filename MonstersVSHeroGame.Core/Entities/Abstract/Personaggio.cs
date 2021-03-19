using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Entities.Abstact
{
    public abstract class Personaggio
    {
        //Proprietà
        public string Nome { get; set; }
        public string Classe { get; set; }
        public string Arma { get; set; }
        public int PuntiVita { get; set; }
        public int Livello { get; set; }

        //Costruttore
        public Personaggio(string nome, string classe, string arma)
        {
            Nome = nome;
            Classe = classe;
            Arma = arma;
            PuntiVita = 20;
            Livello = 1;
        }
    }
}
