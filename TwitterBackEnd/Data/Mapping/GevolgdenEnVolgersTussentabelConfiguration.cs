using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data.Mapping
{
    public class GevolgdenEnVolgersTussentabelConfiguration : IEntityTypeConfiguration<GevolgdenEnVolgersTussentabel>
    {
        public void Configure(EntityTypeBuilder<GevolgdenEnVolgersTussentabel> builder)
        {
            builder.HasKey(b => new { b.VolgerId, b.GevolgdeId });

            builder.
                HasOne(b => b.Gevolgde).
                WithMany(g => g.TussentabelKantVanGevolden).
                HasForeignKey(b => b.GevolgdeId).
                OnDelete(DeleteBehavior.Restrict);

            builder.
                HasOne(b => b.Volger).
                WithMany(g=>g.TussentabelKantVanVolgers).
                HasForeignKey(b => b.VolgerId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
