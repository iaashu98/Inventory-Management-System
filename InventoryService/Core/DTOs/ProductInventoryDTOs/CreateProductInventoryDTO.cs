namespace InventoryService.Core.DTOs.ProductInventoryDTOs
{
    /// <summary>
    /// Represents the Data Transfer Object (DTO) for the ProductInventory entity.
    /// This DTO is used for creating ProductInventory data without including the associated Product entity.
    /// </summary>
    public class CreateProductInventoryDTO
    {
        /// <summary>
        /// Gets or sets the ID of the associated product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the location of the inventory.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the inventory.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the inventory was last updated.
        /// </summary>
        public DateTime LastUpdated { get; set; }
    }
}