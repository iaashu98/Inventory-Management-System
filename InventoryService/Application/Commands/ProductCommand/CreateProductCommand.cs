using MediatR;
using InventoryService.Core.DTOs.ProductDTOs;

namespace InventoryService.Application.Commands.ProductCommand
{
    public class CreateProductCommand : IRequest
    {
        public CreateProductDTO Product { get; set; }
    }
}