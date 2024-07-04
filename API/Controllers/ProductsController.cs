using Infrastucture.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;
using Core.Spicifications;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _prosuctTypeRepo;

        public ProductsController(IGenericRepository<Product> productRepo,
                                  IGenericRepository<ProductBrand> brandRepo,
                                  IGenericRepository<ProductType> prosuctTypeRepo)
        {
            this._productRepo = productRepo;
            this._brandRepo = brandRepo;
            this._prosuctTypeRepo = prosuctTypeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var spec = new ProductWithTypeAndBrandSpicification();
            var products =await _productRepo.ListAsync(spec);
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            return await _productRepo.GetByIdAsync(id);
        }


        [HttpGet("barnd")]
        public async Task<ActionResult<ProductBrand>> GetProductsBarnd()
        {
            return Ok( await _brandRepo.GetAllAsync());
        }


        [HttpGet("type")]
        public async Task<ActionResult<ProductBrand>> GetProductsType()
        {
            return Ok(await _prosuctTypeRepo.GetAllAsync());
        }

    }
}
