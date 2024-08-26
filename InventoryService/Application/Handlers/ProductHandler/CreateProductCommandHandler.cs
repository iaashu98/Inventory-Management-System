using InventoryService.Application.Commands.ProductCommand;
using InventoryService.Core.Interfaces;
using MediatR;

namespace InventoryService.Application.Handlers.ProductHandler
{
    public class CreateProductCommandHandler(IProductService productService) : IRequestHandler<CreateProductCommand>
    {
        private readonly IProductService _productService = productService;
        public Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Implement your logic here, e.g., saving the product to the database
            // _productService.AddProduct(request.Product);

            return Task.FromResult(Unit.Value);
        }
    }
}