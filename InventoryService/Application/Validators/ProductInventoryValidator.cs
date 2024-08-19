namespace InventoryService.Application.Validators
{
    public class ProductInventoryValidator
    {
        public ValidationResult ValidateInventory(ProductInventory inventory)
        {
            ValidationResult result = new ValidationResult { IsValid = true };

            if (inventory == null)
            {
                result.IsValid = false;
                result.Errors.Add("Product Inventory must not be null.");
                return result;
            }

            if (inventory.InventoryID < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Inventory Id must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(inventory.Location))
            {
                result.IsValid = false;
                result.Errors.Add("Location is required.");
            }

            if (inventory.ProductID <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Product Id must be greater than 0.");
            }

            if (inventory.Quantity <= 0)
            {
                result.IsValid = false;
                result.Errors.Add("Quantity must be greater than 0.");
            }

            if (inventory.LastUpdated < DateTime.Today)
            {
                result.IsValid = false;
                result.Errors.Add("Last Updated date must not be in past.");
            }

            return result;
        }
    }
}