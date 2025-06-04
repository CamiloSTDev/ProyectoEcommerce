namespace Application.Exceptions;

public class ProductInventoryException : Exception
{
    public ProductInventoryException(string message) : base(message) { }
    public ProductInventoryException(string message, Exception innerException) : base(message, innerException) { }
}

public class ProductNotFoundException : ProductInventoryException
{
    public ProductNotFoundException(Guid id)
        : base($"Producto con ID '{id}' no fue encontrado.") { }
}

public class ProductAlreadyExistsException : ProductInventoryException
{
    public ProductAlreadyExistsException(string name)
        : base($"El producto con nombre '{name}' ya existe.") { }
}

public class InvalidProductDataException : ProductInventoryException
{
    public InvalidProductDataException(string reason)
        : base($"Datos inválidos para el producto: {reason}") { }
}

