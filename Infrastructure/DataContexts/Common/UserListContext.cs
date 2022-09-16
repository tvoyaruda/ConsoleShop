using System;
using System.Collections.Generic;
using System.Text;
using Domain;

namespace Infrastructure
{
    public class UserListContext: ListContext<UserEntity>
    {
        public UserListContext()
        {
            ContextList = new List<UserEntity>
            {
                new CustomerEntity
                {
                    Id = 1,
                    Name = "Adam",
                    Surname = "Rokich",
                    DateOfBirth = new DateTime(1994,7,1),
                    Email = "1", //"user1@gmail.com"
                    Password = "1" //"user1"
                },
                new CustomerEntity
                {
                    Id = 2,
                    Name = "Anna",
                    Surname = "Konel",
                    DateOfBirth = new DateTime(1991,11,25),
                    Email = "user2@gmail.com",
                    Password = "user2"
                },
                new CustomerEntity
                {
                    Id = 3,
                    Name = "Bell",
                    Surname = "Myrow",
                    DateOfBirth = new DateTime(1996,10,11),
                    Email = "user3@gmail.com",
                    Password = "user3"
                },
                new CustomerEntity
                {
                    Id = 4,
                    Name = "Solar",
                    Surname = "Nisow",
                    DateOfBirth = new DateTime(1998,7,31),
                    Email = "user4@gmail.com",
                    Password = "user4"
                },
                new CustomerEntity
                {
                    Id = 5,
                    Name = "Mirta",
                    Surname = "Dalb",
                    DateOfBirth = new DateTime(1997,2,3),
                    Email = "user5@gmail.com",
                    Password = "user5"
                },
                new CustomerEntity
                {
                    Id = 6,
                    Name = "Viktor",
                    Surname = "Sterov",
                    DateOfBirth = new DateTime(1999,4,16),
                    Email = "user6@gmail.com",
                    Password = "user6"
                },
                new AdminEntity
                {
                    Id = 1,
                    Name = "David",
                    Surname = "Glinth",
                    DateOfBirth = new DateTime(1999,4,16),
                    Email = "admin1@gmail.com",
                    Password = "admin1",
                    Role = UserRoles.Admin
                },
                new AdminEntity
                {
                    Id = 2,
                    Name = "Lora",
                    Surname = "Linder",
                    DateOfBirth = new DateTime(1999,5,15),
                    Email = "admin2@gmail.com",
                    Password = "admin2",
                    Role = UserRoles.Admin
                },
                new AdminEntity
                {
                    Id = 3,
                    Name = "Test",
                    Surname = "Test",
                    DateOfBirth = new DateTime(1999,5,15),
                    Email = "a1",
                    Password = "a1",
                    Role = UserRoles.Admin
                }
            };
        }
    }
}
