namespace InventoryService.Application.Validators
{
    public class CategoryValidator
    {
        public ValidationResult ValidateCategory(Category category)
        {
            ValidationResult result = new ValidationResult { IsValid = true };

            if (category == null)
            {
                result.IsValid = false;
                result.Errors.Add("Product Inventory must not be null.");
                return result;
            }

            if (category.CategoryID < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Category Id must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(category.CategoryName))
            {
                result.IsValid = false;
                result.Errors.Add("Category Name is required.");
            }

            if (string.IsNullOrWhiteSpace(category.Description))
            {
                result.IsValid = false;
                result.Errors.Add("Description is required.");
            }
            return result;
        }
    }
}