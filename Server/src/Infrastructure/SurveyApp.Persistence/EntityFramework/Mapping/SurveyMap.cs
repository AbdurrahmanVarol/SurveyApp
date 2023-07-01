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
    public class SurveyMap : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()");

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.Survey)
                .HasForeignKey(x => x.SurveyId);

            builder.Navigation(p => p.Questions).AutoInclude();
            builder.Navigation(p => p.CreatedBy).AutoInclude();
        }
    }
}
