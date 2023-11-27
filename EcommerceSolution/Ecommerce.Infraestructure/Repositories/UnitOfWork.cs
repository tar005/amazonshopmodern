﻿using Ecommerce.Application.Persistence;
using Ecommerce.Infraestructure.Persistence;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infraestructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private Hashtable? _repositories;

        private readonly EcommerceDbContext _context;

        public UnitOfWork(Persistence.EcommerceDbContext context) { 
            _context = context;
        }

        public async Task<int> Complete()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error en transaction", ex);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if(_repositories == null )
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);    
            }

            return (IAsyncRepository<TEntity>)_repositories[type]!;
        }
    }
}
