﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockTracker.Context;
using StockTracker.Context.Interface;
using StockTracker.Model.Persons;
using StockTracker.Seed.Interface;

namespace StockTracker.Seed.Persons
{
    public class GenericPerson : IGeneric<Person>
    {
        public GenericPerson(){}

        public GenericPerson(IStockTrackerContext db)
        {
            db.Persons.AddRange(All());
            ((StockTrackerContext)db).SaveChanges();
        }

        public Person[] All()
        {
            return new[]
            {
                new Person
                {
                    Email = "test@test.co.za",
                    Mobile = "0846004321",
                    PersonId = 1,
                    PersonName = "TestName1",
                    PersonSurname = "TestSurname1",
                    WhatsApp = "0730521234"
                },
                new Person
                {
                    PersonId = 2,
                    Email = "secondmail@mail.co.za",
                    Mobile = "0843006543",
                    WhatsApp = "",
                    PersonName = "TestName2",
                    PersonSurname = "TestSurname2"
                },
                new Person
                {
                    PersonId = 3,
                    Email = "thenewthirdnumber@gmail.com",
                    Mobile = "0123456789",
                    WhatsApp = "",
                    PersonName = "Samuel",
                    PersonSurname = "Jackson"
                }
            };
        }

        public Person One()
        {
            return All()[0];
        }

        public Person One(int index)
        {
            return All()[index];
        }
    }
}
