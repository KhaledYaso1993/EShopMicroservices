namespace Catalog.API.Products.CreateProduct; 
public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
public record CreateProductResult(Guid Id);

internal class CreateProductCommandHandler (IDocumentSession session)
    : ICommandHandler<CreateProductCommand, CreateProductResult>
{
    public async  Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {

        // task 1: Create Prod Entity from  Command obj
        var product = new Product()
        {
            Name = command.Name,
            Category = command.Category,
            Description = command.Description,
            ImageFile = command.ImageFile,
            Price = command.Price,
        };
        //TDOO
        // Save to the Database 
        session.Store(product);
        await session.SaveChangesAsync(cancellationToken);
        //Task 2:  Retuern CreateProductResult result
        return new CreateProductResult(product.Id);
    } 
}
