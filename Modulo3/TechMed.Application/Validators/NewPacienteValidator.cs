using System.Data;
using FluentValidation;
using TechMed.Application.InputModels;

namespace TechMed.Application.Validators;

public class NewPacienteValidator : AbstractValidator<NewPacienteInputModel>
{
    public NewPacienteValidator()
    {
        RuleFor(x => x.Nome)
          .NotEmpty().WithMessage("O nome do paciente é obrigatório").MinimumLength(3).WithMessage("O nome do paciente deve ter no mínimo 3 caracteres");
    }
}
