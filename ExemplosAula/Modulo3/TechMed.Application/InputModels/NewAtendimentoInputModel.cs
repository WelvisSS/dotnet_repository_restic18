using TechMed.Core.Entities;
namespace TechMed.Application.InputModels
{
    public class NewAtendimentoInputModel
    {
        public int AtendimentoId { get; set; }
        public int MedicoId { get; set; }
        public required Medico Medico { get; set; }
        public int PacienteId { get; set; }
        public required Paciente Paciente { get; set; }
    }
}
