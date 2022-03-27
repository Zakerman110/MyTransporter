using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;

namespace Transport.BLL.Interfaces.Services
{
    public interface IModelService
    {
        Task<IEnumerable<ModelResponse>> GetAsync();
        Task<IEnumerable<ModelMakeResponse>> GetDetailAsync();
        Task<ModelResponse> GetByIdAsync(int id);
        Task<ModelMakeResponse> GetByIdDetailAsync(int id);
        Task AddAsync(ModelRequest request);
        Task UpdateAsync(ModelRequest request);
        Task DeleteAsync(int id);
    }
}
