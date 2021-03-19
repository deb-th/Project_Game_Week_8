using MonstersVSHeroGame.ADORepository.Extensions;
using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MonstersVSHeroGame.ADORepository
{
    public class ADOGiocatoreRepository : IGiocatoreRepository
    {
        const string connectionString = @"Persist Security Info = False; 
                                          Integrated Security = true; 
                                          Initial Catalog = Game;
                                          Server = .\SQLEXPRESS";

        public void Create(Giocatore giocatore)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire la connessione
                connection.Open();

                //Creare il command
                SqlCommand insertCommand = new SqlCommand();
                insertCommand.Connection = connection;
                insertCommand.CommandType = System.Data.CommandType.Text;
                insertCommand.CommandText = "INSERT INTO Giocatore VALUES (@Nome, @Ruolo)";

                insertCommand.Parameters.AddWithValue("@Nome", giocatore.Nome);
                insertCommand.Parameters.AddWithValue("@Ruolo", giocatore.Ruolo);

                //Esecuzione del command
                insertCommand.ExecuteNonQuery();

                //Chiudere la connessione
                connection.Close();
            }
        }

        public bool Delete(Giocatore obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giocatore> GetAll()
        {
            List<Giocatore> giocatori = new List<Giocatore>() { };

            //creare connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire connessione
                connection.Open();

                //Creare comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore";

                //Eseguire il comando
                SqlDataReader reader = command.ExecuteReader();

                //Leggere i dati
                while (reader.Read())
                {
                    giocatori.Add(reader.ToGiocatore());
                }

                //Chiusura connessione
                reader.Close();
                connection.Close();
            }
            return giocatori;
        }

        public Giocatore GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Giocatore GetByName(string name)
        {
            List<Giocatore> giocatori = new List<Giocatore>() { };
            Giocatore giocatore = null;

            //Creo la connessione con l'oggetto connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Apro la connessione
                connection.Open();

                //Creo il command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Giocatore " +
                                      "WHERE Nome = @nome";

                command.Parameters.AddWithValue("@nome", name);

                //Eseguo il command con DataReader
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dei dati
                while (reader.Read())
                {
                    giocatori.Add(reader.ToGiocatore());
                }
                if(giocatori.Count() == 0)
                {
                    giocatore = null;
                }
                else
                {
                    giocatore = giocatori[0];
                }

                //Chiudo la connessione
                reader.Close();
                connection.Close();
            }
            return giocatore;
        }

        public bool Update(Giocatore obj)
        {
            throw new NotImplementedException();
        }
    }
}