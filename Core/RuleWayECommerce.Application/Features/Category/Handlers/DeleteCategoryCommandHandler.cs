using MediatR;
using RuleWayECommerce.Application.Features.Category.Commands;
using RuleWayECommerce.Application.Interfaces;

namespace RuleWayECommerce.Application.Features.Category.Handlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                return false;

            await _categoryRepository.DeleteAsync(category);

            return true;
        }
    }
}