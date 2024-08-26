using System.Data;
using FluentValidation;
using InventoryService.Core.DTOs.CategoryDTOs;

namespace InventoryService.Application.Validators.DTOValidators.CategoryDtoValidator
{
    public class CategoryDtoValidator : AbstractValidator<CategoryDTO>
    {
        public CategoryDtoValidator()
        {
            // Validation rules for Category Id 
            RuleFor(x => x.CategoryID)
                .GreaterThan(0).WithMessage("Category Id must be greater than 0.");

            // Validation rules for Category Name
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Category Name is required.")
                .Length(1,100).WithMessage("Category name must be between 1 and 100 characters.");

            // Validation rules for Category Description
            RuleFor(x => x.Description)
                .MaximumLength(1000).WithMessage("Description cannot exceed 1000 characters.");
        }
    }
}