using MonstersVSHeroGame.Core.Entities.Abstact;
using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Entities
{
    public class Hero : Personaggio
    {
        //Proprietà Specifiche
        public int PuntiAccumulati { get; set; }
        //public DateTime DurataGioco { get; set; } //Tempo totale di Gioco dell'Eroe
        public Giocatore Giocatore { get; set; }

        //Costruttore
        public Hero(string nome, string classe, string arma, Giocatore giocatore) : base(nome, classe, arma)
        {
            PuntiAccumulati = 0;
            Giocatore = giocatore;
        }

        public Hero(string nome, string classe, string arma, int puntiVita, int livello, int puntiAccumulati, Giocatore giocatore) : base(nome, classe, arma)
        {
            PuntiVita = puntiVita;
            PuntiAccumulati = puntiAccumulati;
            Livello = livello;
            Giocatore = giocatore;
        }

        //Override di metodi derivati
        public void attack(Mostro mostro)
        {
            PuntiAccumulati += mostro.Livello * 10;
        }

        //Metodi Specifici
        public void escape(Mostro mostro)
        {
            PuntiAccumulati -= mostro.Livello * 5;
        }
    }
}
