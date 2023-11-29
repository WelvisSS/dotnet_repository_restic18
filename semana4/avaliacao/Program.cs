class Clinica
{
    static void Main()
    {
        List<Medico> medicos = new List<Medico>();
        List<Paciente> pacientes = new List<Paciente>();

        Medico medico1 = new Medico();
        Medico medico2 = new Medico();
        Medico medico3 = new Medico();

        medico1.Nome = "Welvis";
        medico1.CPF = "04734288577";
        medico1.DataNascimento = "12/12/2020";
        medico1.CRM = "123453";

        medico2.Nome = "Teste";
        medico2.CPF = "04734288573";
        medico2.DataNascimento = "12/12/2021";
        medico2.CRM = "123452";

        medico3.Nome = "Welvis";
        medico3.CPF = "04734288570";
        medico3.DataNascimento = "12/12/2020";
        medico3.CRM = "123451";

        Paciente paciente1 = new Paciente();
        Paciente paciente2 = new Paciente();

        paciente1.Nome = "Welvis";
        paciente1.CPF = "04734288577";
        paciente1.DataNascimento = "12/12/2020";
        paciente1.Sexo = "Masculino";

        paciente2.Nome = "Teste";
        paciente2.CPF = "04734288574";
        paciente2.DataNascimento = "12/12/2021";
        paciente2.Sexo = "Feminino";

        medico1.AdicionarMedico(medico1, medicos);
        medico2.AdicionarMedico(medico2, medicos);
        medico3.AdicionarMedico(medico3, medicos);

        paciente1.AdicionarPaciente(paciente1, pacientes);
        paciente1.AdicionarPaciente(paciente2, pacientes);

        Console.WriteLine(medicos.Count);
        Console.WriteLine(pacientes.Count);


    }
}
