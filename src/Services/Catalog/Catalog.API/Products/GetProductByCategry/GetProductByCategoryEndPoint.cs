
namespace Catalog.API.Products.GetProductByCategory;

//public record GetProductByCategryRequest();
public record GetProductByCategoryResponse(IEnumerable<Product> Products);
public class GetProductByCategoryndPoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products/Category/{Category}", async (string Category,ISender sender) => {
            var result = await sender.Send(new GetProductByCategoryQuery(Category));
            var response = result.Adapt<GetProductByCategoryResponse>();
            return Results.Ok(response);
        }).WithName("GetProcuctByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Get Procuct By Category")
        .WithSummary("Get Procuct By Category"); ;    }
}
