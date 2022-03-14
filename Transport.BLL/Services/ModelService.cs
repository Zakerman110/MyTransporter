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

        public ModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ModelResponse>> GetAsync()
        {
            IEnumerable<Model> models = await _unitOfWork.ModelRepository.GetAllAsync();
            List<ModelResponse> modelsResponse = new List<ModelResponse>();
            foreach (var model in models)
            {
                ModelResponse modelResponse = new ModelResponse();
                modelResponse.Id = model.Id;
                modelResponse.Name = model.Name;

                modelsResponse.Add(modelResponse);
            }
            return modelsResponse;
        }

        public async Task<IEnumerable<ModelMakeResponse>> GetDetailAsync()
        {
            IEnumerable<Model> models = await _unitOfWork.ModelRepository.GetAllDetailAsync();
            List<ModelMakeResponse> modelsResponse = new List<ModelMakeResponse>();
            foreach (var model in models)
            {
                ModelMakeResponse modelResponse = new ModelMakeResponse();
                modelResponse.Id = model.Id;
                modelResponse.Name = model.Name;
                //modelResponse.MakeId = model.MakeId;

                MakeResponse makeResponse = new MakeResponse();
                makeResponse.Id = model.Make.Id;
                makeResponse.Name = model.Make.Name;

                modelResponse.Make = makeResponse;

                modelsResponse.Add(modelResponse);
            }
            return modelsResponse;
        }

        public async Task<ModelResponse> GetByIdAsync(int id)
        {
            Model model = await _unitOfWork.ModelRepository.GetAsync(id);
            ModelResponse modelResponse = new ModelResponse();
            modelResponse.Id = model.Id;
            modelResponse.Name = model.Name;
            return modelResponse;
        }

        public async Task<ModelMakeResponse> GetByIdDetailAsync(int id)
        {
            Model model = await _unitOfWork.ModelRepository.GetDetailAsync(id);
            ModelMakeResponse modelResponse = new ModelMakeResponse();

            modelResponse.Id = model.Id;
            modelResponse.Name = model.Name;

            MakeResponse makeResponse = new MakeResponse();
            makeResponse.Id = model.Make.Id;
            makeResponse.Name = model.Make.Name;

            modelResponse.Make = makeResponse;

            return modelResponse;
        }

        public Task AddAsync(ModelRequest request)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ModelRequest request)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
