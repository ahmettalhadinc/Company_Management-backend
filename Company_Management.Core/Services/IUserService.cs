using Company_Management.Core.DTO;
using Company_Management.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company_Management.Core.Services
{
    public interface IUserService:IService<User>
    {
        User GetByEmail(string email);
        Task<Token> Login(UserLoginDto userLoginDto);
    }
}
