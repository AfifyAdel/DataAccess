﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<long> Insert(User user);
        void Update(User user);
        void Delete(long id);
    }
}
