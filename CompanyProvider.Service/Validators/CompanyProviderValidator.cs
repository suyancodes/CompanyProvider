using CompanyProvider.Domain.Enums;
using FluentValidation;

namespace CompanyProvider.Service.Validators
{
    public class CompanyProviderValidator : AbstractValidator<Domain.Entities.CompanyProvider>
    {
        public CompanyProviderValidator()
        {
            RuleFor(p => p.CompanyId).GreaterThan(0).WithMessage("Empresa é obrigatória.");
            
            RuleFor(p => p.Name).NotEmpty().WithMessage("Nome é obrigatório.");

            RuleFor(p => p.CpfCnpj).NotEmpty().WithMessage("Cpf/Cnpj é obrigatório.");
            RuleFor(p => p.CpfCnpj).Matches(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$").When(p => p.PersonType == PersonType.Legal).WithMessage("CNPJ em formato inválido.");
            RuleFor(p => p.CpfCnpj).Matches(@"^\d{3}\.\d{3}\.\d{3}\-\d{2}$").When(p => p.PersonType == PersonType.Physical).WithMessage("CPF em formato inválido.");

            RuleFor(p => p.Rg).NotEmpty().When(p => p.PersonType == PersonType.Physical).WithMessage("RG é obrigatório.");
            RuleFor(p => p.Rg).Matches(@"^\d{2}\.\d{3}\.\d{3}\-\d{1}$").When(p => p.PersonType == PersonType.Physical).WithMessage("RG em formato inválido.");

            RuleFor(p => p.BirthDate).NotEmpty().When(p => p.PersonType == PersonType.Physical).WithMessage("Data de nascimento é obrigatória.");
        }
    }
}