using Microsoft.EntityFrameworkCore;
using Nexos.CAVM.API.Context;
using Nexos.CAVM.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public class PublisherRepository: RepositoryBase<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ProjectContext projectContext)
            : base(projectContext)
        {

        }
        public async Task<IEnumerable<Publisher>> GetAllPublishersAsync()
        {
            return await FindAll().ToListAsync();
        }

        public async Task<Publisher> GetPublisherByIdAsync(Guid publisherId)
        {
            return await FindByCondition(p => publisherId.Equals(p.Id))
                .FirstOrDefaultAsync();
        }


        public void CreatePublisher(Publisher publisher)
        {
            Create(publisher);
        }

        public void DeletePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public void UpdatePublisher(Publisher publisher)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> CanAddBook(Guid publisherId)
        {
            var publisher = await GetPublisherByIdAsync(publisherId);

            return publisher.MaxNumberBook == -1 || publisher.MaxNumberBook >= publisher.Books.Count();
        }
    }
}