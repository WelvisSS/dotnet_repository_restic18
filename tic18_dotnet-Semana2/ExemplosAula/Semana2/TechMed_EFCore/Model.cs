using Microsoft.EntityFrameworkCore;

namespace TechMed_EFCore.Models;
public class TechMedContext : DbContext
{

    public DbSet<Medico> Medicos { get; set; }
    public DbSet<Paciente> Pacientes { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var connectionString = "server=localhost;user=root;password=2496;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Medico>().ToTable("Medicos").HasKey(m => m.Id);
        modelBuilder.Entity<Paciente>().ToTable("Pacientes").HasKey(p => p.Id);

        modelBuilder.Entity<Atendimento>().HasOne(a => a.Medico).WithMany(m => m.Atendimentos).HasForeignKey(a => a.MedicoId);

        modelBuilder.Entity<Atendimento>().HasOne(a => a.Paciente).WithMany(p => p.Atendimentos).HasForeignKey(a => a.PacienteId);

    }
    // codigo omitido
}

public abstract class Pessoa
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? CPF { get; set; }
}

public class Medico : Pessoa
{
    public string? CRM { get; set; }
    public string? Especialidade { get; set; }
    public decimal Salario { get; set; }

    public List<Atendimento>? Atendimentos { get; }
}

public class Paciente : Pessoa
{
    public string? Endereco { get; set; }
    public string? Telefone { get; set; }

    public List<Atendimento>? Atendimentos { get; }
}

public class Atendimento
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public required int PacienteId { get; set; }
    public required int MedicoId { get; set; }
    public required Paciente Paciente { get; set; }
    public required Medico Medico { get; set; }
}
