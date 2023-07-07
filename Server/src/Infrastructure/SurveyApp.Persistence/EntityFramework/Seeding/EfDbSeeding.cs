using SurveyApp.Domain.Entities;
using SurveyApp.Persistence.EntityFramework.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.EntityFramework.Seeding
{
    public static class EfDbSeeding
    {
        public static void SeedDatabase(SurveyAppContext context)
        {
            SeedUserIfNoExists(context);
            SeedQuestionTypeIfNoExists(context);
            SeedSurveyIfNoExists(context);
            SeedQuestionIfNoExists(context);
            SeedOptionIfNoExists(context);
        }
        private static void SeedUserIfNoExists(SurveyAppContext context)
        {
            if (!context.Users.Any())
            {
                //password:12345
                var passwordSalt = "8qjYoxBQ2SgvH7vcbDsPbus2YFpicja5cDbz9IL6hJIgS4gTgr5uq1ADDLy7GHsIEY+0otBju+h74HRuNuFnU25/HWCXOjdKqPlksusj7mNjAR6rk9K9Oy4s1wIySzCoy3xi205Kqhgb4NJ0UcryFCvT6G/9QDQ63A9NyNVQ8s0=";
                var passwordHash = "WMA4dhrMhW2ZW3+8wIlpzcew0pVATmgSq4WZ+tjmiOW1R09J5lKdcxR16RIT1ds44FjeYM0o+ksAeTzSX6aXZQ==";

                var users = new List<User>() {
                        new User
                        {
                            FirstName = "Abdurrahman",
                            LastName = "Varol",
                            Email = "abdurrahman@gmail.com",
                            UserName = "abdurrahman",
                            PasswordSalt = passwordSalt,
                            PasswordHash = passwordHash,
                            RefreshToken = Guid.NewGuid().ToString(),
                        }
                        };
                context.Users.AddRange(users);
                context.SaveChanges();
            }
        }
        private static void SeedQuestionTypeIfNoExists(SurveyAppContext context)
        {
            if (!context.QuestionTypes.Any())
            {
                var questionTypes = new List<QuestionType>
               {
                   new QuestionType
                   {
                       Name="Radio"
                   },
                   new QuestionType
                   {
                       Name="Check"
                   },
                   new QuestionType
                   {
                       Name="Range"
                   },
                   new QuestionType
                   {
                       Name="Text"
                   },
                   new QuestionType
                   {
                       Name="Text Area"
                   }
               };
                context.QuestionTypes.AddRange(questionTypes);
                context.SaveChanges();
            }
        }
        private static void SeedSurveyIfNoExists(SurveyAppContext context)
        {
            if (!context.Surveys.Any())
            {
                var user = context.Users.FirstOrDefault(p => p.UserName.Equals("abdurrahman"));
                var survey = new Survey
                {
                    CreatedAt = DateTime.Now,
                    CreatedById = user.Id,
                    Title = "Eğitim Sonu Anketi",
                };
                context.Surveys.Add(survey);
                context.SaveChanges();
            }
        }
        private static void SeedQuestionIfNoExists(SurveyAppContext context)
        {
            if (!context.Questions.Any())
            {
                var survey = context.Surveys.FirstOrDefault();
                var questions = new List<Question>
               {
                   new Question
                   {
                       QuestionTypeId = 1,
                       SurveyId = survey.Id,
                       Text = "Hangi bölümden mezunsunuz?"
                   },
                   new Question
                   {
                       QuestionTypeId = 2,
                       SurveyId = survey.Id,
                       Text = "Hangi programlama dillerini biliyorsunuz?"
                   },
                   new Question
                   {
                       QuestionTypeId = 5,
                       SurveyId = survey.Id,
                       Text = "Eğitmeninizin adı nedir?"
                   },
                   new Question
                   {
                       QuestionTypeId = 4,
                       SurveyId = survey.Id,
                       Text = "Eğitmen hakkında düşünceleriniz nedir?"
                   },
                   new Question
                   {
                       QuestionTypeId = 3,
                       SurveyId = survey.Id,
                       Text = "Eğitmenden memnun kaldınız mı?"
                   }
               };
                context.Questions.AddRange(questions);
                context.SaveChanges();
            }
        }
        private static void SeedOptionIfNoExists(SurveyAppContext context)
        {
            if (!context.Options.Any())
            {
                var options = new List<Option>
                {
                    new Option
                    {
                        QuestionId = 1,
                        Text = "Bilgisayar Mühendisliği"
                    },
                    new Option
                    {
                        QuestionId = 1,
                        Text = "Makine Mühendisliği",
                    },
                    new Option
                    {
                        QuestionId = 1,
                        Text = "Elektrik Elektronik Mühendisliği",
                    },
                    new Option
                    {
                        QuestionId = 2,
                        Text = "C#",
                    },
                    new Option
                    {
                        QuestionId = 2,
                        Text = "Javascript",
                    },
                    new Option
                    {
                        QuestionId = 2,
                        Text = "Java",
                    },
                    new Option
                    {
                        QuestionId = 2,
                        Text = "Go",
                    },
                    new Option
                    {
                        QuestionId = 2,
                        Text = "Python",
                    }
                };
                options.AddRange( Enumerable.Range(0, 10).Select(x => new Option
                {
                    QuestionId = 5,
                    Text = $"{x}"
                }));

                context.Options.AddRange(options);
                context.SaveChanges();
            }
        }
    }
}
