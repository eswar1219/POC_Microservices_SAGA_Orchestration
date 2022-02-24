using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class UserRepoImplement : IUserAccountService
    {
        DataContext _dbContext;
        public UserRepoImplement(DataContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public int Delete(int Id)
        {
            var account = _dbContext.UserAccount.FirstOrDefault(x => x.Id == Id);
            if (account != null)
            {
                _dbContext.Remove(account);
                _dbContext.SaveChanges();

                return 1;
            }
            return 0;
        }

        public IEnumerable<UserAccount> GetAll()
        {
            return _dbContext.UserAccount.ToList();

        }

        public UserAccount GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserAccount Insert(UserAccount data)
        {
            _dbContext.UserAccount.Add(data);
            _dbContext.SaveChanges();
            return data;
        }

        public int Update(UserAccount data)
        {
            throw new NotImplementedException();
        }

    }
}
