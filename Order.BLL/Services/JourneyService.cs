using AutoMapper;
using Order.BLL.DTO.Requests;
using Order.BLL.DTO.Responses;
using Order.BLL.Interfaces.Services;
using Order.DAL.Entities;
using Order.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.BLL.Services
{
    public class JourneyService : IJourneyService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public JourneyService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<JourneyResponse>> GetAsync()
        {
            var journeys = await _unitOfWork.JourneyRepository.Get();
            return journeys.Select(_mapper.Map<Journey, JourneyResponse>);
        }

        public Task<IEnumerable<JourneyResponse>> GetDetailAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<JourneyResponse> GetByIdAsync(int id)
        {
            var journey = await _unitOfWork.JourneyRepository.FindById(id);
            return _mapper.Map<Journey, JourneyResponse>(journey);
        }

        public async Task<JourneyResponse> GetByIdDetailAsync(int id)
        {
            var journey = await _unitOfWork.JourneyRepository.GetDetail(id);
            return _mapper.Map<Journey, JourneyResponse>(journey);
        }


        public async Task<JourneyResponse> AddAsync(JourneyRequest request)
        {
            var journey = _mapper.Map<JourneyRequest, Journey>(request);
            await _unitOfWork.JourneyRepository.Create(journey);
            await _unitOfWork.SaveChangesAsync();
            return _mapper.Map<Journey, JourneyResponse>(journey);
        }

        public async Task UpdateAsync(JourneyRequest request)
        {
            var journey = _mapper.Map<JourneyRequest, Journey>(request);
            await _unitOfWork.JourneyRepository.Update(journey);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.JourneyRepository.Remove(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
