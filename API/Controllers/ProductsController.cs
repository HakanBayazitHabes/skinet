using API.Dtos;
using AutoMapper;
using Core.Data;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(
        IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandsRepo,
        IGenericRepository<ProductType> productTypesRepo,
        IMapper mapper) : ControllerBase
    {

        private readonly IGenericRepository<Product> _productsRepo = productsRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandsRepo = productBrandsRepo;
        private readonly IGenericRepository<ProductType> _productTypesRepo = productTypesRepo;
        private readonly IMapper _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductWithTypesAndBrandsSpecification();

            var products = await _productsRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandsRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductTypes()
        {
            return Ok(await _productTypesRepo.ListAllAsync());
        }
    }
}