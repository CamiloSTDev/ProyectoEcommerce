using Application.DTOs;
using Application.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly GetAllProductsHandler _getHandler;
    private readonly CreateProductHandler _createHandler;

    public ProductsController(GetAllProductsHandler getHandler, CreateProductHandler createHandler)
    {
        _getHandler = getHandler;
        _createHandler = createHandler;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var products = await _getHandler.ExecuteAsync();
        return Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> Create(ProductDto dto)
    {
        var product = await _createHandler.ExecuteAsync(dto);
        return CreatedAtAction(nameof(GetAll), new { id = product.Id }, product);
    }
}