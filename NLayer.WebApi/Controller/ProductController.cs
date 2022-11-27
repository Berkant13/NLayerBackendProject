using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;
using NLayer.Core.Model;
using NLayer.Core.Services;

namespace NLayer.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IService<Product> _service;
        public ProductController(IMapper mapper, IService<Product> service)
        {
            _mapper = mapper;
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var products = await _service.GetAllAsync();
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDtos));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<List<ProductDto>>(product);
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));
        }
        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productdto)
        {
            var product = await _service.AddAsync(_mapper.Map<Product>(productdto));
            var productsDto = _mapper.Map<List<ProductDto>>(product);
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(201, productsDto));


        }
        [HttpPut]
        public async Task<IActionResult> Update(ProductUpdateDto productdto)
        {
            await _service.AddAsync(_mapper.Map<Product>(productdto));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(204));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(product);

            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(204));


        }
    }
}
