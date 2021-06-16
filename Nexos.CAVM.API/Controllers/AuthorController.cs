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
    [Route("api/authors")]
    public class AuthorController : ControllerBase
    {
        private readonly ILogger<AuthorController> _logger;
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public AuthorController(ILogger<AuthorController> logger
                                , IRepositoryWrapper repository
                                , IMapper mapper
                                )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        [HttpGet]
        [AuthorsResultFilterAttribute]
        public IActionResult GetAll()
        {
            try
            {
                var authors = _repository.Authors.GetAllAuthorsAsync().Result;
                _logger.LogInformation($"Returned all authors from database.");
                return Ok(authors);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAll authors action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet]
        [Route("{id}", Name = "GetAuthor")]
        public async Task<IActionResult> GetAuthor(Guid id)
        {
            try
            {
                var author = await _repository.Authors.GetAuthorByIdAsync(id);
                if (author == null)
                {
                    return NotFound();
                }

                return Ok(_mapper.Map<AuthorDto>(author));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Get author action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAuthor(AuthorForCreationDto authorForCreation)
        {
            var newAuthor = _mapper.Map<Author>(authorForCreation);

            _repository.Authors.CreateAuthor(newAuthor);

            await _repository.SaveAsync();

            var authorToReturn = await _repository.Authors.GetAuthorByIdAsync(newAuthor.Id);

            return CreatedAtRoute(
                "GetAuthor",
                 new { id = newAuthor.Id },
                 _mapper.Map<AuthorDto>(authorToReturn));
        }
    }
}
