namespace InventoryService.Application.Validators
{
    public class SupplierValidator{
        public ValidationResult ValidateSupplier(Supplier supplier){
            ValidationResult result = new ValidationResult { IsValid = true };

            if (supplier == null)
            {
                result.IsValid = false;
                result.Errors.Add("Supplier must not be null.");
                return result;
            }

            if(supplier.SupplierID < 0)
            {
                result.IsValid = false;
                result.Errors.Add("Supplier Id must be greater than 0.");
            }

            if (string.IsNullOrWhiteSpace(supplier.SupplierName))
            {
                result.IsValid = false;
                result.Errors.Add("Supplier Name is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.ContactName))
            {
                result.IsValid = false;
                result.Errors.Add("Contact Name is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.Address))
            {
                result.IsValid = false;
                result.Errors.Add("Address is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.City))
            {
                result.IsValid = false;
                result.Errors.Add("City Name is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.PostalCode))
            {
                result.IsValid = false;
                result.Errors.Add("Postal Code is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.Country))
            {
                result.IsValid = false;
                result.Errors.Add("Country Name is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.Phone))
            {
                result.IsValid = false;
                result.Errors.Add("Phone Number is required.");
            }

            if (string.IsNullOrWhiteSpace(supplier.Email))
            {
                result.IsValid = false;
                result.Errors.Add("Email Id is required.");
            }

            return result;
        }
    }
}