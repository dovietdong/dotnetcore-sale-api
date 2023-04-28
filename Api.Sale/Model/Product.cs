namespace Api.Sale.Model
{
    public class Products
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public long ProductPrice { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
