using CompanyProvider.Domain.Dtos;
using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Enums;
using CompanyProvider.Domain.Filters;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Domain.Interfaces.Services;
using CompanyProvider.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompanyProvider.Service.Services
{
    public class CompanyProviderService : ICompanyProviderService
    {
        private ICompanyProviderRepository<Domain.Entities.CompanyProvider> _companyProviderRepository;
        private ICompanyRepository<Company> _companyRepository;
        private IContactRepository<Contact> _contactRepository;

        public CompanyProviderService(ICompanyProviderRepository<Domain.Entities.CompanyProvider> companyProviderRepository,
            ICompanyRepository<Company> companyRepository,
            IContactRepository<Contact> contactRepository)
        {
            _companyProviderRepository = companyProviderRepository;
            _companyRepository = companyRepository;
            _contactRepository = contactRepository;
        }

        public void Save(CompanyProviderDto dto)
        {
            dto.Contacts = dto.Contacts.Where(p => !string.IsNullOrEmpty(p.PhoneNumber));

            var entity = new Domain.Entities.CompanyProvider(dto);

            var validateResult = new CompanyProviderValidator().Validate(entity);
            if (!validateResult.IsValid)
            {
                throw new Exception(string.Join(" ", validateResult.Errors));
            }

            if (entity.PersonType == PersonType.Physical &&_companyRepository.GetById(entity.CompanyId).Uf == Domain.Enums.UF.PR && DateTime.Now.Year - entity.BirthDate.Value.Year < 18)
            {
                throw new Exception("Não é possível cadastrar pessoa física menor de idade como fornecedor para empresas do Paraná.");
            };

            if(entity.Id > 0)
            {
                _companyProviderRepository.Update(entity);
            }
            else
            {
                _companyProviderRepository.Insert(entity);
            }

            var contactsToDelete = dto.Contacts.Where(p => p.ToDelete).Select(p => new Contact(p.Id));
            if (contactsToDelete.Any())
            {
                _contactRepository.DeleteRange(contactsToDelete);
            }
            
            foreach (var contact in entity.Contacts)
            {
                if (contact.Id > 0)
                {
                    _contactRepository.Update(contact);
                }
                else
                {
                    _contactRepository.Insert(contact);
                }
            }
        }

        public IList<Domain.Entities.CompanyProvider> GetProvidersByFilter(CompanyProviderFilter companyProviderFilter)
        {
            return _companyProviderRepository.GetByFilter(companyProviderFilter);
        }

        public IList<Domain.Entities.CompanyProvider> GetProviders()
        {
            return _companyProviderRepository.GetByFilter(new CompanyProviderFilter());
        }

        public void Delete(long id)
        {
            var entity = _companyProviderRepository.GetById(id);

            _companyProviderRepository.Delete(entity);
        }

        public void DeletePhone(long id)
        {
            var entity = _contactRepository.GetById(id);

            _contactRepository.Delete(entity);
        }

        public Domain.Entities.CompanyProvider GetByIdWithContacts(long id)
        {
            return _companyProviderRepository.GetByIdWithContacts(id);
        }
    }
}
