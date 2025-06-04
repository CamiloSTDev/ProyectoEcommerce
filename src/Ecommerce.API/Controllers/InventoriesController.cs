using Application.DTOs;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Commands;
using MediatR;
using Application.Exceptions;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class InventoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly GetAllInventoryHandler _getInventoryHandler;

    public InventoriesController(IMediator mediator, GetAllInventoryHandler getInventoryHandler)
    {
        _mediator = mediator;
        _getInventoryHandler = getInventoryHandler;
    }

    [HttpGet("getall")]

    public async Task<IActionResult> GetAll()
    {
        try
        {
            var inventories = await _getInventoryHandler.GetAllAsync();
            if (inventories == null || inventories.Count == 0)
                return NoContent(); // 204

            return Ok(inventories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }

    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById([FromBody] GetByIdInventoryCommand id)
    {
        try
        {
            var inventory = await _mediator.Send(id);
            return Ok(inventory);
        }
        catch (InventoryNotFoundException ex)
        {
            return NotFound(new { error = ex.Message }); // 404
        }
    }

    [HttpPost("update")]
    public async Task<IActionResult> Update([FromBody] UpdateInventoryCommand inventory)
    {
        try
        {
            var updatedInventory = await _mediator.Send(inventory);
            return Ok(updatedInventory);
        }
        catch (InventoryNotFoundException ex)
        {
            return NotFound(new { error = ex.Message }); // 404
        }
        catch (InventoryInvalidUpdateException ex)
        {
            return BadRequest(new { error = ex.Message }); // 400
        }
    }
}