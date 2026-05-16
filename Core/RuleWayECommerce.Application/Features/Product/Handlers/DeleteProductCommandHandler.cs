using MediatR;
using RuleWayECommerce.Application.Features.Product.Commands;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Product.Handlers
{
    public class DeleteProductCommandHandler (IProductRepository _productRepository)
        : IRequestHandler<DeleteProductCommand, bool>
    {
        public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product is null)
                return false;

            await _productRepository.DeleteAsync(product);

            return true;
        }
    }
}
