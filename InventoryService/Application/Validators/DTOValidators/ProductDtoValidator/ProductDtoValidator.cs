using FluentValidation;
using InventoryService.Core.DTOs.ProductDTOs;

namespace InventoryService.Application.Validators.DtoValidators.ProductDtoValidator
{
    public class ProductDtoValidator : AbstractValidator<ProductDTO>
    {
        public ProductDtoValidator()
        {
            //Validation rules for Product ID
            RuleFor(x => x.ProductID)
                .GreaterThan(0).WithMessage("Product Id must be greater than 0.");

            // Validation rules for ProductName
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product name is required.")
                .Length(1, 100).WithMessage("Product name must be between 1 and 100 characters.");

            // Validation rules for CategoryID
            RuleFor(x => x.CategoryID)
                .GreaterThan(0).WithMessage("CategoryID must be greater than 0.");

            // Validation rules for SupplierID
            RuleFor(x => x.SupplierID)
                .GreaterThan(0).WithMessage("SupplierID must be greater than 0.");

            // Validation rules for QuantityPerUnit
            RuleFor(x => x.QuantityPerUnit)
                .NotEmpty().WithMessage("Quantity per unit is required.")
                .MaximumLength(50).WithMessage("Quantity per unit cannot exceed 50 characters.");

            // Validation rules for UnitPrice
            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Unit price must be greater than 0.");

            // Validation rules for UnitsInStock
            RuleFor(x => x.UnitsInStock)
                .GreaterThanOrEqualTo(0).WithMessage("Units in stock cannot be negative.");

            // Validation rules for UnitsOnOrder
            RuleFor(x => x.UnitsOnOrder)
                .GreaterThanOrEqualTo(0).WithMessage("Units on order cannot be negative.");

            // Validation rules for ReorderLevel
            RuleFor(x => x.ReorderLevel)
                .GreaterThanOrEqualTo(0).WithMessage("Reorder level cannot be negative.");

            // Validation rules for Discontinued
            RuleFor(x => x.Discontinued)
                .NotNull().WithMessage("Discontinued status is required.");
        }
    }
}