using Core.Entities.DTOs;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstact
{
    public interface IAuthService
    {
        IDataResult<AccessToken> CreateAccessToken(User user);
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        
    }
}
