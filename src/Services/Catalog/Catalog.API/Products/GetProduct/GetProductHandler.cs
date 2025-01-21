

namespace Catalog.API.Products.GetProduct;
public record GetProductsQuery() : IQuery<GetProductsResult>;
public record GetProductsResult(IEnumerable<Product> Products);
internal class GetProductQueryHandler(IDocumentSession session) : IQueryHandler<GetProductsQuery, GetProductsResult>
{
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken)
    {
        var product = await session.Query<Product>().ToListAsync(cancellationToken);
      var response= new GetProductsResult(product);
        return response;
    }
}
