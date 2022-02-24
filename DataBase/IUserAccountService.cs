using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public interface IUserAccountService
    {
        IEnumerable<UserAccount> GetAll();

        UserAccount GetById(int id);

        UserAccount Insert(UserAccount data);

        int Update(UserAccount data);

        int Delete(int Id);


    }
}
