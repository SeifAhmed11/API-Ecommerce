using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using ecommerce.Dtos;
using ecommerce.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ecommerce.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productsRepo;
        private readonly IGenericRepository<ProductType> _productTypeRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductsController(IGenericRepository<Product> productsRepo,
                                  IGenericRepository<ProductType> productTypeRepo,
                                  IGenericRepository<ProductBrand> productBrandRepo,
                                  IMapper mapper)
        {
            _productsRepo     = productsRepo;
            _productTypeRepo  = productTypeRepo;
            _productBrandRepo = productBrandRepo;
            _mapper           = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort = null)
        {
            // Log the sort value to ensure it's being passed correctly
            Console.WriteLine($"Sort value: {sort}");

            sort = string.IsNullOrEmpty(sort) ? "name" : sort.ToLower();

            // Validate sort parameter
            var validSortValues = new List<string> { "priceasc", "pricedesc", "name" };
            if (!validSortValues.Contains(sort))
            {
                return BadRequest(new { errors = new[] { "Invalid sort value." }, statusCode = 400, message = "Invalid sort parameter." });
            }

            // Use the specification with the sort parameter
            var spec = new ProductsWithTypesAndBrandsSpecification(sort);
            var products = await _productsRepo.ListAsync(spec);

            return Ok(_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products));
        }




        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await _productsRepo.GetEntityWithSpec(spec);
            
            if(product == null) return NotFound(new ApiResponse(404));

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepo.ListAllAsync());
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepo.ListAllAsync());
        }
    }
}