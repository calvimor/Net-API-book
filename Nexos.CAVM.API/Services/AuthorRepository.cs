using Microsoft.EntityFrameworkCore;
using Nexos.CAVM.API.Context;
using Nexos.CAVM.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public class AuthorRepository: RepositoryBase<Author>, IAuthorRepository
    {
        public AuthorRepository(ProjectContext projectContext)
            : base(projectContext)
        {

        }
        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await FindAll()
                    .Include(a => a.Books)
                        .ThenInclude(b => b.Publisher)
                    .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(Guid authorId)
        {
            return await FindByCondition(p => authorId.Equals(p.Id))
                .Include(a => a.Books)
                    .ThenInclude(b => b.Publisher)
                .FirstOrDefaultAsync();
        }

        public void CreateAuthor(Author author)
        {
            Create(author);
        }

        public void DeleteAuthor(Author author)
        {
            throw new NotImplementedException();
        }

        public void UpdateAuthor(Author author)
        {
            throw new NotImplementedException();
        }
    }
}
