using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Data
{
    public class CustomerListContext: ListContext<CustomerEntity>
    {
        public CustomerListContext()
        {
            DataList = new List<CustomerEntity>
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
            };
        }
    }
}
