using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Entities;
using Backend.Core.Repository;
using Backend.Data.Context;

namespace Backend.Data.Repositories
{
    public class PersonRepository :Repository<Person> , IPersonRepository
    {
        public PersonRepository(AppDbContext context) : base(context)
        {
        }
    }
}
