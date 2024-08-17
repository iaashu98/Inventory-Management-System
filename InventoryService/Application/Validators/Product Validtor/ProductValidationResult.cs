namespace InventoryService.Application.Validators.ProductValidator{
    public class ProductValidationResult{
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; } = [];
    }
}