using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexos.CAVM.API.Entities;
using Nexos.CAVM.API.Filters;
using Nexos.CAVM.API.Models;
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
        private readonly IMapper _mapper;

        public PublisherController(ILogger<PublisherController> logger
                                , IRepositoryWrapper repository
                                , IMapper mapper
                                )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        [PublishersResultFilter]
        public ActionResult<IEnumerable<Publisher>> GetAll()
        {
            try
            {
                var publishers =_repository.Publishers.GetAllPublishersAsync().Result;
                _logger.LogInformation($"Returned all publishers from database.");
                return Ok(publishers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll publishers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet]
        [Route("{id}", Name = "GetPublisher")]
        public async Task<IActionResult> GetPublisher(Guid id)
        {
            try
            {
                var publisher = await _repository.Publishers.GetPublisherByIdAsync(id);
                if (publisher == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<PublisherDto>(publisher));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Get publisher action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePublisher(PublisherForCreationDto publisherForCreation)
        {
            var newPublisher = _mapper.Map<Publisher>(publisherForCreation);

            _repository.Publishers.CreatePublisher(newPublisher);

            await _repository.SaveAsync();

            var publisherToReturn = await _repository.Publishers.GetPublisherByIdAsync(newPublisher.Id);

            return CreatedAtRoute(
                "GetPublisher",
                 new { id = newPublisher.Id },
                 _mapper.Map<PublisherDto>(publisherToReturn));
        }
    }
}
