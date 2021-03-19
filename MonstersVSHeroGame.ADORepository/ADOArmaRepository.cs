using MonstersVSHeroGame.ADORepository.Extensions;
using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MonstersVSHeroGame.ADORepository
{
    public class ADOArmaRepository : IArmaRepository
    {
        const string connectionString = @"Persist Security Info = False; 
                                          Integrated Security = true; 
                                          Initial Catalog = Game;
                                          Server = .\SQLEXPRESS";

        public void Create(Arma obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> GetAll()
        {
            List<Arma> armi = new List<Arma>() { };

            //creare connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire connessione
                connection.Open();

                //Creare comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Arma";

                //Eseguire il comando
                SqlDataReader reader = command.ExecuteReader();

                //Leggere i dati
                while (reader.Read())
                {
                    armi.Add(reader.ToArma());
                }

                //Chiusura connessione
                reader.Close();
                connection.Close();
            }
            return armi;
        }

        public Arma GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Arma GetByName(string name)
        {
            List<Arma> armi = new List<Arma>() { };
            //Creo la connessione con l'oggetto connection
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Apro la connessione
                connection.Open();

                //Creo il command
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Arma " +
                                      "WHERE Nome = @nome";

                command.Parameters.AddWithValue("@nome", name);

                //Eseguo il command con DataReader
                SqlDataReader reader = command.ExecuteReader();

                //Lettura dei dati
                while (reader.Read())
                {
                    armi.Add(reader.ToArma());
                }
                //Chiudo la connessione
                reader.Close();
                connection.Close();
            }
            return armi[0];
        }

        public bool Update(Arma obj)
        {
            throw new NotImplementedException();
        }
    }
}
