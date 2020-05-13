using Moq;
using NUnit.Framework;
using CompanyProvider.Domain.Entities;
using CompanyProvider.Domain.Interfaces.Services;
using CompanyProvider.Infrastructure.Context;
using CompanyProvider.Infrastructure.Repositories;
using CompanyProvider.Service.Services;
using CompanyProvider.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using CompanyProvider.Domain.Filters;
using CompanyProvider.Domain.Enums;
using CompanyProvider.Domain.Dtos;

namespace CompanyProvider.Test
{
    public class CompanyProviderTest
    {
        private ICompanyProviderService _service { get; set; }
        private List<Company> _companies { get; set; }
        private List<Domain.Entities.CompanyProvider> _companyProviders { get; set; }

        [SetUp]
        public void Setup()
        {
            Mock<CompanyProviderContext> mockContext = new Mock<CompanyProviderContext>();

            _companies = new List<Company>
            {
                new Company() { Id = 1, FantasyName = "Paranaense", Cnpj = "10700505000112", Uf = UF.PR },
                new Company() { Id = 2, FantasyName = "Catarinense", Cnpj = "88358040000150", Uf = UF.SC }
            };
            var mockDbSetCompanies = _companies.AsQueryable().GetMockDbSet();
            mockContext.Setup(m => m.Companies).Returns(mockDbSetCompanies.Object);
            mockContext.Setup(m => m.Set<Company>()).Returns(mockDbSetCompanies.Object);

            _companyProviders = new List<Domain.Entities.CompanyProvider>
            {
                new Domain.Entities.CompanyProvider() { Name = "TesteA", CreatedDate = new DateTime(2020, 05, 08, 15, 30, 0) },
                new Domain.Entities.CompanyProvider() { Name = "TesteB" },
                new Domain.Entities.CompanyProvider() { Name = "TesteC", CpfCnpj = "76977745509" },
            };
            var mockDbSetCompanyProviders = _companyProviders.AsQueryable().GetMockDbSet();
            mockContext.Setup(m => m.CompanyProviders).Returns(mockDbSetCompanyProviders.Object);
            mockContext.Setup(m => m.Set<Domain.Entities.CompanyProvider>()).Returns(mockDbSetCompanyProviders.Object);

            Mock<CompanyProviderRepository<Domain.Entities.CompanyProvider>> mockRepository = new Mock<CompanyProviderRepository<Domain.Entities.CompanyProvider>>(mockContext.Object);
            Mock<CompanyRepository<Company>> mockCompanyRepository = new Mock<CompanyRepository<Company>>(mockContext.Object);
            Mock<ContactRepository<Contact>> mockContactRepository = new Mock<ContactRepository<Contact>>(mockContext.Object);
            
            _service = new CompanyProviderService(mockRepository.Object, mockCompanyRepository.Object, mockContactRepository.Object);
        }

        [Test]
        public void CreateCompanyProviderFromParanaAndOverAge()
        {
            Assert.DoesNotThrow(() => _service.Save(new CompanyProviderDto()
            {
                CompanyId = 1,
                PersonType = PersonType.Physical,
                BirthDate = new DateTime(1993, 07, 23),
                Name = "João",
                CpfCnpj = "066.127.891-22",
                Rg = "28.792.362-9"
            }));
        }

        [Test]
        public void CreateCompanyProviderFailsWhenFromParanaAndUnderAge()
        { 
            Assert.Throws<Exception>(() => _service.Save(new CompanyProviderDto()
            {
                CompanyId = 1,
                PersonType = PersonType.Physical,
                BirthDate = new DateTime(DateTime.Now.Year - 17, 01, 01),
                Name = "João",
                CpfCnpj = "066.127.891-22",
                Rg = "28.792.362-9"
            }));
        }

        [Test]
        public void CreateCompanyProviderNotFromParanaAndUnderAge()
        {
            Assert.DoesNotThrow(() => _service.Save(new CompanyProviderDto()
            {
                CompanyId = 2,
                PersonType = PersonType.Physical,
                BirthDate = new DateTime(DateTime.Now.Year - 17, 01, 01),
                Name = "João",
                CpfCnpj = "066.127.891-22",
                Rg = "28.792.362-9"
            }));
        }

        [Test]
        public void CreateCompanyProviderNotFromParanaAnOverAge()
        {
            Assert.DoesNotThrow(() => _service.Save(new CompanyProviderDto()
            {
                CompanyId = 2,
                PersonType = PersonType.Physical,
                BirthDate = new DateTime(1993, 01, 01),
                Name = "João",
                CpfCnpj = "066.127.891-22",
                Rg = "28.792.362-9"
            }));
        }

        [Test]
        public void CreateCompanyProviderFailsWhenPhysicalWithoutRg()
        {
            Assert.Throws<Exception>(() => _service.Save(new CompanyProviderDto()
            {
                CompanyId = 2,
                PersonType = PersonType.Physical,
                BirthDate = new DateTime(1993, 01, 01),
                Name = "João",
                CpfCnpj = "066.127.891-22"
            }));
        }

        [Test]
        public void CreateCompanyProviderFailsWhenPhysicalWithoutBirthDate()
        {
            Assert.Throws<Exception>(() => _service.Save(new CompanyProviderDto()
            {
                CompanyId = 2,
                PersonType = PersonType.Physical,
                Name = "João",
                CpfCnpj = "066.127.891-22",
                Rg = "28.792.362-9"
            }));
        }

        [Test]
        public void GetCompanyProviderByName()
        {
            var actual = _service.GetProvidersByFilter(new CompanyProviderFilter() { Name = "b" });

            var expected = new List<Domain.Entities.CompanyProvider>();
            expected.Add(_companyProviders[1]);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetCompanyProviderByCpfCnpj()
        {
            var actual = _service.GetProvidersByFilter(new CompanyProviderFilter() { CpfCnpj = "76977745509" });

            var expected = new List<Domain.Entities.CompanyProvider>();
            expected.Add(_companyProviders[2]);

            CollectionAssert.AreEquivalent(expected, actual);
        }

        [Test]
        public void GetCompanyProviderByCreatedDate()
        {
            var actual = _service.GetProvidersByFilter(new CompanyProviderFilter() { CreatedDate = new DateTime(2020, 05, 08) });

            var expected = new List<Domain.Entities.CompanyProvider>();
            expected.Add(_companyProviders[0]);

            CollectionAssert.AreEquivalent(expected, actual);
        }
    }
}