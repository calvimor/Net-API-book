using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Controllers
{
    [ApiController]
    [Route("api/publishers")]
    public class PublisherController : ControllerBase
    {
        private readonly ILogger<PublisherController> _logger;
        private readonly IRepositoryWrapper _repository;

        public PublisherController(ILogger<PublisherController> logger
                                , IRepositoryWrapper repository
                                )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));

        }

        [HttpGet]
        public ActionResult<IEnumerable<Publisher>> GetAll()
        {
            try
            {
                var publishers =_repository.Publishers.GetAllPublishersAsync();
                _logger.LogInformation($"Returned all publishers from database.");
                return Ok(publishers.Result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll publishers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        
    }
}
