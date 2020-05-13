using Microsoft.EntityFrameworkCore;
using Moq;
using CompanyProvider.Domain.Entities;
using System.Linq;

namespace CompanyProvider.Test.Utils
{
    public static class MockExtension
    {
        public static Mock<DbSet<T>> GetMockDbSet<T>(this IQueryable<T> data) where T : BaseEntity
        {
            var mockSet = new Mock<DbSet<T>>();
            mockSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            return mockSet;
        }
    }
}
