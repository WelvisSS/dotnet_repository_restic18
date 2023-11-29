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
        set
        {
            string formatoData = "dd/MM/yyyy";

            try
            {
                DateTime dataConvertida = DateTime.ParseExact(value, formatoData, System.Globalization.CultureInfo.InvariantCulture);
                // Console.WriteLine("Data convertida: " + dataConvertida);
                // return dataConvertida;
                dataNascimento = value;

            }
            catch (FormatException)
            {
                Console.WriteLine("Formato de data inválido.");
            }
        }
        get { return dataNascimento; }
    }

    public string CPF
    {
        set { cpf = value; }
        get { return cpf; }
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

    // public List<Medico> MedicoPorIdade(List<Medico> Medicos, int idadeMinima, int idadeMaxima)
    // {
    //     DateTime hoje = DateTime.Today;
    //     return Medicos.Where(m => hoje.Year - m.DataNascimento.Year >= idadeMinima &&
    //                               hoje.Year - m.DataNascimento.Year <= idadeMaxima).ToList();
    // }

    public DateTime converteData(string dataString)
    {
        string formatoData = "dd/MM/yyyy";

        DateTime dataConvertida = DateTime.ParseExact(dataString, formatoData, System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine("Data convertida: " + dataConvertida);
        return dataConvertida;
    }


}