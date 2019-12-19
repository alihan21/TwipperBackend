using System.Collections.Generic;
using System.Threading.Tasks;

namespace TwitterBackEnd.Models.Domein
{
    public interface IGebruikerRepository
    {
        void VoegGebruikerToe(Gebruiker gebruiker);
        void VerwijderGebruiker(Gebruiker gebruiker);
        //void UpdateGebruiker(Gebruiker gebruiker);
        Task<Gebruiker> GeefGebruikerMetId(string gebruikerId);
        Task<Gebruiker> GeefGebruikerMetNaam(string gebruikersnaam);
        Task<Gebruiker> GeefGebruikerMetTweetId(int tweetId);
        Task<List<Gebruiker>> GeefAlleGebruikers();
        void SaveChanges();
    }
}
