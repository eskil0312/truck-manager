using TruckManager.Domain.Entities;

namespace TruckManager.Application.Common.Interfaces.Percistence
{
    public interface IUserRepository
    {
        void Add(User user);

        User? GetUserByEmail(string email);
    }
}
