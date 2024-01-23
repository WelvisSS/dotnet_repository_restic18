using TechMed.WebAPI.Infra.Data.Interfaces;
using TechMed.WebAPI.Model;

namespace TechMed.WebAPI.Infra.Data;
public class AtendimentoDB : IAtendimentoCollection
{
    private readonly List<Atendimento> _atendimentos = new List<Atendimento>();
    private int _id = 0;
    public void Create(Atendimento paciente)
    {
        if (_atendimentos.Count > 0)
            _id = _atendimentos.Max(m => m.PacienteId);
        paciente.PacienteId = ++_id;
        _atendimentos.Add(paciente);
    }
    public void Delete(int id)
    {
        _atendimentos.RemoveAll(m => m.PacienteId == id);
    }
    public ICollection<Atendimento> GetAll()
    {
        return _atendimentos.ToArray();
    }
    public Atendimento? GetById(int id)
    {
        return _atendimentos.FirstOrDefault(m => m.PacienteId == id);
    }
    public void Update(int id, Atendimento atendimento)
    {
        var atendimentoDB = _atendimentos.FirstOrDefault(m => m.AtendimentoId == id);
        if (atendimentoDB is not null)
        {
            atendimentoDB.Paciente = atendimento.Paciente;
            atendimentoDB.Medico = atendimento.Medico;
            atendimentoDB.Exames = atendimento.Exames;
        }
    }
}
