using MediatR;
using LearningApp.Core.DTOs;

namespace LearningApp.Core.Commands
{
    public class UpdateProductCommand : IRequest<ProductDto>
    {
        public int Id { get; set; }
        public CreateProductDto Product { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
    }
}