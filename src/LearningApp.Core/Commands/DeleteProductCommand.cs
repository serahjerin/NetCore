using MediatR;

namespace LearningApp.Core.Commands
{
    public class DeleteProductCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}