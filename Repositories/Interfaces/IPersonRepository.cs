﻿using BookReader.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookReader.Repositories.Interfaces
{
    public interface IPersonRepository : IBaseRepository<Person>
    {


        Task<Person> FindbyUserId(int userId);



    }
}
