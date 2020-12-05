using System;
using System.Collections.Generic;
using System.Text;
using Backend.Core.Entities;
using Backend.Core.Repository;
using Backend.Core.Services;

namespace Backend.Service.Services
{
    public class PersonService : Service<Person> , IPersonService
    {
        public PersonService(IRepository<Person> repository) : base(repository)
        {
        }
    }
}
