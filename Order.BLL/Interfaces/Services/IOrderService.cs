using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
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
        Task<OrderResponse> GetByIdAsync(int id);
        Task AddAsync(OrderRequest request);
        Task UpdateAsync(OrderRequest request);
        Task DeleteAsync(int id);
    }
}
