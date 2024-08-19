namespace InventoryService.Core.DTOs
{
    /// <summary>
    /// Represents the Data Transfer Object (DTO) for the Supplier entity.
    /// This DTO is used for transferring Supplier data without the associated Products collection.
    /// </summary>
    public class SupplierDTO
    {
        /// <summary>
        /// Gets or sets the ID of the supplier.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the contact name for the supplier.
        /// </summary>
        public string ContactName { get; set; }

        /// <summary>
        /// Gets or sets the address of the supplier.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the city where the supplier is located.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the postal code for the supplier's address.
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the country where the supplier is located.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the email address of the supplier.
        /// </summary>
        public string Email { get; set; }
    }
}