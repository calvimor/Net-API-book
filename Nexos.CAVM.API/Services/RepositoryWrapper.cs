using Nexos.CAVM.API.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private ProjectContext _repoContext;
        private IAuthorRepository _author;
        private IPublisherRepository _publisher;
        private IBookRepository _book;

        public RepositoryWrapper(ProjectContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }


        public IAuthorRepository Authors
        {
            get
            {
                if (_author == null)
                {
                    _author = new AuthorRepository(_repoContext);
                }
                return _author;
            }
        }

        public IPublisherRepository Publishers
        {
            get
            {
                if(_publisher == null)
                {
                    _publisher = new PublisherRepository(_repoContext);
                }
                return _publisher;
            }
        }

        public IBookRepository Books
        {
            get
            {
                if(_book == null)
                {
                    _book = new BookRepository(_repoContext);
                }
                return _book;
            }
        }

        public async Task SaveAsync()
        {
            await _repoContext.SaveChangesAsync();
        }
    }
}
