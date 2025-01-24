﻿namespace Catalog.API.Products.GetProductByCategory;


public record GetProductByCategoryQuery(string category) : IQuery<GetProductByCategoryResult>;
public record GetProductByCategoryResult(IEnumerable<Product> Products);
internal class GetProductByCategoryHandler(IDocumentSession session) : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
{
    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query
        , CancellationToken cancellationToken)
    {
        var product = await session.Query<Product>().Where(x => x.Category.Contains(query.category)).ToListAsync(cancellationToken);
        return new GetProductByCategoryResult(product);
    }
}
