using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TwitterBackEnd.Data.Mapping;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext<Gebruiker>
    {
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Tweet> Tweets { get; set; }
        public DbSet<GevolgdenEnVolgersTussentabel> GevolgdenEnVolgersTussentabel { get; set; }
        public DbSet<Retweet> Retweets { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new GevolgdenEnVolgersTussentabelConfiguration());
        }
    }
}
