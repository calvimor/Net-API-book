using Microsoft.EntityFrameworkCore;
using Nexos.CAVM.API.Context;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.Exceptions;
using Nexos.CAVM.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public class BookRepository: RepositoryBase<Book>, IBookRepository, IDisposable
    {
        public BookRepository(ProjectContext _context)
            : base(_context)
        {

        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await FindAll()
                        .Include(b => b.Author)
                        .Include(b => b.Publisher)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooks(BookResourceParameters bookResourceParameters)
        {
            if (bookResourceParameters == null)
            {
                throw new ArgumentNullException(nameof(bookResourceParameters));
            }

            if (string.IsNullOrWhiteSpace(bookResourceParameters.Title)
                 && string.IsNullOrWhiteSpace(bookResourceParameters.Author)
                 && string.IsNullOrWhiteSpace(bookResourceParameters.Publisher)
                 && bookResourceParameters.Year <= 0
                 )
            {
                return await GetAllBookAsync();
            }

            var collection = RepositoryContext.Books as IQueryable<Book>;

            if (!string.IsNullOrWhiteSpace(bookResourceParameters.Title))
            {
                var title = bookResourceParameters.Title.Trim();
                collection = collection.Where(a => a.Title == title);
            }

            if (!string.IsNullOrWhiteSpace(bookResourceParameters.Author))
            {
                var author = bookResourceParameters.Author.Trim();
                collection = collection.Where(a => a.Author.Name.Contains(author));
            }

            if (!string.IsNullOrWhiteSpace(bookResourceParameters.Publisher))
            {
                var publisher = bookResourceParameters.Publisher.Trim();
                collection = collection.Where(a => a.Publisher.PublisherName.Contains(publisher));
            }

            if (bookResourceParameters.Year > 0)
            {

                var year = bookResourceParameters.Year;
                collection = collection.Where(a => a.Year == year);
            }

            return collection
                    .Include(b => b.Author)
                    .Include(b => b.Publisher)
                    .ToList();
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            return await FindByCondition(b => bookId.Equals(b.Id))
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync();
        }

        public void CreateBook(Book book)
        {
            var collection = RepositoryContext.Publishers as IQueryable<Publisher>;
            collection = collection.Where(p => p.Id == book.PublisherId).Include(p => p.Books);

            var publisher = collection
                    .SingleOrDefaultAsync()                    
                    .Result;
            
            //if(!publisher.CanAddBook())
            //{
            //    throw new BusinessRuleException("No es posible registrar el libro, se alcanzó el máximo permitido.");
            //}

            if (!FindByCondition(m => m.AuthorId.Equals(book.AuthorId)).Any())
            {
                throw new BusinessRuleException("El autor no está registrado.");
            }

            if (!FindByCondition(m => m.PublisherId.Equals(book.PublisherId)).Any())
            {
                throw new BusinessRuleException("La editorial no está registrada.");
            }

            Create(book);
        }

        public void DeleteBook(Book book)
        {
            Delete(book);
        }

        public void UpdateBook(Book book)
        {
            Update(book);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (RepositoryContext != null)
                {
                    RepositoryContext.Dispose();
                    RepositoryContext = null;
                }
            }
        }
    }
}
