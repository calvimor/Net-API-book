using Microsoft.EntityFrameworkCore;
using Nexos.CAVM.API.Context;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.ResourceParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public class BookRepository: RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(ProjectContext projectContext)
            : base(projectContext)
        {

        }

        public async Task<IEnumerable<Book>> GetAllBookAsync()
        {
            return await FindAll().ToListAsync();
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

            return collection.ToList();
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            return await FindByCondition(p => bookId.Equals(p.Id))
                .FirstOrDefaultAsync();
        }

        public void CreateBook(Book book)
        {
            // TODO validate author and publisher

            if(!FindByCondition(m => m.AuthorId.Equals(book.AuthorId)).Any())
            {

            }

            if (!FindByCondition(m => m.PublisherId.Equals(book.PublisherId)).Any())
            {

            }

            Create(book);
        }

        public void DeleteBook(Book book)
        {
            throw new NotImplementedException();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }
    }
}
