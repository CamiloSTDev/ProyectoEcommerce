namespace Application.Exceptions;

public class InventoryException : Exception
{
    public InventoryException(string message) : base(message) { }
    public InventoryException(string message, Exception innerException) : base(message, innerException) { }
}

public class InventoryNotFoundException : InventoryException
{
    public InventoryNotFoundException(int id)
        : base($"No se encontró inventario con ID {id}.") { }
}

public class InventoryAlreadyExistsException : InventoryException
{
    public InventoryAlreadyExistsException(Guid productId)
        : base($"Ya existe un inventario para el producto con ID {productId}.") { }
}

public class InventoryInvalidUpdateException : InventoryException
{
    public InventoryInvalidUpdateException(int id)
        : base($"No fue posible actualizar el inventario con ID {id}. Datos inválidos o inexistentes.") { }
}

public class InventoryEmptyException : InventoryException
{
    public InventoryEmptyException()
        : base("No se encontraron registros de inventario.") { }
}

public class InventoryInvalidDataException : InventoryException
{
    public InventoryInvalidDataException(string reason)
        : base($"Datos inválidos para inventario: {reason}") { }
}