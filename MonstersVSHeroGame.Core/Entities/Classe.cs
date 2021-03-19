using System;
using System.Collections.Generic;
using System.Text;

namespace MonstersVSHeroGame.Core.Entities
{
    public class Classe
    {
        //Proprietà
        public string Nome { get; set; } //Nome Univoco
        public bool Hero { get; set; }
        //se true : classe appartenente a Eroe {Mago, Guerriero}
        //se false : classe appartenente a Mostro {Cultiste, Orco, SignoreDelMale}

    }
}
