using Business.Abstact;
using Core.Entities.DTOs;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        public AuthManager(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService=userService;
            _tokenHelper=tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims=_userService.GetClaims(user);
            var result = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(result);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByEmail(userForLoginDto.Email).Data;
            var result = BusinessRules.Run(CheckIfUserExists(userToCheck),
                CheckIfPasswordIsCorrect(userToCheck, userForLoginDto));
            if (result != null)
                return new ErrorDataResult<User>(result.Message);
            return new SuccessDataResult<User>(userToCheck);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            var userToCheck=_userService.GetByEmail(userForRegisterDto.Email).Data;
            var result = BusinessRules.Run(CheckIfUserAlreadyExists(userToCheck));
            if (result!=null)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            return new SuccessDataResult<User>(userToCheck);

        }
        public IResult CheckIfUserExists(User user)
        {
            if (user==null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckIfUserAlreadyExists(User user)
        {
            if (user!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        public IResult CheckIfPasswordIsCorrect(User userToCheck,UserForLoginDto userForLoginDto)
        {
            if (userToCheck == null)
            {
                return new ErrorResult();
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
