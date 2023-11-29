using System.Collections.Generic;
public class Paciente
{
    public Paciente() { }

    string nome;
    string dataNascimento;
    string cpf;
    string sexo;

    List<string> sintomas = new List<string>();

    public string Nome
    {
        set { nome = value; }
        get { return nome; }
    }

    public string DataNascimento
    {
        set { dataNascimento = value; }
        get { return dataNascimento; }
    }

    public string CPF
    {
        set { cpf = value; }
        get { return CPF; }
    }

    public string Sexo
    {
        set { sexo = value; }
        get { return sexo; }
    }

    // public List<string> Sintomas
    // {
    //     set { sintomas.Add(value); }
    //     get { return sintomas; }
    // }
}