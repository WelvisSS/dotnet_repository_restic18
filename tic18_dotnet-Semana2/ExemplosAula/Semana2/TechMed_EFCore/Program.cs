using Microsoft.EntityFrameworkCore;
using TechMed_EFCore.Models;

var context = new TechMedContext();

Console.WriteLine($"Lendo todos os médicos no banco de dados");
foreach (var med in context.Medicos.OrderBy(m => m.Nome))
{
    Console.WriteLine($"Id: {med.Id} - Nome: {med.Nome} - CRM: {med.CRM}");
}

Console.WriteLine($"Lendo todos os pacientes no banco de dados");
foreach (var pac in context.Pacientes.OrderBy(m => m.Nome))
{
    Console.WriteLine($"Id: {pac.Id} - Nome: {pac.Nome} - CRM: {pac.CPF}");
}


Console.WriteLine($"Criar um médico no banco de dados");

var medico = new Medico
{
    Nome = "Dr. Dexter",
    CPF = "123.456.789-00",
    CRM = "123456",
    Especialidade = "Clínico Geral",
    Salario = 10000
};

context.Medicos.Add(medico);

Console.WriteLine($"Criar um paciente no banco de dados");
var paciente = new Paciente
{
    Nome = "Valber",
    CPF = "101.202.303-00",
    Endereco = "Rua A, 0",
    Telefone = "1234-5678"
};

context.Pacientes.Add(paciente);


var atendimento = new Atendimento
{
    DataHora = DateTime.Now,
    MedicoId = 4,
    Medico = medico,
    PacienteId = 1,
    Paciente = paciente,
};

context.Atendimentos.Add(atendimento);

var exame = new Exame
{
    Local = "Aqui",
    DataHora = DateTime.Now,
    Atendimento = atendimento,
};

context.Exames.Add(exame);

var medico3 = new Medico
{
    Nome = "Dr. Dexter",
    CPF = "123.456.789-00",
    CRM = "123456",
    Especialidade = "Clínico Geral",
    Salario = 10000
};

context.Medicos.Add(medico);

var paciente3 = new Paciente
{
    Nome = "Valber",
    CPF = "101.202.303-00",
    Endereco = "Rua A, 0",
    Telefone = "1234-5678"
};

context.Pacientes.Add(paciente);

var atendimento1 = new Atendimento
{
    DataHora = DateTime.Now,
    MedicoId = medico3.Id,
    Medico = medico3,
    PacienteId = paciente3.Id,
    Paciente = paciente3,
};

context.Atendimentos.Add(atendimento1);

var exame1 = new Exame
{
    Local = "Aqui",
    DataHora = DateTime.Now,
    Atendimento = atendimento1,
};

context.Exames.Add(exame1);

var exame2 = new Exame
{
    Local = "Ali",
    DataHora = DateTime.Now,
    Atendimento = atendimento1,
};

context.Exames.Add(exame2);

var atendimento2 = new Atendimento
{
    DataHora = DateTime.Now,
    MedicoId = medico.Id,
    Medico = medico,
    PacienteId = paciente.Id,
    Paciente = paciente,
};

context.Atendimentos.Add(atendimento2);

var exame3 = new Exame
{
    Local = "Acolá",
    DataHora = DateTime.Now,
    Atendimento = atendimento2,
};

context.Exames.Add(exame3);

var exame4 = new Exame
{
    Local = "Lá",
    DataHora = DateTime.Now,
    Atendimento = atendimento2,
};

context.Exames.Add(exame4);


context.SaveChanges();


Console.WriteLine($"Atualizando o nome de um paciente no banco de dados");
var doente = context.Pacientes.Where(p => p.CPF == "101.202.303-00").FirstOrDefault();
doente.Nome = "João";
context.Pacientes.Update(doente);

context.SaveChanges();

Console.WriteLine($"Removendo o primeiro médico no banco de dados");
// var primeiroMedico = context.Medicos.FirstOrDefault();
// context.Medicos.Remove(primeiroMedico);

context.SaveChanges();

Console.WriteLine($"Mostrando todos os exames que cada paciente já fez");

var patientsWithExams = context.Pacientes.Include(p => p.Atendimentos).ThenInclude(a => a.Exames);

foreach (var patient in patientsWithExams)
{
    Console.WriteLine($"Patient: {patient.Nome}");
    Console.WriteLine("Exams:");
    foreach (var atend in patient.Atendimentos)
    {
        foreach (var exam in atend.Exames)
        {
            Console.WriteLine($"- {exam.Local} - {exam.DataHora}");
        }
    }
    Console.WriteLine();
}

Console.WriteLine($"Finalizando o programa");
