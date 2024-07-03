using System;
using System.Collections.Generic;
using Music_Game.Models;

namespace Music_Game.Services
{
    public class CardGame
    {
        public List<Card> Cards { get; private set; }

        public CardGame()
        {
            Cards = new List<Card>
            {
                new Card { SongId = "3n3Ppam7vgaVa1iaRUc9Lp", SongName = "Mr. Brightside", Artist = "The Killers", ReleaseYear = 2003 },
                new Card { SongId = "11dFghVXANMlKmJXsNCbNl", SongName = "Cut To The Feeling", Artist = "Carly Rae Jepsen", ReleaseYear = 2017 },
                new Card { SongId = "6rqhFgbbKwnb9MLmUQDhG6", SongName = "Speak To Me - 2011 Remastered Version", Artist = "Pink Floyd", ReleaseYear = 1973 },
                new Card { SongId = "7ouMYWpwJ422jRcDASZB7P", SongName = "Knights of Cydonia", Artist = "Muse", ReleaseYear = 2006 },
                new Card { SongId = "3ZmXcKR6BgL9YJ1DRHP2OS", SongName = "Bohemian Rhapsody", Artist = "Queen", ReleaseYear = 1975 },
                new Card { SongId = "2v1jVc7iKfJkfbwiYj7BI8", SongName = "Smells Like Teen Spirit", Artist = "Nirvana", ReleaseYear = 1991 },
                new Card { SongId = "4uLU6hMCjMI75M1A2tKUQC", SongName = "Billie Jean", Artist = "Michael Jackson", ReleaseYear = 1982 },
                new Card { SongId = "1OmcAT5Y8eg5bUPv9qJT4R", SongName = "Rolling in the Deep", Artist = "Adele", ReleaseYear = 2010 },
                new Card { SongId = "7IHOIqZUUInxjVkko181PB", SongName = "Shape of You", Artist = "Ed Sheeran", ReleaseYear = 2017 },
                new Card { SongId = "3Hvu1pq89D4R0lyPBoujSv", SongName = "Bad Guy", Artist = "Billie Eilish", ReleaseYear = 2019 },
                new Card { SongId = "0cqRj7pUJDkTCEsJkx8snD", SongName = "Blinding Lights", Artist = "The Weeknd", ReleaseYear = 2019 },
                new Card { SongId = "2Fxmhks0bxGSBdJ92vM42m", SongName = "Levitating", Artist = "Dua Lipa", ReleaseYear = 2020 },
                new Card { SongId = "1P17dC1amhFzptugyAO7Il", SongName = "Peaches", Artist = "Justin Bieber", ReleaseYear = 2021 },
                new Card { SongId = "5T8EDUDqKcs6OSOwEsfqG7", SongName = "Stay", Artist = "The Kid LAROI, Justin Bieber", ReleaseYear = 2021 },
                new Card { SongId = "2BgEsaKNfHUdlh97KmvFyo", SongName = "Industry Baby", Artist = "Lil Nas X, Jack Harlow", ReleaseYear = 2021 },
                new Card { SongId = "2AkcwMSweGbQu5qwXXpaQp", SongName = "Drivers License", Artist = "Olivia Rodrigo", ReleaseYear = 2021 },
                new Card { SongId = "3PfIrDoz19wz7qK7tYeu62", SongName = "Good 4 U", Artist = "Olivia Rodrigo", ReleaseYear = 2021 },
                new Card { SongId = "2h4cmbybqyEndFt5kWCcVv", SongName = "Montero (Call Me By Your Name)", Artist = "Lil Nas X", ReleaseYear = 2021 },
                new Card { SongId = "3faWZkR6j2g8sN6Usa15eS", SongName = "Butter", Artist = "BTS", ReleaseYear = 2021 },
                new Card { SongId = "5VnDkUNkLswPtWNk1atn9r", SongName = "Shivers", Artist = "Ed Sheeran", ReleaseYear = 2021 }
            };
        }
    }
}
