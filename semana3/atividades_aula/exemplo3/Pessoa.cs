using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exemplo3
{
    public class Pessoa
    {

        public Pessoa(string nome, float altura)
        {
            this.nome = nome;
            this.altura = altura;
        }

        private static string nome { get; private set; }
        private static float altura { get; private set; }
    }
}