using Commander.DTOs.ApplicationUserDTOs;
using Commander.Models;

namespace Commander.Data.ApplicationUserRepo
{
    public interface IApplicationUserRepository
    {
        bool SaveChanges();

        ApplicationUser Login(UserLoginDTO userLoginDTO);
    }
}