using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Interfaces.Services
{
    public interface IJourneyService
    {
        Task<IEnumerable<JourneyResponse>> GetAsync();
        Task<JourneyResponse> GetByIdAsync(int id);
        Task AddAsync(JourneyRequest request);
        Task UpdateAsync(JourneyRequest request);
        Task DeleteAsync(int id);
    }
}
