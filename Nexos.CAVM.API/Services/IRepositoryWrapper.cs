using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Services
{
    public interface IRepositoryWrapper
    {
        IAuthorRepository Authors { get; }

        IPublisherRepository Publishers { get; }

        IBookRepository Books { get; }

        Task SaveAsync();
    }
}
