using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nexos.CAVM.API.ResourceParameters;
using Nexos.CAVM.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nexos.CAVM.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IRepositoryWrapper _repository;

        public BookController(ILogger<BookController> logger
                            , IRepositoryWrapper repository
                            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public IActionResult GetBooks([FromQuery] BookResourceParameters bookResourceParameters)
        {
            try
            {
                var books = _repository.Books.GetBooks(bookResourceParameters).Result;
                _logger.LogInformation($"Returned books from database.");
                return Ok(books);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetBooks action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        [HttpGet]
        [Route("{id}", Name = "GetBook")]
        public async Task<IActionResult> GetBook(Guid id)
        {
            try
            {
                var book = await _repository.Books.GetBookByIdAsync(id);
                if (book == null)
                {
                    return NotFound();
                }

                return Ok(book);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside Get book action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
