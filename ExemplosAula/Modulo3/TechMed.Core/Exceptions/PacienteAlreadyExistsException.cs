namespace TechMed.Core.Exceptions;
public class PacienteAlreadyExistsException : Exception
{
   public PacienteAlreadyExistsException() :
      base("Já existe um paciente com esse CPF.")
   {
   }
}
