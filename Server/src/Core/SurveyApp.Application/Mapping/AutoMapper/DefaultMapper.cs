using AutoMapper;
using SurveyApp.Application.Dtos.Requests;
using SurveyApp.Application.Dtos.Responses;
using SurveyApp.Domain.ComplexTypes;
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
            CreateMap<Survey, SurveyResponse>()
                .ForMember(d => d.CreatedAt, s => s.MapFrom(m => DateTime.Parse(m.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"))));   
            CreateMap<Survey, SurveyDisplayForUpdateResponse>()
                .ForMember(d => d.CreatedAt, s => s.MapFrom(m => DateTime.Parse(m.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"))));
            CreateMap<Survey, SurveyDisplayResponse>()
                .ForMember(d => d.CreatedBy, s=>s.MapFrom(m=>$"{m.CreatedBy.FirstName} {m.CreatedBy.LastName}"))
                .ForMember(d => d.CreatedAt, s => s.MapFrom(m => DateTime.Parse(m.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"))));
            CreateMap<CreateSurveyRequest, Survey>();
            CreateMap<UpdateSurveyRequest, Survey>();


            CreateMap<Option, OptionResponse>();
            CreateMap<CreateOptionRequest, Option>();
            CreateMap<UpdateOptionRequest, Option>();

            CreateMap<Question, QuestionResponse>();
            CreateMap<Question, QuestionDisplayResponse>();
            CreateMap<CreateQuestionRequest, Question>()
                .ForMember(d => d.Options, s => s.MapFrom(m => m.Options.Select(o => new Option { Text = o }).ToList()));
            CreateMap<UpdateQuestionRequest, Question>();

            CreateMap<QuestionType, QuestionTypeResponse>();

            CreateMap<Answer, AnswerResponse>();
            CreateMap<CreateAnswerRequest, Answer>();

            CreateMap<CreateTextAnswerRequest, TextAnswer>();

            CreateMap<User, UserDisplayResponse>()
                .ForMember(d => d.FullName, s => s.MapFrom(m => $"{m.FirstName} {m.LastName}"));

            CreateMap<AnswerResult,AnswerResultResponse>();
            CreateMap<SurveyResult,SurveyResultResponse>();
            CreateMap<QuestionResult,QuestionResultResponse>();


        }
    }
}
