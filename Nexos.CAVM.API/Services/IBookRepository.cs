using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBookAsync();

        Task<Book> GetBookByIdAsync(Guid bookId);

        Task<IEnumerable<Book>> GetBooks(BookResourceParameters booksResourceParameters);

        void CreateBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
    }
}
