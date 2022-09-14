using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Data
{
    public class AdminListContext: ListContext<AdminEntity>
    {
        public AdminListContext()
        {
            DataList = new List<AdminEntity>
            {
                new AdminEntity
                {
                    Id = 1,
                    Name = "David",
                    Surname = "Glinth",
                    DateOfBirth = new DateTime(1999,4,16),
                    Email = "admin1@gmail.com",
                    Password = "admin1"
                },
                new AdminEntity
                {
                    Id = 2,
                    Name = "Lora",
                    Surname = "Linder",
                    DateOfBirth = new DateTime(1999,5,15),
                    Email = "admin2@gmail.com",
                    Password = "admin2"
                },
                new AdminEntity
                {
                    Id = 3,
                    Name = "Test",
                    Surname = "Test",
                    DateOfBirth = new DateTime(1999,5,15),
                    Email = "a1",
                    Password = "a1"
                }
            };
        }
    }
}
