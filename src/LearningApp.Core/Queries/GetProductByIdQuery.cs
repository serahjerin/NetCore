using MediatR;
using LearningApp.Core.DTOs;

namespace LearningApp.Core.Queries
{
    public class GetProductByIdQuery : IRequest<ProductDto?>
    {
        public int Id { get; set; }
    }
}