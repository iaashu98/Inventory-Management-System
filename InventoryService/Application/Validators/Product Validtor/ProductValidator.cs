namespace InventoryService.Application.Validators.ProductValidator{
    public class ProductValidator{
        public ProductValidationResult Validate(Product product){
            
            ProductValidationResult result = new ProductValidationResult { IsValid = true };

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
                result.Errors.Add("ProductName is required.");
            }

            if (product.CategoryID <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("CategoryID must be greater than 0.");
            }

            if (product.SupplierID <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("SupplierID must be greater than 0.");
            }

            if (product.UnitPrice <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("UnitPrice must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(product.QuantityPerUnit))
            {
                result.IsValid = false;
                result.Errors.Add("QuantityPerUnit is required.");
            }

            if (product.UnitsInStock < 0)
            {
                result.IsValid = false;
                result.Errors.Add("UnitsInStock must be greater than or equal to 0.");
            }

            if (product.UnitsOnOrder < 0)
            {
                result.IsValid = false;
                result.Errors.Add("UnitsOnOrder must be greater than or equal to 0.");
            }

            if (product.ReorderLevel < 0)
            {
                result.IsValid = false;
                result.Errors.Add("ReorderLevel must be greater than or equal to 0.");
            }

            return result;
        }
    }
}