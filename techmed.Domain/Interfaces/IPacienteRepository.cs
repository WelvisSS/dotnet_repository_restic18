namespace Techmed.Interfaces;
using Techmed.Entities;

public interface IPacienteRepository : IBaseRepository<Paciente>
{
    Task<Paciente> GetByName(string nome, CancellationToken cancellationToken);
}
