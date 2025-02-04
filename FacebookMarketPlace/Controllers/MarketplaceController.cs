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
                Title = "MacBookAir",
                Description = "Excellent condition, 256GB, Pacific Blue",
                Price = 1199.99m,
                Category = "Electronics",
                Condition = "Used - Excellent",
                Location = "Seattle, WA",
                Images = new List<string> 
                { 
                    "https://fastly.picsum.photos/id/0/5000/3333.jpg?hmac=_j6ghY5fCfSD6tvtcV74zXivkJSPIfR9B8w34XeQmvU" 
                },
                DatePosted = DateTime.Now.AddDays(-5),
                SellerId = "user123"
            },
            new MarketplaceItem
            {
                Id = 2,
                Title = "Camera",
                Description = "Barely used, good condition",
                Price = 599.99m,
                Category = "Electronics",
                Condition = "Like New",
                Location = "Portland, OR",
                Images = new List<string> 
                { 
                    "https://fastly.picsum.photos/id/250/4928/3264.jpg?hmac=4oIwzXlpK4KU3wySTnATICCa4H6xwbSGifrxv7GafWU"
                },
                DatePosted = DateTime.Now.AddDays(-2),
                SellerId = "user456"
            },
            new MarketplaceItem
            {
                Id = 3,
                Title = "Heals",
                Description = "High heals in good condition",
                Price = 50.00m,
                Category = "Footwear",
                Condition = "Used - Good",
                Location = "Denver, CO",
                Images = new List<string> 
                { 
                    "https://fastly.picsum.photos/id/21/3008/2008.jpg?hmac=T8DSVNvP-QldCew7WD4jj_S3mWwxZPqdF0CNPksSko4"                },
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