using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Services;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace MonstersVSHeroGame
{
    /// <summary>
    ///     Classe Partita che introduce il giocatore nel Game
    /// </summary>
    public class Partita
    {
        /// <summary>
        ///     Metodo Start che mostra il menù principale 
        ///     e fa partire il gioco
        /// </summary>
        public static void Start(Giocatore giocatore)
        {
            #region Dependency Injection
            var serviceProvider = DIConfig.Config();

            HeroService heroService = serviceProvider.GetService<HeroService>();
            ClasseService classeService = serviceProvider.GetService<ClasseService>();
            ArmaService armaService = serviceProvider.GetService<ArmaService>();
            //LevelService levelService = serviceProvider.GetService<LevelService>();
            MostroService mostroService = serviceProvider.GetService<MostroService>();

            var mostri = mostroService.GetAllMostri();
            #endregion

            //Chiamo il menù delle opzioniprima di iniziare l'eventuale partita
            Helper.Menu(); 

            //Catturo la scelta dell'utente da console
            bool IsCorrectUserInput = Int32.TryParse(Console.ReadLine(), out int key);
            Console.WriteLine();

            //Se l'input è idoneo, per ogni opzione scelta
            //vengono eseguite le istruzioni corrispondenti
            if (IsCorrectUserInput)
            {
                switch (key)
                {
                    #region CASO 1 NUOVO EROE
                    case 1: //Giocatore può creare un nuovo eroe con il quale giocare

                        #region CREAZIONE EROE

                        //Richiesta Parametri in input da console
                        Console.WriteLine("Inserisci il nome del tuo Eroe: ");
                        string Nome = Console.ReadLine();

                        Console.WriteLine("CLASSI: ");
                        var classi = classeService.GetAllClassi();
                        foreach (var cl in classi)
                        {
                            if (cl.Hero == true)
                            {
                                Console.WriteLine($"{cl.Nome}");
                            }
                        }
                        Console.WriteLine("Scegli la classe del tuo Eroe: ");
                        string Classe = Console.ReadLine();

                        Console.WriteLine("ARMI: ");
                        var armi = armaService.GetAllArmi();
                        foreach (var arma in armi)
                        {
                            if (arma.Classe == Classe)
                            {
                                Console.WriteLine($"{arma.Nome}");
                            }
                        }
                        Console.WriteLine("Scegli l'arma del tuo Eroe: ");
                        string Arma = Console.ReadLine();

                        Hero hero = new Hero(Nome, Classe, Arma, giocatore);

                        heroService.CreateHero(hero);

                        //è stato creato un nuovo oggetto eroe, sia nel programma
                        //nel database e può iniziare a giocare

                        Console.WriteLine("Premi il tasto invio per iniziare a giocare!");
                        Console.ReadLine();
                        #endregion

                        //GAME

                        //Chiamo il metodo che gioca la battaglia eroe selezionato contro mostri
                        //formata eventualmente da diversi scontri
                        Turno.Game(hero, mostri, giocatore);

                        break;
                    #endregion

                    #region CASO 2 ELIMINA EROE
                    case 2: //Giocatore sceglie di eliminare un suo eroe

                        Console.WriteLine("I Tuoi Eroi: ");
                        var heros = heroService.GetAllHeros();

                        //Seleziono solo gli eroi del giocatore corrente
                        foreach (var h in heros)
                        {
                            if (h.Giocatore.Nome == giocatore.Nome)
                            {
                                Console.WriteLine($"{h.Nome}");
                            }
                        }
                        Console.WriteLine("Seleziona l'Eroe da eliminare: ");
                        string heroDel = Console.ReadLine();

                        Hero heroToDelete = heroService.GetHero(heroDel);

                        bool deleted = heroService.DeleteHero(heroToDelete);
                        if (deleted == true)
                        {
                            Console.WriteLine("L'operazione di cancellazione è avvenuta correttamente");
                        }
                        else
                        {
                            Console.WriteLine("L'operazione di cancellazione NON è avvenuta correttamente");
                        }
                        Console.ReadLine();
                        break;
                    #endregion

                    #region CASO 3 CONTINUA PARTITA EROE
                    case 3: //il giocatore sceglie di continuare la partita con un suo eroe già esistente

                        Console.WriteLine("Ecco i Tuoi Eroi: ");
                        var eroi = heroService.GetAllHeros();

                        //Seleziono solo gli eroi associati al giocatore corrente
                        foreach (var h in eroi)
                        {
                            if (h.Giocatore.Nome == giocatore.Nome)
                            {
                                Console.WriteLine($"{h.Nome}");
                            }
                        }
                        Console.WriteLine("Seleziona l'Eroe col quale giocare la partita: ");
                        string nomeHero = Console.ReadLine();

                        hero = heroService.GetHero(nomeHero);

                        //GAME

                        //Chiamo il metodo che gioca la battaglia eroe selezionato contro mostri
                        //formata eventualmente da diversi scontri
                        Turno.Game(hero, mostri, giocatore);

                        break;

                    #endregion

                    case 'q': //Il giocatore sceglie di uscire dal gioco

                        Console.WriteLine("Arrivederci!!!");
                        Console.ReadLine();
                        break;

                    default: //caso in cui il giocatore ha inserito un input errato

                        Console.WriteLine("Riprovare.");
                        Console.ReadLine();
                        break;
                }
            }
            Console.Clear();
        }
    }
}