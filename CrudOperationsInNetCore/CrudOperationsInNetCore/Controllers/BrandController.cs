using CrudOperationsInNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudOperationsInNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {

        private readonly BrandContext _dbContext;

        public BrandController(BrandContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> GetBrands()
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            return await _dbContext.Brands.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Brand>> GetBrands(int id)
        {
            if (_dbContext.Brands == null)
            {
                return NotFound();
            }
            var brand = await _dbContext.Brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }
            return brand;
        }
        [HttpPost]
        public async Task<ActionResult<Brand>> AddBrands(Brand brand)
        {
            _dbContext.Brands.Add(brand);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBrands), new { id = brand.ID }, brand);
        }
    }
}
