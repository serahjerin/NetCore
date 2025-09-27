using MediatR;
using LearningApp.Core.DTOs;
using System.Collections.Generic;

namespace LearningApp.Core.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {
        public int? CategoryId { get; set; }
        public string? SearchTerm { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}