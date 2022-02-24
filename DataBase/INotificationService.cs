using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase
{
    public interface INotificationService
    {
        IEnumerable<Notification> GetAll();

        Notification GetById(int id);

        Notification Insert(Notification data);

        int Update(Notification data);

        int Delete(int Id);


    }
}
