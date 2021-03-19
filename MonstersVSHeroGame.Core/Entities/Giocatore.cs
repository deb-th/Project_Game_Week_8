using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Entities
{
    public class Giocatore
    {
        //Proprietà
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Ruolo { get; set; } //Utente o Admin

        private int IDSeed = 0;

        //Costruttore
        public Giocatore(string nome)
        {
            ID = IDSeed + 1;
            Nome = nome;
            Ruolo = "Utente";
            IDSeed++;
        }
    }
}
