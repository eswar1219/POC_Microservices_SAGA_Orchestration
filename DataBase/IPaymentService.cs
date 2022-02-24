using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public interface IPaymentService
    {
        IEnumerable<Payment> GetAll();

        Payment GetById(int id);

        Payment Insert(Payment data);

        int Update(Payment data);

        int Delete(int Id);


    }
}
