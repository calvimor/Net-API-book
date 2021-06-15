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
    }
}