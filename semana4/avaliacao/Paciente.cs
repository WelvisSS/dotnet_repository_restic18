using System.Collections.Generic;
public class Paciente
{
    public Paciente() { }

    string nome;
    string dataNascimento;
    string cpf;
    string sexo;

    List<string> sintomas;

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


    public List<string> Sintomas
    {
        // set { sintomas = value; }
        get { return sintomas; }
    }

    public void setSintoma(string sintoma)
    {
        sintomas.Add(sintoma);
    }


    public void AdicionarPaciente(Paciente paciente, List<Paciente> Pacientes)
    {
        if (Pacientes.Any(p => p.CPF == paciente.CPF))
        {
            throw new Exception("CPF já cadastrado para outro paciente.");
        }
        Pacientes.Add(paciente);
    }


    public List<Paciente> PacientePorSexo(List<Paciente> Pacientes, string sexo)
    {
        return Pacientes.Where(p => p.Sexo.ToLower() == sexo.ToLower()).ToList();
    }

    public List<Paciente> PacientesOrdemAlfabetica(List<Paciente> Pacientes)
    {
        return Pacientes.OrderBy(p => p.Nome).ToList();
    }

    public List<Paciente> PacientesPorSintomas(List<Paciente> Pacientes, string textoSintoma)
    {
        return Pacientes.Where(p => p.Sintomas.Any(s => s.Contains(textoSintoma))).ToList();
    }

}