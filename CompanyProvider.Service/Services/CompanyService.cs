using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Interfaces.Repositories;
using CompanyProvider.Domain.Interfaces.Services;
using CompanyProvider.Service.Validators;
using System;
using System.Collections.Generic;

namespace CompanyProvider.Service.Services
{
    public class CompanyService : ICompanyService
    {
        private ICompanyRepository<Company> _companyRepository;

        public CompanyService(ICompanyRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public void Save(Company entity)
        {
            var validateResult = new CompanyValidator().Validate(entity);
            if (!validateResult.IsValid)
            {
                throw new Exception(string.Join(" ", validateResult.Errors));
            }
            
            if (entity.Id > 0)
            {
                _companyRepository.Update(entity);
            }
            else
            {
                _companyRepository.Insert(entity);
            }
        }

        public IList<Company> GetCompanies()
        {
            return _companyRepository.SelectAll();
        }

        public void Delete(long id)
        {
            var entity = _companyRepository.GetById(id);

            _companyRepository.Delete(entity);
        }

        public Company GetById(long id)
        {
            return _companyRepository.GetById(id);
        }
    }
}
