namespace Techmed.Interfaces;
using Techmed.Entities;

public interface IMedicoRepository : IBaseRepository<Medico>
{
    Task<Medico> GetByName(string nome, CancellationToken cancellationToken);
}

