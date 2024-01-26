using TechMed.Core.Entities;
namespace TechMed.Application.ViewModels
{
    public class AtendimentoViewModel
    {
        public int AtendimentoId { get; set; }
        public int MedicoId { get; set; }
        public required Medico Medico { get; set; }
        public int PacienteId { get; set; }
        public required Paciente Paciente { get; set; }

    }
}
