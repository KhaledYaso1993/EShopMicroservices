﻿
using Catalog.API.Products.GetProduct;

namespace Catalog.API.Products.GetProductl;


public record GetProductRequest();
public record GetProductsResponse(IEnumerable<Product> Products);


public class GetProductEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/products", async (ISender sender) =>
        {

            //var query = sender.Adapt<GetProductQuery>();
            var result =await sender.Send(new GetProductsQuery());
            var response = result.Adapt<GetProductsResponse>();
            return Results.Ok(response);

        })
        .WithName("GetProducts")
        .Produces<GetProductsResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}
