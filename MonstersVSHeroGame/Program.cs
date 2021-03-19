using MonstersVSHeroGame.Services;
using System;
using Microsoft.Extensions.DependencyInjection;
using MonstersVSHeroGame.Core.Entities;

namespace MonstersVSHeroGame
{
    class Program
    {
        /// <summary>
        ///     Metodo Principale del programma per l'Implementazione dell'interazione con Giocatore Utente mediante Console
        ///     Admin, i livelli e le statistiche non sono state ancora gestite - Problema con l'update
        /// </summary>
        static void Main(string[] args)
        {
            //MESSAGGI ALL'APERTURA DEL GIOCO
            Console.WriteLine("Monsters VS Hero!");
            Console.WriteLine("Inserisci il tuo nome!");
            string nome = Console.ReadLine();
            
            //crazione dell'oggetto giocatore protagonista
            var giocatore = new Giocatore(nome);

            //Controllo se il giocatore UTENTE è già presente nel database o se si tratta di un nuovo Utente
            Helper.CheckGiocatore(giocatore);

            //GAME

            string quit;
            do
            {
                Partita.Start(giocatore); //Chiamo il metodo che avvia il Gioco

                Console.WriteLine("Uscire dal gioco? (SI o NO)");
                quit = Console.ReadLine().ToString();

                //Viene mostrato il menù principale del Game fin quando il giocatore non decide di usciredefinitivamente dal gioco.
            } while (quit != "SI");

            //FINE

            //Il giocatore ha deciso di uscire dal gioco
            Console.WriteLine("Arrivederci!");
        }
    }
}