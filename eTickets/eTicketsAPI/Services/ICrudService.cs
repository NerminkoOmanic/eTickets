﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTicketsAPI.Services
{
    public interface ICrudService<T, TSearch , TInsert, TUpdate> : IReadService<T, TSearch> 
                where T : class where TSearch : class where TInsert : class where  TUpdate : class
    {
        T Insert(TInsert request);
        T Update(int id, TUpdate request);
        bool Remove(int id);
    }
} 