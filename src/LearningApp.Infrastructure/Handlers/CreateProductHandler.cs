using AutoMapper;
using MediatR;
using LearningApp.Core.Commands;
using LearningApp.Core.DTOs;
using LearningApp.Core.Entities;
using LearningApp.Core.Interfaces;
using System.Threading.Tasks;
using System.Threading;

namespace LearningApp.Infrastructure.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Product>(request.Product);
            product.UserId = request.UserId;

            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveChangesAsync();

            // Load related data for mapping
            var createdProduct = await _unitOfWork.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
            
            return _mapper.Map<ProductDto>(createdProduct);
        }
    }
}