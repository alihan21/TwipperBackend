using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TwitterBackEnd.Models.Domein
{
    public class Gebruiker : IdentityUser
    {
        [Column(TypeName = "nvarchar(50)")]
        public string VolledigeNaam { get; set; }
        public List<Tweet> Tweets { get; set; }
        public List<GevolgdenEnVolgersTussentabel> TussentabelKantVanVolgers { get; set; }
        public List<GevolgdenEnVolgersTussentabel> TussentabelKantVanGevolden { get; set; }


        public List<Gebruiker> Volgers
        {
            get => TussentabelKantVanGevolden.Where(gtt => gtt.Gevolgde.Id == this.Id).Select(gtt => gtt.Volger).ToList();
        }

        public List<Gebruiker> Gevolgden
        {
            get => TussentabelKantVanVolgers.Where(gtt => gtt.Volger.Id == this.Id).Select(gtt => gtt.Gevolgde).ToList();
        }

        public Gebruiker()
        {
            Tweets = new List<Tweet>();
        }

        public void VoegNieuweTweetToe(string tweetBeschrijving)
        {
            Tweets.Add(new Tweet() { Boodschap = tweetBeschrijving, TweetDatum = DateTime.UtcNow });
        }

        //public void VoegNieuweVolgerToe(Gebruiker volger)
        //{
        //    Volgerstt.Add(new GevolgdenEnVolgersTussentabel()
        //    {
        //        GevolgdeId = this.Id,
        //        Gevolgde = this,
        //        VolgerId = volger.Id,
        //        Volger = volger,
        //    });
        //}

        public void VoegNieuweGevolgdeToe(Gebruiker gevolgde){
            TussentabelKantVanVolgers.Add(new GevolgdenEnVolgersTussentabel()
            {
                GevolgdeId = gevolgde.Id,
                Gevolgde = gevolgde,
                VolgerId = this.Id,
                Volger = this,
            });
        }

        public List<object> GeefEnkelNodigeInfoVanBepaaldeLijstVanGebruikers(List<Gebruiker> gebruikers){
            List<object> lijst = new List<object>();

            gebruikers.ForEach(g => {
                lijst.Add(new { g.UserName, g.VolledigeNaam, g.Tweets});
            });

            return lijst;
        }
    }
}
