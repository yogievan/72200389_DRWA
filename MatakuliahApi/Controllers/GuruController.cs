using MatakuliahApi.Models;
using MatakuliahApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatakuliahApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GuruController : ControllerBase
{
    private readonly GuruService _GuruService;

    public GuruController(GuruService GuruService) =>
        _GuruService = GuruService;

    /// <summary>
    /// Get all of Matakuliah Items.
    /// </summary>
    /// <returns>All Matakuliah Items</returns>
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
    public async Task<List<Guru>> Get() =>
        await _GuruService.GetAsync();
    
    /// <summary>
    /// Get a specific MatakuliahItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Specific Items of Matakuliah</returns>
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
    public async Task<ActionResult<Guru>> Get(string id)
    {
        var guru = await _GuruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        return guru;
    }

    /// <summary>
    /// Creates a Matakuliah Item.
    /// </summary>
    /// <param name="newGuru"></param>
    /// <returns>A newly created MatakuliahItem</returns>
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
    public async Task<IActionResult> Post(Guru newGuru)
    {
        await _GuruService.CreateAsync(newGuru);

        return CreatedAtAction(nameof(Get), new { id = newGuru.Id }, newGuru);
    }

    /// <summary>
    /// Update a specific MatakuliahItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>pdate a specific Matakuliah Item</returns>
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
    public async Task<IActionResult> Update(string id, Guru updatedGuru)
    {
        var guru = await _GuruService.GetAsync(id);

        if (guru is null)
        {
            return NotFound();
        }

        updatedGuru.Id = guru.Id;

        await _GuruService.UpdateAsync(id, updatedGuru);

        return NoContent();
    }

    /// <summary>
    /// Deletes a specific MatakuliahItem.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Deletes a specific Matakuliah Item</returns>
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
        var kelas = await _GuruService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        await _GuruService.RemoveAsync(id);

        return NoContent();
    }
}