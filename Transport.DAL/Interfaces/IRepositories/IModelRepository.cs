﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.DAL.Entities;
using Transport.DAL.Entities.Response;

namespace Transport.DAL.Interfaces.IRepositories
{
    public interface IModelRepository
    {
        Task<IEnumerable<Model>> GetAllAsync();

        Task<IEnumerable<MakeModelResponse>> GetAllDetailAsync();

        Task<Model> GetAsync(int Id);

        Task<int> AddAsync(Model entity);

        Task UpdateAsync(Model entity);

        Task DeleteAsync(Model entity);
    }
}
