public class ProductDetail{
    public int ProductDetailID { get; set; }
    public int ProductID { get; set; }
    public string Description { get; set; }
    public string Specifications { get; set; }
    public string WarrantyPeriod { get; set; }
    public string Manufacturer { get; set; }
    public Product Product { get; set; }
}