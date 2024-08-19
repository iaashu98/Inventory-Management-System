namespace InventoryService.Application.Validators.ProductValidator{
    public class ProductValidator{
        public ValidationResult ValidateProduct(Product product){
            
            ValidationResult result = new ValidationResult { IsValid = true };

            if (product == null)
            {
                result.IsValid = false;
                result.Errors.Add("Product must not be null.");
                return result;
            }

            if(product.ProductID < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Product Id must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                result.IsValid = false;
                result.Errors.Add("Product Name is required.");
            }

            if (product.CategoryID <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Category Id must be greater than 0.");
            }

            if (product.SupplierID <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Supplier Id must be greater than 0.");
            }

            if (product.UnitPrice <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Unit Price must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(product.QuantityPerUnit))
            {
                result.IsValid = false;
                result.Errors.Add("Quantity Per Unit is required.");
            }

            if (product.UnitsInStock < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Units In Stock must be greater than or equal to 0.");
            }

            if (product.UnitsOnOrder < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Units On Order must be greater than or equal to 0.");
            }

            if (product.ReorderLevel < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Reorder Level must be greater than or equal to 0.");
            }

            return result;
        }
    }
}