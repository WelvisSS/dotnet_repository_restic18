using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace atividade_aula_4
{
    public class Aluno
    {

        public Aluno()
        {
            this._idade = 20;
            this._nome = "Teste";
        }

        int _idade { get; set; }
        string _nome { get; set; }


    }
}