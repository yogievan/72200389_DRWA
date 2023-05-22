using BookStoreApi.Model;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly BooksService _booksService;

    public BooksController(BooksService booksService) =>
        _booksService = booksService;

    /// <summary>
    /// Get all of BookStoreItem.
    /// </summary>
    /// <returns>All BookStore Items</returns>
    /// <response code="400">If the item is null</response>
    /// <response code="401">error client-side</response>
    /// <response code="404">If the item cannot be found</response>
    /// <response code="500">If the request on the server failed unexpectedly</response>
    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<List<Book>> Get() =>
        await _booksService.GetAsync();

    /// <summary>
    /// Get a specific BookStoreItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Specific Items of BookStore</returns>
    /// <response code="400">If the item is null</response>
    /// <response code="401">error client-side</response>
    /// <response code="404">If the item cannot be found</response>
    /// <response code="500">If the request on the server failed unexpectedly</response>    
    [HttpGet("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Book>> Get(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        return book;
    }

    /// <summary>
    /// Creates a BookStoreItem.
    /// </summary>
    /// <param name="newBook"></param>
    /// <returns>A newly created BookStoreItem</returns>
    /// <remarks>
    /// Sample request:
    ///
    ///     POST /BookStoreApi
    ///     {
    ///     "Id": "Random Number",
    ///     "Name": "Book Name",
    ///     "Price": 1.0,
    ///     "Category": "Book Category",
    ///     "Author": "Name of Author"
    ///     }
    ///
    /// </remarks>
    /// <response code="201">Returns the newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="401">error client-side</response>
    /// <response code="404">If the item cannot be found</response>
    /// <response code="500">If the request on the server failed unexpectedly</response>
    [HttpPost]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Post(Book newBook)
    {
        await _booksService.CreateAsync(newBook);

        return CreatedAtAction(nameof(Get), new { id = newBook.Id }, newBook);
    }

    /// <summary>
    /// Update a specific BookStoreItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>pdate a specific BookStore Item</returns>
    /// <response code="400">If the item is null</response>
    /// <response code="401">error client-side</response>
    /// <response code="404">If the item cannot be found</response>
    /// <response code="500">If the request on the server failed unexpectedly</response>
    [HttpPut("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(string id, Book updatedBook)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        updatedBook.Id = book.Id;

        await _booksService.UpdateAsync(id, updatedBook);

        return NoContent();
    }

    /// <summary>
    /// Deletes a specific BookStoreItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Deletes a specific BookStore Item</returns>
    /// <response code="400">If the item is null</response>
    /// <response code="401">error client-side</response>
    /// <response code="404">If the item cannot be found</response>
    /// <response code="500">If the request on the server failed unexpectedly</response>
    [HttpDelete("{id:length(24)}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(string id)
    {
        var book = await _booksService.GetAsync(id);

        if (book is null)
        {
            return NotFound();
        }

        await _booksService.RemoveAsync(id);

        return NoContent();
    }
}