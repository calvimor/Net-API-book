using Nexos.CAVM.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public interface IPublisherRepository
    {
        Task<IEnumerable<Publisher>> GetAllPublishersAsync();
        Task<Publisher> GetPublisherByIdAsync(Guid publisherId);
        Task<bool> CanAddBook(Guid publisherId);
        void CreatePublisher(Publisher publisher);
        void UpdatePublisher(Publisher publisher);
        void DeletePublisher(Publisher publisher);
    }
}
