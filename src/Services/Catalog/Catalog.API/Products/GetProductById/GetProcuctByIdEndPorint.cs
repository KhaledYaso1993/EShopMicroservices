
namespace Catalog.API.Products.GetProductById;
//public record GetProductByIdRequest();
public record GetProductByIdResponse(Product Product);

public class GetProcuctByIdEndPorint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/Products/{id}", async (Guid id, ISender sender) =>
        {

            var result = await sender.Send(new GetProductByIdQuery(id));
            var response = result.Adapt<GetProductByIdResponse>();
            return Results.Ok(response);
        }).WithName("GetProcuctById")
        .Produces<GetProductByIdResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithDescription("Get Procuct By Id")
        .WithSummary("Get Procuct By Id");
    }
}
