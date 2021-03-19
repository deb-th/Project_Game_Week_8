using MonstersVSHeroGame.ADORepository.Extensions;
using MonstersVSHeroGame.Core.Entities;
using MonstersVSHeroGame.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MonstersVSHeroGame.ADORepository
{
    public class ADOClasseRepository : IClasseRepository
    {
        const string connectionString = @"Persist Security Info = False; 
                                          Integrated Security = true; 
                                          Initial Catalog = Game;
                                          Server = .\SQLEXPRESS";

        public void Create(Classe obj)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Classe obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Classe> GetAll()
        {
            List<Classe> classi = new List<Classe>() { };

            //creare connessione
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Aprire connessione
                connection.Open();

                //Creare comando
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Classe WHERE Hero = 1";
                //Fornisco solo le classi disponibili per l'eroe

                //Eseguire il comando
                SqlDataReader reader = command.ExecuteReader();

                //Leggere i dati
                while (reader.Read())
                {
                    classi.Add(reader.ToClasse());
                }

                //Chiusura connessione
                reader.Close();
                connection.Close();
            }
            return classi;
        }

        public Classe GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public Classe GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public bool Update(Classe obj)
        {
            throw new NotImplementedException();
        }
    }
}
