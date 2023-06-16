using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SurveyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyApp.Persistence.EntityFramework.Mapping
{
    public class QuestionTypeMap : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.QuestionType)
                .HasForeignKey(x => x.QuestionTypeId);
        }
    }
}
