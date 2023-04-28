using Business.Abstact;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userdal;
        public UserManager(IUserDal userDal)
        {
            _userdal=userDal;
        }
        public IResult Add(User user)
        {
            _userdal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userdal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            var result = _userdal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userdal.Get(u => u.Email == email);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<User> GetById(int id)
        {
            var result = _userdal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(result);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userdal.GetClaims(user);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IResult Update(User user)
        {
            _userdal.Update(user);
            return new SuccessResult();
        }
    }
}
