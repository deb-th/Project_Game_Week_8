using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace MonstersVSHeroGame
{
    /// <summary>
    ///     Classe Helper - una classe di aiuto che implementa altri metodi più interni al gioco
    /// </summary>
    public class Helper
    {
        public static void Menu()
        {
            //menù funzionalità
            Console.WriteLine("Premi 1 - Creare un nuovo eroe");
            Console.WriteLine("Premi 2 - Eliminare un tuo eroe");
            Console.WriteLine("Premi 3 - Continuare la partita con un tuo eroe esistente");
            Console.WriteLine("Premi q - Uscire");
        }

        /// <summary>
        ///     Metodo SelectMostro che seleziona il mostro
        ///     avversario dell'eroe in base al livello
        /// </summary>
        /// <returns> 
        ///     Mostro selectedMostro - mostro con il livelle minore
        ///                             o uguale al livello dell'eroe
        /// </returns>
        public static Mostro SelectMostro(Hero hero, IEnumerable<Mostro> mostri)
        {
            Mostro selectedMostro = null;
            foreach (var m in mostri)
            {
                if (m.Livello <= hero.Livello)
                {
                    selectedMostro = m;
                }
            }
            return selectedMostro;
        }

        /// <summary>
        ///     Metodo Play che stabilisce Random
        ///     l'esito dello scontro tra il mostro e l'eroe
        /// </summary>
        /// <returns> 
        ///     bool success - risultato dello scontro eroe e mostro
        ///                    TRUE: se vince l'eroe!
        ///                    FALSE: se vince il mostro!
        /// </returns>
        public static bool Play()
        {
            Random random = new Random();
            int numRandom = random.Next(0, 101);
            bool success;

            if(numRandom % 2 == 0)
            {
                success = true;
            }
            else
            {
                success = false;
            }
            return success;
        }

        /// <summary>
        ///     Metodo CheckWin che verifica i progressi dell'eroe e li aggiorna.
        ///     Nel caso abbia terminato i punti vita l'eroe viene eliminato
        /// </summary>
        public static void CheckWin(Hero hero)
        {
            var serviceProvider = DIConfig.Config();
            HeroService heroService = serviceProvider.GetService<HeroService>();

            //Controllo punteggi finali di partita
            if (hero.PuntiAccumulati >= 200)
            {
                Console.WriteLine("Partita Conclusa! HAI VINTO!!!");
                Console.ReadLine();
                //utilizzo ReadLine nel codice per non chiudere brutalmente il programma
                //senza poter visualizzare un messaggio idoneo
            }
            else if (hero.PuntiVita <= 0)
            {
                heroService.DeleteHero(hero);
                Console.WriteLine("Partita Conclusa! HAI PERSO!!!Il tuo eroe è stato eliminato definitivamente");
                Console.ReadLine();
                //utilizzo ReadLine nel codice per non chiudere brutalmente il programma
                //senza poter visualizzare un messaggio idoneo
            }
            //else
            //{
            //    Console.WriteLine("Progressi aggiornati! Premi un tasto per continuare!");
            //    Console.ReadLine();
            //    //utilizzo ReadLine nel codice per non chiudere brutalmente il programma
            //    //senza poter visualizzare un messaggio idoneo
            //}
        }

        /// <summary>
        ///     Metodo CheckGiocatore 
        ///     che verifica se si tratti di un giocatore esistente nel database o di un nuovo giocatore.
        ///     Nel caso di nuovo giocatore lo si aggiunge nel database.                           
        /// </summary>
        public static void CheckGiocatore(Giocatore giocatore)
        {
            var serviceProvider = DIConfig.Config();

            GiocatoreService giocatoreService = serviceProvider.GetService<GiocatoreService>();

            //cerco il giocatore nel database
            var g = giocatoreService.GetGiocatore(giocatore.Nome);

            if (g != null && g.Nome == giocatore.Nome)
            {
                //giocatore esistente
                Console.WriteLine("Bentornato!! Start Game!");
            }
            else
            {
                //si tratta di un nuovo utente
                giocatoreService.CreateGiocatore(giocatore);
                Console.WriteLine("Benvenuto!! Start Game!");
            }
        }

    }
}