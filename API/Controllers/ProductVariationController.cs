using API.DTO.ProductVariation;
using AutoMapper;
using Core.Model;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductVariationController : ControllerBase
    {
        private readonly IProductVariationService _productVariationService;
        private readonly IMapper _mapper;
        public ProductVariationController(IProductVariationService productVariationService, IMapper mapper)
        {
            _productVariationService = productVariationService;
            _mapper = mapper;
        }


        // GET: api/<ProductVariantController>
        [HttpGet("ProductVariant/{productID}")]
        public IEnumerable<ProductVariationViewDTO> Get(long productID)
        {
            var variantList = _productVariationService.GetProductsVariationList(productID);
            return _mapper.Map<IEnumerable<ProductVariation>, IEnumerable<ProductVariationViewDTO>>(variantList);
        }

        // GET api/<ProductVariantController>/5
        [HttpGet("{ProductVariationID}")]
        public ProductVariationViewDTO Get([Required]int ProductVariationID)
        {
            var variation = _productVariationService.GetProductVariation(ProductVariationID);
            return _mapper.Map<ProductVariation, ProductVariationViewDTO>(variation);
        }

        // POST api/<ProductVariantController>
        [HttpPost]
        public void Post(ProductVariationCreateDTO productVaraiation)
        {
            _productVariationService.AddProductVariation(_mapper.Map<ProductVariationCreateDTO, ProductVariation>(productVaraiation));
        }

        // PUT api/<ProductVariantController>/5
        [HttpPut]
        public void Put(ProductVariationEditDTO productVaraiation)
        {
            _productVariationService.UpdateProductVariation(_mapper.Map<ProductVariationEditDTO, ProductVariation>(productVaraiation));
        }

        // DELETE api/<ProductVariantController>/5
        [HttpDelete("{productVariationID}")]
        public void Delete([Required]int productVariationID)
        {
            _productVariationService.DeleteProductVariation(productVariationID);
        }
    }
}
