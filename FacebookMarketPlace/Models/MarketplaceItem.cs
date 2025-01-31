public class MarketplaceItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }
    public string Condition { get; set; }
    public string Location { get; set; }
    public List<string> Images { get; set; }
    public DateTime DatePosted { get; set; }
    public string SellerId { get; set; }
} 