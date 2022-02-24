using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();

        T GetById(int id);

        void Insert(T data);

        int Update(T data);

        int Delete(int Id);


    }
}
