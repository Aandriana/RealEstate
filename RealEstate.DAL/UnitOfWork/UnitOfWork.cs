using Microsoft.EntityFrameworkCore;
using RealEstate.DAL.Repository.Implementations;
using RealEstate.DAL.Repository.Interfaces;
using System.Threading.Tasks;
using System;
using System.Linq;
using RealEstate.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace RealEstate.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IdentityDbContext<User> _context { get; }
        public UnitOfWork(IdentityDbContext<User> context)
        {
            _context = context;
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return new Repository<TEntity>(_context.Set<TEntity>(), _context);
        }

        public async Task<int> SaveChangesAsync()
        {
            var entries = _context.ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity && (
                                e.State == EntityState.Added
                                || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDateUtc = DateTime.Now;
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((BaseEntity)entityEntry.Entity).UpdatedDateUtc = DateTime.Now;
                }
            }

            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
