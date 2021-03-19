using MonstersVSHeroGame.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MonstersVSHeroGame.ADORepository.Extensions
{
    public static class SqlDataReaderExtensions
    {
        public static Hero ToHero(this SqlDataReader reader)
        {
            string Nome = reader["Nome"].ToString();
            string Classe = reader["Classe"].ToString();
            string Arma = reader["Arma"].ToString();
            int PuntiVita = (int)reader["PuntiVita"];
            int PuntiAccumulati = (int)reader["PuntiVita"];
            int Livello = (int)reader["Livello"];
            Giocatore giocatore = new Giocatore(reader["Giocatore"].ToString());

            return new Hero(Nome, Classe, Arma, PuntiVita, Livello, PuntiAccumulati, giocatore)
            {
            };
        }

        public static Classe ToClasse(this SqlDataReader reader)
        {
            return new Classe()
            {
                Nome = reader["Nome"].ToString(),
                Hero = (bool)reader["Hero"],
            };
        }

        public static Mostro ToMostro(this SqlDataReader reader)
        {
            string Nome = reader["Nome"].ToString();
            string Classe = reader["Classe"].ToString();
            string Arma = reader["Arma"].ToString();
            int PuntiVita = (int)reader["PuntiVita"];
            int Livello = (int)reader["Livello"];

            return new Mostro(Nome, Classe, Arma, PuntiVita, Livello)
            {
            };
        }

        public static Arma ToArma(this SqlDataReader reader)
        {
            return new Arma()
            {
                Nome = reader["Nome"].ToString(),
                Classe = reader["Classe"].ToString(),
                PuntiDanno = (int)reader["PuntiDanno"],
            };
        }

        public static Giocatore ToGiocatore(this SqlDataReader reader)
        {
            string nome = reader["Nome"].ToString();

            return new Giocatore(nome)
            {
            };
        }
    }
}
