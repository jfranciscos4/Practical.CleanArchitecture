﻿using ClassifiedAds.Application;
using ClassifiedAds.Services.Product.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ClassifiedAds.Services.Product.Queries;

public class GetProductsQuery : IQuery<List<Entities.Product>>
{
}

public class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<Entities.Product>>
{
    private readonly IProductRepository _productRepository;

    public GetProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public Task<List<Entities.Product>> HandleAsync(GetProductsQuery query, CancellationToken cancellationToken = default)
    {
        return _productRepository.ToListAsync(_productRepository.GetQueryableSet());
    }
}
