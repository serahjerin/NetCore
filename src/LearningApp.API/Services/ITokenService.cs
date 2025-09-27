using LearningApp.Core.Entities;
using System.Threading.Tasks;

namespace LearningApp.API.Services
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(User user);
    }
}