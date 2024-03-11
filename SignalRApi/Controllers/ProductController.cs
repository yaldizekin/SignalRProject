using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.FeatureDto;
using SignalR.DtoLayer.ProductDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
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
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _mapper.Map<List<ResultProductDto>>(_productService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var context = new SignalRContext();
            var values = context.Products.Include(x => x.Category).Select(y => new ResultProductWithCategory
            {
                CategoryName = y.Category.CategoryName,
                ProductName = y.ProductName,
                ImgUrl = y.ImgUrl,
                Price = y.Price,
                ProductDescription = y.ProductDescription,
                ProductId = y.ProductId,
                ProductStatus = y.ProductStatus,

            });
            return Ok( values.ToList());
        }
        [HttpPost]
        public IActionResult CreateProduct(CreateProductDto createProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductName = createProductDto.ProductName,
                ProductDescription = createProductDto.ProductDescription,
                ImgUrl = createProductDto.ImgUrl,
                ProductStatus = true,
                Price=createProductDto.Price,


            });
            return Ok("Başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value = _productService.TGetById(id);
            _productService.TDelete(value);
            return Ok("Başarıyla silindi");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value = _productService.TGetById(id);

            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateProduct(UpdateProductDto updateProductDto)
        {
            _productService.TAdd(new Product()
            {
                ProductId= updateProductDto.ProductId,
                ProductName = updateProductDto.ProductName,
                ProductDescription = updateProductDto.ProductDescription,
                ImgUrl = updateProductDto.ImgUrl,
                ProductStatus = updateProductDto.ProductStatus,
                Price = updateProductDto.Price,


            });
            return Ok("Başarıyla güncellendi.");
        }
    }
}
