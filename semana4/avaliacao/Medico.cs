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

    public bool ValidarCPF(string cpf)
    {
        return cpf.Length == 11;
    }


    public void AdicionarMedico(Medico medico, List<Medico> Medicos)
    {
        if (Medicos.Any(m => m.CPF == medico.CPF || m.CRM == medico.CRM))
        {
            throw new Exception("CPF ou CRM já cadastrado para outro médico.");
        }
        Medicos.Add(medico);
    }


}