﻿using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface IRouteResponse
    {
        Task<IEnumerable<RouteResponse>> GetAsync();
        Task<RouteResponse> GetByIdAsync(int id);
        Task AddAsync(RouteRequest request);
        Task UpdateAsync(RouteRequest request);
        Task DeleteAsync(int id);
    }
}