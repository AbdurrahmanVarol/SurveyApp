using AutoMapper;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Application.Mapping.AutoMapper
{
    public class DefaultMapper : Profile
    {
        public DefaultMapper()
        {
            CreateMap<Survey, SurveyResponse>();
            CreateMap<CreateSurveyRequest, Survey>();


            CreateMap<Option,OptionResponse>();

            CreateMap<Question, QuestionResponse>();    
            CreateMap<Question, QuestionDisplayResponse>();    
            CreateMap<CreateQuestionRequest, Question>()
                .ForMember(d=>d.Options,s=>s.MapFrom(m=>m.Options.Select(o=>new Option { Text = o}).ToList()));
            
            CreateMap<Answer, AnswerResponse>();
            CreateMap<CreateAnswerRequest, Answer>();


        }
    }
}
