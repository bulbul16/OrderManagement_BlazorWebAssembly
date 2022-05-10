using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly OrderManagementAppDataContext _dbContext;

        public SuppliersController(OrderManagementAppDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("states")]
        public async Task<ActionResult<List<State>>> GetStates()
        {
            var states = await _dbContext.States.ToListAsync();
            return Ok(states);
        }

        [HttpGet]
        public async Task<ActionResult<List<Supplier>>> Get()
        {
            var suppliers = await _dbContext.Suppliers.Include(item => item.State).ToListAsync();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Supplier>> Get(int id)
        {
            var supplier = await _dbContext.Suppliers
                .Include(item => item.State)
                .FirstOrDefaultAsync(item => item.Id == id);
            if (supplier == null)
                return NotFound("Sorry,No Supplier here. :/");
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> Create(Supplier supplier)
        {
            supplier.State = null;
            _dbContext.Suppliers.Add(supplier);
            await _dbContext.SaveChangesAsync();

            return Ok(await GetSuppliersFromDB());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> Update(Supplier supplier,int id)
        {
            var dbSupplier = await _dbContext.Suppliers
                              .Include(item => item.State)
                              .FirstOrDefaultAsync(item => item.Id == id);
            if(dbSupplier == null)
                return NotFound("Sorry, but no supplier for you. :/");

            dbSupplier.SupplierName = supplier.SupplierName;
            dbSupplier.AddressLine1= supplier.AddressLine1;
            dbSupplier.AddressLine2= supplier.AddressLine2;
            dbSupplier.City = supplier.City;
            dbSupplier.PostalCode = supplier.PostalCode;
            dbSupplier.StateId = supplier.StateId;

            await _dbContext.SaveChangesAsync();

            return Ok(await GetSuppliersFromDB());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplier>> Delete(int id)
        {
            var dbSupplier = await _dbContext.Suppliers
                              .Include(item => item.State)
                              .FirstOrDefaultAsync(item => item.Id == id);
            if (dbSupplier == null)
                return NotFound("Sorry, but no supplier for you. :/");

            _dbContext.Suppliers.Remove(dbSupplier);
            await _dbContext.SaveChangesAsync();

            return Ok(await GetSuppliersFromDB());
        }

        private async Task<List<Supplier>> GetSuppliersFromDB()
        {
            return await _dbContext.Suppliers.Include(item => item.State).ToListAsync();
        }
    }
}
