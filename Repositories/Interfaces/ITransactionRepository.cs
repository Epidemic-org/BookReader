using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BookReader.Repositories.Interfaces
{
    public interface ITransactionRepository : IBaseRepository<Transaction>
    {

    }
}
