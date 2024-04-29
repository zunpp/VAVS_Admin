using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace VAVS_Data.Repository.Base
{
    public interface IUnitOfWork : IDisposable
    {
       


        void Commit();
        void BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

    }
}
