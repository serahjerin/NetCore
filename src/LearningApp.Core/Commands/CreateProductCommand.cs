using MediatR;
using LearningApp.Core.DTOs;

namespace LearningApp.Core.Commands
{
    public class CreateProductCommand : IRequest<ProductDto>
    {
        public CreateProductDto Product { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
    }
}