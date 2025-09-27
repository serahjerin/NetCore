using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using LearningApp.Core.DTOs;
using LearningApp.Core.Queries;
using LearningApp.Infrastructure.Data;
using System.Threading.Tasks;
using System.Threading;

namespace LearningApp.Infrastructure.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == request.Id && !p.IsDeleted, cancellationToken);

            return product == null ? null : _mapper.Map<ProductDto>(product);
        }
    }
}