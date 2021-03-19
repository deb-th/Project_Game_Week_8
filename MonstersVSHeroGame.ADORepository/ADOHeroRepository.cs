using MonstersVSHeroGame.ADORepository.Extensions;
using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MonstersVSHeroGame.ADORepository
{
    public class ADOHeroRepository : IHeroRepository
    {
        const string connectionString = @"Persist Security Info = False; 
                                          Integrated Security = true; 
                                          Initial Catalog = Game;
                                          Server = .\SQLEXPRESS";
        public void Create(Hero hero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire la connessione
                connection.Open();

                //Creare il command
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Hero VALUES (@Nome, @Classe, @Arma, @PuntiVita, @Livello, @PuntiAccumulati, @Giocatore)";

                insertCommand.Parameters.AddWithValue("@Nome", hero.Nome);
                insertCommand.Parameters.AddWithValue("@Classe", hero.Classe);
                insertCommand.Parameters.AddWithValue("@Arma", hero.Arma);
                insertCommand.Parameters.AddWithValue("@PuntiVita", hero.PuntiVita);
                insertCommand.Parameters.AddWithValue("@Livello", hero.Livello);
                insertCommand.Parameters.AddWithValue("@PuntiAccumulati", hero.PuntiAccumulati);
                insertCommand.Parameters.AddWithValue("@Giocatore", hero.Giocatore.Nome);

                //Esecuzione del command
                int NumOfRows = insertCommand.ExecuteNonQuery();

                Console.WriteLine("Numero di righe aggiornate: {0}", NumOfRows);

                //Chiudere la connessione
                connection.Close();
            }
        }

        public bool Delete(Hero hero)
        {
            bool isDeleted = false;
            //Creare la connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Costruire adapter
                SqlDataAdapter adapter = new SqlDataAdapter();

                //Creare i comandi da associare all'adapter
                SqlCommand SelectCommand = new SqlCommand();
                SelectCommand.Connection = connection;
                SelectCommand.CommandType = System.Data.CommandType.Text;
                SelectCommand.CommandText = "SELECT * FROM Hero";


                SqlCommand DeleteCommand = new SqlCommand();
                DeleteCommand.Connection = connection;
                DeleteCommand.CommandType = System.Data.CommandType.Text;
                DeleteCommand.CommandText = "DELETE FROM Hero WHERE Nome = @nome ";             
                DeleteCommand.Parameters.AddWithValue("@Nome", hero.Nome);

                //Istruire l'adapter associandogli i comandi
                adapter.SelectCommand = SelectCommand;
                adapter.DeleteCommand = DeleteCommand;

                //Creazione DataSet
                DataSet dataSet = new DataSet();

                try
                {
                    //Aprire la connessione
                    connection.Open();

                    adapter.Fill(dataSet, "Hero");

                    dataSet.Tables["Hero"].Rows[0].Delete();

                    adapter.Update(dataSet, "Hero");

                    isDeleted = true;
                }
                catch (Exception e)
                {
                    isDeleted = false;
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //chiusura connessione
                    connection.Close();
                }
                return isDeleted;
            }
        }

        public IEnumerable<Hero> GetAll()
        {
            List<Hero> heros = new List<Hero>() { };

            //creare connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire connessione
                connection.Open();

                //Creare comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Hero";

                //Eseguire il comando
                SqlDataReader reader = command.ExecuteReader();

                //Leggere i dati
                while (reader.Read())
                {
                    heros.Add(reader.ToHero());
                }

                //Chiusura connessione
                reader.Close();
                connection.Close();
            }
            return heros;
        }

        public Hero GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Hero GetByName(string name)
        {
            List<Hero> heros = new List<Hero>() { };
            //Creo la connessione con l'oggetto connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Apro la connessione
                connection.Open();

                //Creo il command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Hero " +
                                      "WHERE Nome = @nome";

                command.Parameters.AddWithValue("@nome", name);

                //Eseguo il command con DataReader
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dei dati
                while (reader.Read())
                {
                    heros.Add(reader.ToHero());
                }
                //Chiudo la connessione
                reader.Close();
                connection.Close();
            }
            return heros[0];
        }

        public bool Update(Hero hero)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    //Aprire la connessione
                    connection.Open();

                    //Creare il command
                    SqlCommand updateCommand = new SqlCommand();
                    updateCommand.Connection = connection;
                    updateCommand.CommandType = System.Data.CommandType.Text;
                    updateCommand.CommandText = "UPDATE Hero " +
                                                "SET Classe = @Classe, Arma = @Arma, Giocatore = @Giocatore, " +
                                                "PuntiVita = @PuntiVita, PuntiAccumulati = @PuntiAccumulati, " +
                                                "Livello = @Livello " +
                                                "WHERE Nome = @Nome) ";


                    updateCommand.Parameters.AddWithValue("@Nome", hero.Nome);
                    updateCommand.Parameters.AddWithValue("@Classe", hero.Classe); 
                    updateCommand.Parameters.AddWithValue("@Arma", hero.Arma);
                    updateCommand.Parameters.AddWithValue("@Giocatore", hero.Giocatore.Nome);
                    updateCommand.Parameters.AddWithValue("@PuntiVita", hero.PuntiVita);
                    updateCommand.Parameters.AddWithValue("@PuntiAccumulati", hero.PuntiAccumulati);
                    updateCommand.Parameters.AddWithValue("@Livello", hero.Livello);

                    //Esecuzione del command
                    updateCommand.ExecuteNonQuery();

                    Console.WriteLine("Aggiornamento avvenuto correttamente");

                    //Chiudere la connessione
                    connection.Close();

                    return true;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    connection.Close();
                    return false;
                }
            }
        }
    }
}
