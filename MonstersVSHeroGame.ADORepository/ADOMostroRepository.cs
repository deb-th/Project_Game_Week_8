using MonstersVSHeroGame.ADORepository.Extensions;
using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MonstersVSHeroGame.ADORepository
{
    public class ADOMostroRepository : IMostroRepository
    {
        const string connectionString = @"Persist Security Info = False; 
                                          Integrated Security = true; 
                                          Initial Catalog = Game;
                                          Server = .\SQLEXPRESS";

        public void Create(Mostro obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Mostro obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mostro> GetAll()
        {
            List<Mostro> mostri = new List<Mostro>() { };

            //creare connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire connessione
                connection.Open();

                //Creare comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Mostro";

                //Eseguire il comando
                SqlDataReader reader = command.ExecuteReader();

                //Leggere i dati
                while (reader.Read())
                {
                    mostri.Add(reader.ToMostro());
                }

                //Chiusura connessione
                reader.Close();
                connection.Close();
            }
            return mostri;
        }

        public Mostro GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Mostro GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Mostro obj)
        {
            throw new NotImplementedException();
        }
    }
}