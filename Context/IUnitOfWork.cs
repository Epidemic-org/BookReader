using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_book_repository_webapi.Contracts;
using test_book_repository_webapi.Models;

namespace test_book_repository_webapi.Context
{
    public interface IUnitOfWork : IDisposable
    {
        public IGenericRepository<Book> GnrBookRepository { get; }        
    }
}
