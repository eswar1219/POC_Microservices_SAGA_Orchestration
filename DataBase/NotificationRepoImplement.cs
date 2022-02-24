using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataBase
{
    public class NotificationRepoImplement : INotificationService
    {
        public DataContext _dbContext;
        public NotificationRepoImplement(DataContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public int Delete(int Id)
        {
            var account = _dbContext.NotificationDetail.FirstOrDefault(x => x.UserId == Id);
            if (account != null)
            {
                _dbContext.Remove(account);
                _dbContext.SaveChanges();

                return 1;
            }
            return 0;
        }

        public IEnumerable<Notification> GetAll()
        {
            return _dbContext.NotificationDetail.ToList();
        }

        public Notification GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Notification Insert(Notification data)
        {
            _dbContext.NotificationDetail.Add(data);
            _dbContext.SaveChanges();

            return data;
        }

        public int Update(Notification data)
        {
            throw new NotImplementedException();
        }

    }
}
