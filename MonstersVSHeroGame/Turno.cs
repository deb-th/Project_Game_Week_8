using MonstersVSHeroGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using MonstersVSHeroGame.Services;

namespace MonstersVSHeroGame
{
    /// <summary>
    ///     Classe Turno che implementa i metodi utili per l'esucuzione
    ///     degli scontri tra eroe e mostri
    /// </summary>
    public class Turno
    {
        /// <summary>
        ///     Metodo Game che richiama il metodo Turno.Set
        ///                 per giocare i vari turni che compongono la partita
        ///                 dell'eroe scelto dal giocatore
        /// </summary>
        public static void Game(Hero hero, IEnumerable<Mostro> mostri, Giocatore giocatore)
        {
            var serviceProvider = DIConfig.Config();
            HeroService heroService = serviceProvider.GetService<HeroService>();
            Hero updatedHero = hero;
            int pVitaTotali = 0;
            int puntiTotali = 0;
            string q;
            bool turno = true; //a inizio partita è sempre il turno dell'eroe
            bool result;
           
            do
            {
                result = Turno.Set(ref hero, mostri, turno);

                if (result == true)
                {
                    puntiTotali = hero.PuntiAccumulati;
                    Console.WriteLine("Il tuo eroe ha sconfitto il mostro e ha accumulato " + hero.PuntiAccumulati + " punti!");
                    //tocca ancora all'eroe
                    turno = true;
                }
                else
                {
                    pVitaTotali = hero.PuntiVita;
                    Console.WriteLine("Il tuo eroe ha perso! Gli sono rimasti ancora " + hero.PuntiVita + " punti vita!");
                    //allora è il turno del mostro
                    turno = false;
                }

                updatedHero = new Hero(hero.Nome, hero.Classe, hero.Arma, pVitaTotali, hero.Livello, puntiTotali, giocatore);

                Console.WriteLine("Continuare la partita? (SI o NO)");
                q = Console.ReadLine().ToString();

            } while (q != "NO");

            //il giocatore ha deciso di terminare la partita e salvare i progressi
            //quindi si procede all'aggiornamento dei progressi nel database
            //e al controllo generale del punteggio

            //Controllo punteggio
            Helper.CheckWin(updatedHero);

            Console.WriteLine("Salvare i progressi? (SI o NO)");
            string s = Console.ReadLine().ToString();

            if (s == "SI")
            {
                //Salvataggio progressi
                heroService.UpdateHero(updatedHero);
            }
        }

        /// <summary>
        ///     Metodo Set che in base a chi tocca tra mostro e eroe
        ///     chiama le operazioni corrispettive per eseguire lo scontro
        ///     e stabilire la vittoria o meno dell'eroe.
        /// </summary>
        /// <returns> 
        ///     bool 'turno' - TRUE: al prossimo turno tocca all'eroe
        ///                    FALSE: al prossimo turno tocca al mostro attaccare
        /// </returns>
        public static bool Set(ref Hero hero, IEnumerable<Mostro> mostri, bool turno)
        {
            Mostro mostro = Helper.SelectMostro(hero, mostri);

            if (turno == true) 
            {
                return TurnoEroe(ref hero, mostro); //turno del giocatore
            }
            else
            {
                return TurnoMostro(ref hero, mostro); //altrimenti turno del mostro
            }
        }

        /// <summary>
        ///     Metodo TurnoEroe - è il turno dell'eroe e deve scegliere l'azione da eseguire nei confronti
        ///                        del mostro per provare a superare il turno.
        ///                        - Attaccare il mostro!
        ///                        - Tentare la fuga!
        /// </summary>
        /// <returns> 
        ///     bool heroWin - TRUE: se l'eroe ha vinto lo scontro e al prossimo turno tocca sempre a lui
        ///                    FALSE: se l'eroe ha perso e al prossimo turno tocca al mostro attaccare
        /// </returns>
        public static bool TurnoEroe(ref Hero hero, Mostro mostro)
        {

            var serviceProvider = DIConfig.Config();
            ArmaService armaService = serviceProvider.GetService<ArmaService>();
            //turno Giocatore
            Console.WriteLine("Tocca a te Eroe! Scegli la tua mossa!");
            Console.WriteLine("1 - per Attaccare il mostro!");
            Console.WriteLine("2 - per tentare la Fuga dal mostro!");

            bool IsCorrectUserInput = Int32.TryParse(Console.ReadLine(), out int key);
            Console.WriteLine();

            bool heroWin = false;

            if (IsCorrectUserInput)
            {
                switch (key)
                {
                    case 1: //Giocatore Attacca il Mostro

                        Arma armaMostro = armaService.GetArma(mostro.Arma);

                        //Scontro con risultato random
                        heroWin = Helper.Play(); //l'eroe ha attaccato il mostro                        

                        if (heroWin == true) //eroe ha vinto
                        {
                            hero.attack(mostro); //arreca danni al mostro
                            //heroWin TRUE
                        }
                        else 
                        {
                            //ha vinto il mostro
                            //hero subisce danni
                            hero.PuntiVita -= armaMostro.PuntiDanno;
                            //heroWin FALSE eroe ha perso
                        }
                        return heroWin;

                    case 2: //Giocatore decide di tentare la fuga!!

                        heroWin = Helper.Play(); //eroe tenta la fuga 

                        if (heroWin == true) //la fuga è andata a buon fine
                        {
                            hero.escape(mostro);
                            Console.WriteLine("La fuga è Riuscita, ma il tuo punteggio è " + hero.PuntiAccumulati);
                            return heroWin; //TRUE nel prossimo turno tocca ancora all'eroe
                        }
                        else //Se la fuga non va a buon fine l'eroe deve riaffrontare lo stesso mostro
                        {
                            Console.WriteLine("La fuga è Fallita! Devi riaffrontare lo stesso mostro! Scegli la tua prossima mossa");
                            return TurnoEroe(ref hero, mostro);
                        }
                }
            }
            return heroWin;
        }

        /// <summary>
        ///     Metodo TurnoMostro - è il turno del mostro che attacca l'eroe
        /// </summary>
        /// <returns> 
        ///     bool mWin - TRUE: se l'eroe ha vinto lo scontro e al prossimo turno tocca a lui
        ///                 FALSE: se l'eroe è stato sconfitto e al prossimo turno tocca sempre al mostro attaccare
        /// </returns>
        public static bool TurnoMostro(ref Hero hero, Mostro mostro)
        {
            //turno Mostro
            var serviceProvider = DIConfig.Config();
            ArmaService armaService = serviceProvider.GetService<ArmaService>();
            Arma armaMostro = armaService.GetArma(mostro.Arma);

            //Scontro con risultato random
            bool mWin = Helper.Play(); //il mostro ha attaccato l'eroe

            if (mWin == false) //ha vinto il mostro
            {
                //il mostro arreca danni all'eroe

                hero.PuntiVita -= armaMostro.PuntiDanno;

                return mWin; //FALSE il prossimo turno sarà sempre del mostro
            }
            else
            {
                //caso in cui ha vinto l'eroe

                hero.attack(mostro); //mostro subisce danni

                return mWin; //TRUE tocca all'eroe nel prossimo turno
            }
        }
    }
}