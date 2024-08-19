namespace InventoryService.Core.DTOs
{
    /// <summary>
    /// Represents the Data Transfer Object (DTO) for the Category entity.
    /// This DTO is used for transferring basic Category data.
    /// </summary>
    public class CategoryDTO
    {
        /// <summary>
        /// Gets or sets the ID of the category.
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the name of the category.
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// Gets or sets the description of the category.
        /// </summary>
        public string Description { get; set; }
    }
}