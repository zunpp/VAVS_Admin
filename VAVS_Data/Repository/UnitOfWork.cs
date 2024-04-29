using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using VAVS_Data.Models;
using VAVS_Data.Repository.Base;

namespace VAVS_Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly VAVSContext _context;
        public bool disposed = false;
       

        public UnitOfWork(VAVSContext context)
        {
            _context = context;
        }
        
        #region [Dispose and Commit]
        public void Commit()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (ValidationException vexp)
            {
                foreach (var exp in vexp.Data.Values)
                {
                    string error = exp.ToString();
                    Console.WriteLine(error);
                }
            }
        }


        #endregion

        #region [Begin, Commit and Rollback Transaction]

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
