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
        get { return cpf; }
    }

    public string Sexo
    {
        set { sexo = value; }
        get { return sexo; }
    }


    // public List<string> Sintomas
    // {
    //     set { sintomas.Add(value.ElementtAt(0)); }
    //     get { return sintomas; }
    // }

    public void AdicionarPaciente(Paciente paciente, List<Paciente> Pacientes)
    {
        if (Pacientes.Any(p => p.CPF == paciente.CPF))
        {
            throw new Exception("CPF já cadastrado para outro paciente.");
        }
        Pacientes.Add(paciente);
    }
}