using System.Data;
using System.Text.RegularExpressions;
using FluentValidation;
using TechMed.Application.InputModels;

namespace TechMed.Application.Validators;

public class NewPacienteValidator : AbstractValidator<NewPacienteInputModel>
{
    public NewPacienteValidator()
    {
        RuleFor(x => x.Nome)
          .NotEmpty().WithMessage("O nome do paciente é obrigatório").MinimumLength(3).WithMessage("O nome do paciente deve ter no mínimo 3 caracteres");

        RuleFor(x => x.Cpf)
          .NotEmpty().WithMessage("O CPF do paciente é obrigatório").
          MinimumLength(11).
          WithMessage("O CPF do paciente deve ter no mínimo 11 caracteres").
          Must(validateCpf).WithMessage("O cpf deve estar no formato 000.000.000-00");

    }

    public static bool validateCpf(string cpf)
    {
        string cpfPattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

        Regex regex = new Regex(cpfPattern);

        return regex.IsMatch(cpf);
    }

}
