public class ProductInventory
{
    public int InventoryID { get; set; }
    public int ProductID { get; set; }
    public string Location { get; set; }
    public int Quantity { get; set; }
    public DateTime LastUpdated { get; set; }
    public Product Product { get; set; }    
}