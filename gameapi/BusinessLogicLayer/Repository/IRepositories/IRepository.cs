﻿using BusinessLogicLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repository.IRepositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        
    }
}
