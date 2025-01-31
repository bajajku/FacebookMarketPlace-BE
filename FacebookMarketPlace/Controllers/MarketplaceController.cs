using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class MarketplaceController : ControllerBase
{
    private static List<MarketplaceItem> _items;

    static MarketplaceController()
    {
        _items = new List<MarketplaceItem>
        {
            new MarketplaceItem
            {
                Id = 1,
                Title = "iPhone 13 Pro",
                Description = "Excellent condition, 256GB, Pacific Blue",
                Price = 799.99m,
                Category = "Electronics",
                Condition = "Used - Excellent",
                Location = "Seattle, WA",
                Images = new List<string> 
                { 
                    "https://example.com/iphone13-1.jpg",
                    "https://example.com/iphone13-2.jpg" 
                },
                DatePosted = DateTime.Now.AddDays(-5),
                SellerId = "user123"
            },
            new MarketplaceItem
            {
                Id = 2,
                Title = "Leather Sofa",
                Description = "Brown leather sofa, barely used, no scratches",
                Price = 599.99m,
                Category = "Furniture",
                Condition = "Like New",
                Location = "Portland, OR",
                Images = new List<string> 
                { 
                    "https://example.com/sofa-1.jpg",
                    "https://example.com/sofa-2.jpg" 
                },
                DatePosted = DateTime.Now.AddDays(-2),
                SellerId = "user456"
            },
            new MarketplaceItem
            {
                Id = 3,
                Title = "Mountain Bike",
                Description = "Trek Marlin 7, 2022 model, perfect for trails",
                Price = 450.00m,
                Category = "Sports",
                Condition = "Used - Good",
                Location = "Denver, CO",
                Images = new List<string> 
                { 
                    "https://example.com/bike-1.jpg",
                    "https://example.com/bike-2.jpg" 
                },
                DatePosted = DateTime.Now.AddDays(-1),
                SellerId = "user789"
            }
        };
    }

    [HttpGet]
    public ActionResult<IEnumerable<MarketplaceItem>> GetAll()
    {
        return Ok(_items);
    }

    [HttpGet("{id}")]
    public ActionResult<MarketplaceItem> GetById(int id)
    {
        var item = _items.FirstOrDefault(x => x.Id == id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }

    [HttpGet("category/{category}")]
    public ActionResult<IEnumerable<MarketplaceItem>> GetByCategory(string category)
    {
        var items = _items.Where(x => x.Category.ToLower() == category.ToLower());
        return Ok(items);
    }

    [HttpPost]
    public ActionResult<MarketplaceItem> Create(MarketplaceItem item)
    {
        item.Id = _items.Count + 1;
        item.DatePosted = DateTime.UtcNow;
        _items.Add(item);
        return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
    }
} 