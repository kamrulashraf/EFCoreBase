using API.DTO.Category;
using API.DTO.Product;
using API.DTO.ProductVariation;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductViewDTO> Get()
        {
            var products = _productService.GetAllProducts();
            return _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewDTO>>(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{productID}")]
        public ProductViewDTO Get(long productID)
        {
            return _mapper.Map<ProductViewDTO>(_productService.GetProduct(productID));
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post(ProductCreateDTO product)
        {
            _productService.AddProduct(_mapper.Map<ProductCreateDTO, Product>(product));
        }

        [HttpPost("AddPorudctVariant")]
        public void AddPorudctVariant(ProductVariationCreateDTO variant)
        {
            var coreVariant = _mapper.Map<ProductVariationCreateDTO, ProductVariation>(variant);
            _productService.AddProductVariant(coreVariant);
        }

        [HttpGet("GetProductByCategory")]
        public IEnumerable<Product> GetProductByCategory(long categoryID)
        {
            throw new NotImplementedException();
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int ProductID, Product product)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{productId}")]
        public void Delete(long productId)
        {
            var res = _productService.DeleteProduct(productId);
        }
    }
}
