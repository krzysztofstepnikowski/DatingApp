using System.Threading.Tasks;
using DatingApp.Core.Models;
using Refit;

namespace DatingApp.Core.Api
{
    public interface IApiService
    {
        [Get("/users?page={page}")]
        Task<Root> GetUsers(int page);
    }
}
