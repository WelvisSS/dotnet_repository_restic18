using Microsoft.EntityFrameworkCore;

namespace Techmed.Model;


public class TechmedContext : DbContext
{
    public DbSet<Medico> Medicos { get; set; }

    public DbSet<Paciente> Pacientes { get; set; }

    public TechmedContext()
    {
        Database.EnsureCreated();
        Database.EnsureDeleted();
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        var stringConexao = "server=localhost;user=root;password=2496;database=techmed";
        var serverVersion = ServerVersion.AutoDetect(stringConexao);
        optionsBuilder.UseMySql(stringConexao, serverVersion);
    }

}

public abstract class Pessoa
{
    public string? nome { get; set; }
    public string? cpf { get; set; }
    public DateTime dataNascimento { get; set; }
}

public class Paciente : Pessoa
{
    public string? sexo { get; set; }
    public string? sintomas { get; set; }
}

public class Medico : Pessoa
{
    public int crm { get; set; }
}
