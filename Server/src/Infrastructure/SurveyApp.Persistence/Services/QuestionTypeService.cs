using AutoMapper;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Application.Interfaces.Repositories;
using SurveyApp.Application.Interfaces.Services;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.Services
{
    public class QuestionTypeService : IQuestionTypeService
    {
        private readonly IQuestionTypeRepository _questionTypeRepository;
        private readonly IMapper _mapper;

        public QuestionTypeService(IQuestionTypeRepository questionTypeRepository, IMapper mapper)
        {
            _questionTypeRepository = questionTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<QuestionTypeResponse>> GetAll()
        {
            var types = await _questionTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<QuestionTypeResponse>>(types);
        }
    }
}
