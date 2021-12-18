using Ateliex.Areas.Cadastro.Models;
using FluentValidation;

namespace Ateliex.Areas.Cadastro.Validators
{
    public class ModeloValidator : AbstractValidator<Modelo>
    {
        public ModeloValidator()
        {
            RuleFor(x => x.Codigo).NotEmpty();
            RuleFor(x => x.Nome).NotEmpty().WithMessage("Por favor especifique um nome.");
            RuleFor(x => x.CustoDeProducao).NotEqual(0).When(x => x.Recursos.Any());
            RuleFor(x => x.Nome).Length(5, 50);
            RuleFor(x => x.Nome).Must(BeAValidNome).WithMessage("Por favor especifique um nome válido.");
        }

        private bool BeAValidNome(string nome)
        {
            return nome == "teste";
        }
    }
}
