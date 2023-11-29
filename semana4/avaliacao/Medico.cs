using System;

public class Medico
{
    public Medico() { }

    string nome;
    string dataNascimento;
    string cpf;
    string crm;


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

    public string CRM
    {
        set { crm = value; }
        get { return crm; }
    }

    public boolean validarCpf(string cpf)
    {

        return false;
    }


}