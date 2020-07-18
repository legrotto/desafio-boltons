using DesafioBoltons.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioBoltons.Infa.Data.Mapping
{
    public class NFeMap : IEntityTypeConfiguration<NFeEntity>
    {
        public void Configure(EntityTypeBuilder<NFeEntity> builder)
        {
            builder.ToTable("NFE_DESAFIO");

            builder.HasKey(c => c.ID);

            builder.Property(c => c.ID)
               .HasColumnName("ID")
               .IsRequired()
               .ValueGeneratedOnAdd();

            builder.Property(c => c.Access_key)
                .HasColumnName("ACCESS_KEY")
                .IsRequired();

            builder.Property(c => c.Xml)
                .HasColumnName("XML_VALUE")
                .IsRequired();
        }
    }
}
