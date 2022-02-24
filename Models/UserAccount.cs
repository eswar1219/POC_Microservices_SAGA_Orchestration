using System;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccountNumber { get; set; }
    }
}
