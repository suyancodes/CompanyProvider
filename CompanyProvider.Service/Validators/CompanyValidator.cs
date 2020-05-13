using FluentValidation;
using CompanyProvider.Domain.Entities;

namespace CompanyProvider.Service.Validators
{
    public class CompanyValidator : AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.FantasyName).NotEmpty().WithMessage("Nome fantasia é obrigatório.");
            
            RuleFor(p => p.Uf).NotEmpty().WithMessage("UF é obrigatório.");

            RuleFor(p => p.Cnpj).NotEmpty().WithMessage("Cnpj é obrigatório.");
            RuleFor(p => p.Cnpj).Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$").WithMessage("CNPJ em formato inválido.");
        }
    }
}