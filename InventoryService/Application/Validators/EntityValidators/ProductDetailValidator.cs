namespace InventoryService.Application.Validators
{
    public class ProductDetailValidator
    {
        public ValidationResult ValidateProductDetail(ProductDetail productDetail)
        {
            ValidationResult result = new ValidationResult { IsValid = true };

            if (productDetail == null)
            {
                result.IsValid = false;
                result.Errors.Add("Product Detail must not be null.");
                return result;
            }

            if (productDetail.ProductDetailID < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Product Detaiil Id must be greater than 0.");
            }

            if (productDetail.ProductID < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Product Id must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(productDetail.Description))
            {
                result.IsValid = false;
                result.Errors.Add("Product Name is required.");
            }

            if (string.IsNullOrWhiteSpace(productDetail.Specifications))
            {
                result.IsValid = false;
                result.Errors.Add("Specifications is required.");
            }

            if (string.IsNullOrWhiteSpace(productDetail.WarrantyPeriod))
            {
                result.IsValid = false;
                result.Errors.Add("Warranty Period is required.");
            }

            if (string.IsNullOrWhiteSpace(productDetail.Manufacturer))
            {
                result.IsValid = false;
                result.Errors.Add("Manufacturer Name is required.");
            }
            return result;
        }
    }
}