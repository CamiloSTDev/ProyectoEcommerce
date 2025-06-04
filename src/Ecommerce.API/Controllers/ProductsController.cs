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
public class ProductsController : ControllerBase
{
    private readonly GetAllProductsHandler _getHandler;
    private readonly IMediator _mediator;

    public ProductsController(GetAllProductsHandler getHandler, IMediator mediator)
    {
        _getHandler = getHandler;
        _mediator = mediator;
    }

    [HttpGet("getall")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _getHandler.ExecuteAsync();
        return Ok(products); // 200
    }

    //[Authorize(Roles = "Vendedor")]
    [HttpPost("addproduct")]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        try
        {
            var product = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product); // 201
        }
        catch (ProductAlreadyExistsException ex)
        {
            return Conflict(new { error = ex.Message }); // 409
        }
        catch (InvalidProductDataException ex)
        {
            return BadRequest(new { error = ex.Message }); // 400
        }
        catch (InventoryAlreadyExistsException ex)
        {
            return Conflict(new { error = ex.Message }); // 409
        }
        catch (InventoryInvalidDataException ex)
        {
            return BadRequest(new { error = ex.Message }); // 400
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = "Error interno del servidor", details = ex.Message }); // 500
        }
    }
}