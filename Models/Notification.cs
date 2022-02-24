using System;

namespace Models
{
    public class Notification
    {
        public Guid Id { get; set; }
      
        public string Message { get; set; }

        public int UserId { get; set; }
    }
}
