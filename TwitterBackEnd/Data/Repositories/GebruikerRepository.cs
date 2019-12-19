using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterBackEnd.Models.Domein;

namespace TwitterBackEnd.Data.Repositories
{
    public class GebruikerRepository : IGebruikerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public GebruikerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<Gebruiker> GeefGebruikerMetId(string gebruikerId)
        {
            return _dbContext.Gebruikers.
                Include(g => g.Tweets).
                ThenInclude(t => t.Retweets).
                ThenInclude(r => r.Gebruiker).
                Include(g => g.TussentabelKantVanGevolden).
                ThenInclude(gtt => gtt.Volger).
                Include(g => g.TussentabelKantVanVolgers).
                ThenInclude(gtt => gtt.Gevolgde).
                ThenInclude(g => g.Tweets).
                ThenInclude(t => t.Retweets).
                ThenInclude(r => r.Gebruiker).
                SingleOrDefaultAsync(g => g.Id == gebruikerId);
        }

        public void VerwijderGebruiker(Gebruiker gebruiker)
        {
            _dbContext.Gebruikers.Remove(gebruiker);
        }

        public void VoegGebruikerToe(Gebruiker gebruiker)
        {
            _dbContext.Gebruikers.Add(gebruiker);
        }

        public Task<List<Gebruiker>> GeefAlleGebruikers()
        {
            return _dbContext.Gebruikers.
                Include(g => g.Tweets).
                ThenInclude(t => t.Retweets).
                ThenInclude(r => r.Gebruiker).
                Include(g => g.TussentabelKantVanGevolden).
                ThenInclude(gtt => gtt.Volger).
                Include(g => g.TussentabelKantVanVolgers).
                ThenInclude(gtt => gtt.Gevolgde).
                ToListAsync();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public Task<Gebruiker> GeefGebruikerMetNaam(string gebruikersnaam)
        {
            return _dbContext.Gebruikers.
                Include(g => g.Tweets).
                ThenInclude(t => t.Retweets).
                ThenInclude(r => r.Gebruiker).
                Include(g => g.TussentabelKantVanGevolden).
                ThenInclude(gtt => gtt.Volger).
                Include(g => g.TussentabelKantVanVolgers).
                ThenInclude(gtt => gtt.Gevolgde).
                SingleOrDefaultAsync(g => g.UserName == gebruikersnaam);
        }

        public Task<Gebruiker> GeefGebruikerMetTweetId(int tweetId)
        {
            return _dbContext.Gebruikers.
                Include(g => g.Tweets).
                ThenInclude(t => t.Retweets).
                ThenInclude(r => r.Gebruiker).
                Include(g => g.TussentabelKantVanGevolden).
                ThenInclude(gtt => gtt.Volger).
                Include(g => g.TussentabelKantVanVolgers).
                ThenInclude(gtt => gtt.Gevolgde).
                SingleOrDefaultAsync(g => g.Tweets.Exists(t => t.TweetId == tweetId));
        }
    }
}
