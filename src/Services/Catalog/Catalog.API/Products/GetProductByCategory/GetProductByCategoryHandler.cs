﻿using Catalog.API.Products.GetProductById;

namespace Catalog.API.Products.GetProductByCategory;
public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryQueryHandler
    (IDocumentSession session, ILogger<GetProductByCategoryQueryHandler> logger)
    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
    {
        logger.LogInformation("GetProductByCategoryQueryHandler.Handel Called With {@Query}", query);

        var products = await session.Query<Product>().Where(x => x.Category.Contains(query.category)).ToListAsync();

        return new GetProductByCategoryResult(products);

    }

}
