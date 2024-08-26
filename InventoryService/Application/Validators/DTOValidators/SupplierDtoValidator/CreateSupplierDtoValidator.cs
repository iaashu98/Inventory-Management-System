using FluentValidation;
using InventoryService.Core.DTOs.CategoryDTOs;
using InventoryService.Core.DTOs.SupplierDTOs;

namespace InventoryService.Application.Validators.DTOValidators.SupplierDtoValidator
{
    public class CreateSupplierDtoValidator : AbstractValidator<CreateSupplierDTO>
    {
        public CreateSupplierDtoValidator()
        {
            // Validation rules for SupplierName
            RuleFor(x => x.SupplierName)
                .NotEmpty().WithMessage("Supplier name is required.")
                .Length(1, 100).WithMessage("Supplier name must be between 1 and 100 characters.");

            // Validation rules for ContactName
            RuleFor(x => x.ContactName)
                .NotEmpty().WithMessage("Contact name is required.")
                .Length(1, 100).WithMessage("Contact name must be between 1 and 100 characters.");

            // Validation rules for Address
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Address is required.")
                .Length(1, 200).WithMessage("Address must be between 1 and 200 characters.");

            // Validation rules for City
            RuleFor(x => x.City)
                .NotEmpty().WithMessage("City is required.")
                .Length(1, 100).WithMessage("City must be between 1 and 100 characters.");

            // Validation rules for PostalCode
            RuleFor(x => x.PostalCode)
                .NotEmpty().WithMessage("Postal code is required.")
                .Length(1, 20).WithMessage("Postal code must be between 1 and 20 characters.");

            // Validation rules for Country
            RuleFor(x => x.Country)
                .NotEmpty().WithMessage("Country is required.")
                .Length(1, 100).WithMessage("Country must be between 1 and 100 characters.");

            // Validation rules for Phone
            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Phone number is required.")
                .Length(1, 20).WithMessage("Phone number must be between 1 and 20 characters.");

            // Validation rules for Email
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .Length(1, 100).WithMessage("Email must be between 1 and 100 characters.");
        }
    }
}