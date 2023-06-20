using MatakuliahApi.Models;
using MatakuliahApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace MatakuliahApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PresensiMengajarController : ControllerBase
{
    private readonly PresensiMengajarService _PresensiMengajarService;

    public PresensiMengajarController(PresensiMengajarService PresensiMengajarService) =>
        _PresensiMengajarService = PresensiMengajarService;

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
    public async Task<List<PresensiMengajar>> Get() =>
        await _PresensiMengajarService.GetAsync();

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
    public async Task<ActionResult<PresensiMengajar>> Get(string id)
    {
        var PresensiMengajar = await _PresensiMengajarService.GetAsync(id);

        if (PresensiMengajar is null)
        {
            return NotFound();
        }

        return PresensiMengajar;
    }

    /// <summary>
    /// Creates a Matakuliah Item.
    /// </summary>
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
    public async Task<IActionResult> Post(PresensiMengajar newPresensiMengajar)
    {
        await _PresensiMengajarService.CreateAsync(newPresensiMengajar);

        return CreatedAtAction(nameof(Get), new { id = newPresensiMengajar.Id }, newPresensiMengajar);
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
    public async Task<IActionResult> Update(string id, PresensiMengajar updatedPresensiMengajar)
    {
        var PresensiMengajar = await _PresensiMengajarService.GetAsync(id);

        if (PresensiMengajar is null)
        {
            return NotFound();
        }

        updatedPresensiMengajar.Id = PresensiMengajar.Id;

        await _PresensiMengajarService.UpdateAsync(id, updatedPresensiMengajar);

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
        var kelas = await _PresensiMengajarService.GetAsync(id);

        if (kelas is null)
        {
            return NotFound();
        }

        await _PresensiMengajarService.RemoveAsync(id);

        return NoContent();
    }
}