using MockQueryable.Moq;
using Moq;
using RealEstate.DAL.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace XUnitTestProject.Services
{
    public class RepositoryMock<T> where T : class
    {
        public Mock<IRepository<T>> Repository;

        public RepositoryMock(List<T> testDB)
        {
            Repository = new Mock<IRepository<T>>();
            Repository.Setup(r => r.GetAllAsync(It.IsAny<Expression<Func<T, bool>>>()))
               .ReturnsAsync((Expression<Func<T, bool>> predicate) => testDB.AsQueryable()
               .Where(predicate ?? (_ => true))
               .BuildMock().Object);
            Repository.Setup(r => r.GetAsync(It.IsAny<Expression<Func<T, bool>>>()))
                      .ReturnsAsync((Expression<Func<T, bool>> predicate) => testDB
                      .AsQueryable()
                      .Where(predicate ?? (_ => true))
                      .FirstOrDefault());
            Repository.Setup(r => r.AddAsync(It.IsAny<T>()))
                     .Callback((T item) =>
                     {
                         testDB.Add(item);
                     });
            Repository.Setup(r => r.Remove(It.IsAny<T>()))
                .Callback((T item) =>
                {
                    testDB.Remove(item);
                });
            Repository.Setup(r => r.UpdateAsync(It.IsAny<T>()))
               .Callback((T newItem) =>
               {
                   var oldItem = testDB.Where(i => i == newItem).FirstOrDefault();
                   oldItem = newItem;
               });
        }
    }
}
