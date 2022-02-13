using API_CRUD.Models.Concrete;
using System.Threading.Tasks;

namespace API_CRUD.Infrastructure.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<AppUser> Authentication(string userName, string password);
    }
}
