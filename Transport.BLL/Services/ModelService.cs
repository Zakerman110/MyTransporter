using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Transport.BLL.DTO.Request;
using Transport.BLL.DTO.Response;
using Transport.BLL.Interfaces.Services;
using Transport.DAL.Entities;
using Transport.DAL.Interfaces;

namespace Transport.BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public ModelService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ModelResponse>> GetAsync()
        {
            IEnumerable<Model> models = await _unitOfWork.ModelRepository.GetAllAsync();
            return models.Select(_mapper.Map<Model, ModelResponse>);
        }

        public async Task<IEnumerable<ModelMakeResponse>> GetDetailAsync()
        {
            IEnumerable<Model> models = await _unitOfWork.ModelRepository.GetAllDetailAsync();
            return models.Select(_mapper.Map<Model, ModelMakeResponse>);
        }

        public async Task<ModelResponse> GetByIdAsync(int id)
        {
            Model model = await _unitOfWork.ModelRepository.GetAsync(id);
            return _mapper.Map<Model, ModelResponse>(model);
        }

        public async Task<ModelMakeResponse> GetByIdDetailAsync(int id)
        {
            Model model = await _unitOfWork.ModelRepository.GetDetailAsync(id);
            return _mapper.Map<Model, ModelMakeResponse>(model);
        }

        public async Task AddAsync(ModelRequest request)
        {
            var model = _mapper.Map<ModelRequest, Model>(request);
            await _unitOfWork.ModelRepository.AddAsync(model);
        }

        public async Task UpdateAsync(ModelRequest request)
        {
            var model = _mapper.Map<ModelRequest, Model>(request);
            await _unitOfWork.ModelRepository.UpdateAsync(model);
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.ModelRepository.DeleteAsync(id);
        }
    }
}
