// using TechMed.Application.Services.Interfaces;
// using TechMed.Application.InputModels;
// using TechMed.Application.ViewModels;
// using TechMed.Infrastructure.Persistence.Interfaces;
// using TechMed.Core.Entities;

// namespace TechMed.Application.Services;
// public class AtendimentoService : IAtendimentoService
// {
//   private readonly ITechMedContext _context;
//   public AtendimentoService(ITechMedContext context)
//   {
//     _context = context;
//   }

//   public int Create(NewAtendimentoInputModel atendimento)
//   {
//     return _context.AtendimentosCollection.Create(new Atendimento
//     {
//       Paciente = atendimento.Paciente

//     });

//   }

//   public void Delete(int id)
//   {
//     _context.MedicosCollection.Delete(id);
//   }

//   public List<AtendimentoViewModel> GetAll()
//   {
//     var atendimentos = _context.AtendimentosCollection.GetAll().Select(m => new AtendimentoViewModel
//     {
//       AtendimentoId = m.AtendimentoId,
//       Atendimento = m.Nome
//     }).ToList();

//     return atendimentos;

//   }

//   public MedicoViewModel? GetByCrm(string crm)
//   {
//     throw new NotImplementedException();
//   }

//   public AtendimentoViewModel? GetById(int id)
//   {
//     var atendimento = _context.AtendimentosCollection.GetById(id);

//     if (atendimento is null)
//       return null;

//     var AtendimentoViewModel = new AtendimentoViewModel
//     {
//       AtendimentoId = atendimento.AtendimentoId,
//       Nome = medico.Nome
//     };
//     return AtendimentoViewModel;
//   }

//   public void Update(int id, NewAtendimentoInputModel atendimento)
//   {
//     _context.AtendimentosCollection.Update(id, new Atendimento
//     {
//       Nome = atendimento.Nome
//     });
//   }
// }
