using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data.Mapping
{
  public class ConnectionConfiguration : IEntityTypeConfiguration<Connection>
  {
    public void Configure(EntityTypeBuilder<Connection> builder)
    {
      builder.HasKey(b => new { b.FollowerId, b.FollowingId });

      builder.
          HasOne(b => b.Following).
          WithMany(g => g.FollowingList).
          HasForeignKey(b => b.FollowingId).
          OnDelete(DeleteBehavior.Restrict);

      builder.
          HasOne(b => b.Follower).
          WithMany(g => g.FollowersList).
          HasForeignKey(b => b.FollowerId).
          OnDelete(DeleteBehavior.Restrict);
    }
  }
}
