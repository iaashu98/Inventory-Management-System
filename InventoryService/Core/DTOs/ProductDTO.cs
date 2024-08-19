namespace InventoryService.Core.DTOs
{
    /// <summary>
    /// Represents the Data Transfer Object (DTO) for the Product entity.
    /// This DTO is used for transferring Product data without the unnecessary details like navigation properties.
    /// </summary>
    public class ProductDTO
    {
        /// <summary>
        /// Gets or sets the ID of the product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the ID of the category associated with the product.
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the ID of the supplier associated with the product.
        /// </summary>
        public int SupplierID { get; set; }

        /// <summary>
        /// Gets or sets the quantity per unit of the product.
        /// </summary>
        public string QuantityPerUnit { get; set; }

        /// <summary>
        /// Gets or sets the unit price of the product.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the units in stock for the product.
        /// </summary>
        public int UnitsInStock { get; set; }

        /// <summary>
        /// Gets or sets the units on order for the product.
        /// </summary>
        public int UnitsOnOrder { get; set; }

        /// <summary>
        /// Gets or sets the reorder level for the product.
        /// </summary>
        public int ReorderLevel { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the product is discontinued.
        /// </summary>
        public bool Discontinued { get; set; }
    }
}