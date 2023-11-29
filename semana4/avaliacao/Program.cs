class Clinica
{
    static void Main()
    {
        List<Medico> medicos = new List<Medico>();

        Medico medico1 = new Medico();

        medico1.Nome = "Welvis";
        medico1.CPF = "04734288577";
        medico1.DataNascimento = "12/12/2020";
        medico1.CRM = "123456";

        Paciente paciente = new Paciente();

        medico1.AdicionarMedico(medico1, medicos);


    }
}
