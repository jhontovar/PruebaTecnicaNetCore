using Xunit;
using Moq;
using core.Services;
using core.Interfaces;
using core.Entities;
using core.Interfaces.Repository;

namespace Core.Tests;

public class ProductoServiceTests
{
    /// <summary>
    /// Prueba de listar todos los productos
    /// </summary>
    [Fact]
    public void ObtenerTodos_RetornaListaDeProductosEF()
    {
        var mockRepo = new Mock<IUnitOfWork>();
        mockRepo.Setup(uow => uow.ProductoRepository.ObtenerTodos())
                .ReturnsAsync(new List<Producto> { new Producto { Id = 1, Nombre = "Carro" } });

        var service = new ProductoService(mockRepo.Object);

        // Act
        var resultado = service.ObtenerTodos().Result;

        // Assert
        Assert.Single(resultado);
        Assert.Equal("Carro", resultado.First().Nombre);
    }

    [Fact]
    public async Task Crear_AgregaProductoYGuardarCambiosEnEF()
    {
        var mockProductoRepositorio = new Mock<IProductoRepository>();
        var mockUnitOfWork = new Mock<IUnitOfWork>();

        // Simula que el UoW tiene el repositorio de producto
        mockUnitOfWork.Setup(uow => uow.ProductoRepository).Returns(mockProductoRepositorio.Object);

        var productoService = new ProductoService(mockUnitOfWork.Object);

        var producto = new Producto
        {
            Id = 1,
            Nombre = "Producto Test Carro",
            Precio = 10.99m,
            Stock = 5
        };

        // Act
        await productoService.Crear(producto);

        // Assert
        mockProductoRepositorio.Verify(repo => repo.Crear(producto), Times.Once);
        mockUnitOfWork.Verify(uow => uow.GuardarCambiosAsync(), Times.Once);
    }
}
