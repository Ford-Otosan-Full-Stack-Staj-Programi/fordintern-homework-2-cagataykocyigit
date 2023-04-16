using Homework2.Data.Context;
using Homework2.Data.Model;
using Homework2.Data.Repository.Abstract;
using Homework2.Data.Repository.Concrete;
using Homework2.Data.UnitOfWork.Abstract;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Data.UnitOfWork.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext data;
        private bool disposed;

        public IGenericRepository<Account> AccountRepository { get; private set; }

        public IGenericRepository<Person> PersonRepository { get; private set; }

        public UnitOfWork(AppDbContext data)
        {
            this.data = data;

            AccountRepository = new GenericRepository<Account>(data);
            PersonRepository = new GenericRepository<Person>(data);

        }

        public void CompleteWithTransaction()
        {
            using (var dbContextTransaction = data.Database.BeginTransaction())
            {
                try
                {
                    data.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    // logging                    
                    dbContextTransaction.Rollback();
                }
            }
        }

        public void Complete()
        {
            data.SaveChanges();
        }

        protected virtual void Clean(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    data.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Clean(true);
            GC.SuppressFinalize(this);
        }
    }
}
