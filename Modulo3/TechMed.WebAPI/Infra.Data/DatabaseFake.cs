using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Infra.Data;
public class DatabaseFake : IDatabaseFake
{
    public IMedicoCollection Collection { get; } = new MedicosDB();
    // public IPacienteCollection PacienteCollection { get; } = new PacienteDB();
    // public IExameCollection ExameCollection { get; } = new ExameDB();
    // public IAtendimentoCollection AtendimentoCollection { get; } = new AtendimentoDB();
}
