using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponse>> GetAsync();
        Task<IEnumerable<OrderResponse>> GetCompleteAsync();
        Task<OrderResponse> GetByIdAsync(int id);
        Task<OrderResponse> GetByIdDetailAsync(int id);
        Task<IEnumerable<OrderResponse>> GetByVehicleId(int id);
        Task<IEnumerable<Vehicle>> GetVehiclesFreeOnDate(DateTime date);
        Task<IEnumerable<OrderResponse>> GetCompleteByUserId(string id);
        Task<OrderResponse> AddAsync(OrderRequest request);
        Task UpdateAsync(OrderEditRequest request);
        Task DeleteAsync(int id);
    }
}
