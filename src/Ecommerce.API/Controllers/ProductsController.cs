using Application.DTOs;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Application.Commands;
using MediatR;

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
        return Ok(products);
    }

    //[Authorize(Roles = "Vendedor")]
    [HttpPost("addproduct")]
    public async Task<IActionResult> Create([FromBody] CreateProductCommand command)
    {
        var product =  await _mediator.Send(command);
        return CreatedAtAction(nameof(GetAll), new { name = product.Name }, product);
    }
}