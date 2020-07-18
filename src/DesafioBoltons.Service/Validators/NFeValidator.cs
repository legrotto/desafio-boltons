using DesafioBoltons.Domain.Entities;
using FluentValidation;

namespace DesafioBoltons.Service.Validators
{
    public class NFeValidator : AbstractValidator<NFeEntity>
    {
        public NFeValidator()
        {
            ValidaCamposObrigatorios();
        }

        private void ValidaCamposObrigatorios()
        {
            RuleFor(r => r.Access_key)
                .NotEmpty()
                .WithMessage("A CHAVE DE ACESSO é obrigatória.");

            RuleFor(r => r.Xml)
                .NotEmpty()
                .WithMessage("O XML é obrigatório.");
        }
    }
}
