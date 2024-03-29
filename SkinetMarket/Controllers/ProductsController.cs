﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SkinetMarket.Dtos;
using SkinetMarket.Errors;
using SkinetMarket.Helpers;

namespace SkinetMarket.Controllers;

public class ProductsController : BaseApiController
{
    private readonly IMapper _mapper;
    private readonly IGenericRepository<ProductBrand> _productBrandRepo;
    private readonly IGenericRepository<Product> _productsRepo;
    private readonly IGenericRepository<ProductType> _productTypeRepo;

    public ProductsController(IGenericRepository<Product> productsRepo,
        IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo,
        IMapper mapper)
    {
        _productsRepo = productsRepo;
        _productBrandRepo = productBrandRepo;
        _productTypeRepo = productTypeRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts(
        [FromQuery] ProductSpecParams productSpecParams)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(productSpecParams);

        var countSpec = new ProductWithFiltersForCountSpecification(productSpecParams);

        var totalItems = await _productsRepo.CountAsync(countSpec);

        var products = await _productsRepo.ListAsync(spec);

        var data = _mapper
            .Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>((IReadOnlyList<Product>)products);

        return Ok(new Pagination<ProductToReturnDto>(productSpecParams.PageIndex, productSpecParams.PageSize,
            totalItems, data));
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
    {
        var spec = new ProductsWithTypesAndBrandsSpecification(id);

        var product = await _productsRepo.GetEntityWithSpec(spec);

        if (product == null) return NotFound(new ApiResponse(404));

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