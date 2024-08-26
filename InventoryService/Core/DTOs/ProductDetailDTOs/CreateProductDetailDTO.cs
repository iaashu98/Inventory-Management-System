namespace InventoryService.Core.DTOs.ProductDetailDTOs
{
    /// <summary>
    /// Represents the Data Transfer Object (DTO) for the ProductDetail entity.
    /// This DTO is used for creating ProductDetail data without including the associated Product entity.
    /// </summary>
    public class CreateProductDetailDTO
    {
        /// <summary>
        /// Gets or sets the ID of the associated product.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the description of the product detail.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the specifications of the product.
        /// </summary>
        public string Specifications { get; set; }

        /// <summary>
        /// Gets or sets the warranty period of the product.
        /// </summary>
        public string WarrantyPeriod { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer of the product.
        /// </summary>
        public string Manufacturer { get; set; }
    }
}