using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Entities
{
    public class Arma
    {
        //Proprietà
        public string Nome { get; set; } //Nome univoco
        public string Classe { get; set; }
        public int PuntiDanno { get; set; }
    }
}