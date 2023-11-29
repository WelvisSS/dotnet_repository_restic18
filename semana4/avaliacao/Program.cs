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

        medico2.Nome = "Andre";
        medico2.CPF = "04734288573";
        medico2.DataNascimento = "12/12/1998";
        medico2.CRM = "123452";

        medico3.Nome = "Maria";
        medico3.CPF = "04734288570";
        medico3.DataNascimento = "12/12/1975";
        medico3.CRM = "123451";

        Paciente paciente1 = new Paciente();
        Paciente paciente2 = new Paciente();

        paciente1.Nome = "Welvis";
        paciente1.CPF = "04734288577";
        paciente1.DataNascimento = "12/12/2020";
        paciente1.Sexo = "masculino";
        paciente1.setSintoma("Dor de cabeça");
        paciente1.setSintoma("Febre");

        paciente2.Nome = "Maria";
        paciente2.CPF = "04734288574";
        paciente2.DataNascimento = "12/12/2021";
        paciente2.Sexo = "feminino";
        paciente2.setSintoma("Febre");
        paciente2.setSintoma("Tontura");

        medico1.AdicionarMedico(medico1, medicos);
        medico2.AdicionarMedico(medico2, medicos);
        medico3.AdicionarMedico(medico3, medicos);

        paciente1.AdicionarPaciente(paciente1, pacientes);
        paciente1.AdicionarPaciente(paciente2, pacientes);


        // Relatórios

        List<Medico> filtro = medico1.MedicoPorIdade(medicos, 18, 30);

        Console.WriteLine("Informações de médicos entre 18 e 30 anos:\n");

        foreach (Medico med in filtro)
        {
            Console.WriteLine($"Informações do médico: Nome: {med.Nome}, CRM: {med.CRM}, CRM: {med.CRM}, Data de nascimento: {med.DataNascimento}\n");
        }
        Console.WriteLine("\n");

        Console.WriteLine("Filtro por pacientes do sexo feminino:\n");
        // Filtro por pacientes do sexo feminino
        List<Paciente> filtro2 = paciente1.PacientePorSexo(pacientes, "feminino");
        foreach (Paciente pac in filtro2)
        {
            Console.WriteLine($"Pacientes femininos: Nome: {pac.Nome}, CPF: {pac.CPF}, Data de nascimento: {pac.DataNascimento}, Sexo: {pac.Sexo}\n");
        }

        Console.WriteLine("Filtro de pacientes por ordem alfabetica:\n");

        // Filtor de pacientes por ordem alfabetica
        List<Paciente> filtro3 = paciente1.PacientesOrdemAlfabetica(pacientes);
        foreach (Paciente pac in filtro3)
        {
            Console.WriteLine($"Nome: {pac.Nome}, CPF: {pac.CPF}, Data de nascimento: {pac.DataNascimento}, Sexo: {pac.Sexo}\n\n");
        }

        Console.WriteLine("Filtro por sintoma (Tontura):\n");
        List<Paciente> filtro4 = paciente1.PacientesPorSintomas(pacientes, "Tontura");
        foreach (Paciente pac in filtro4)
        {
            Console.WriteLine($"Nome: {pac.Nome}, CPF: {pac.CPF}, Data de nascimento: {pac.DataNascimento}, Sexo: {pac.Sexo}, \nSintomas:");
            foreach (string sintoma in pac.Sintomas)
            {
                Console.WriteLine($"{sintoma}, ");
            }

            Console.WriteLine($"\n\n");
        }
    }
}
