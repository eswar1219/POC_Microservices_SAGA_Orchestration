using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class PaymentRepoImplement : IPaymentService
    {
        public DataContext _dbContext;
        public PaymentRepoImplement(DataContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public int Delete(int Id)
        {
            var account = _dbContext.PaymentDetail.FirstOrDefault(x => x.UserId == Id);
            if (account != null)
            {
                _dbContext.Remove(account);
                _dbContext.SaveChanges();

                return 1;
            }
            return 0;
        }

        public IEnumerable<Payment> GetAll()
        {
            return _dbContext.PaymentDetail.ToList();
        }

        public Payment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Payment Insert(Payment data)
        {
            _dbContext.PaymentDetail.Add(data);
            _dbContext.SaveChanges();

            return data;
        }

        public int Update(Payment data)
        {
            throw new NotImplementedException();
        }
    }
}
