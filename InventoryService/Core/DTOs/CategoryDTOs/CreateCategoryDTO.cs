namespace InventoryService.Core.DTOs.CategoryDTOs
{
    /// <summary>
    /// Represents the Data Transfer Object (DTO) for the Category entity.
    /// This DTO is used for creating Category data.
    /// </summary>
    public class CreateCategoryDTO
    {
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