using System.Runtime.CompilerServices;

namespace ScreenSound3.Models
{
    public class Musicas
    {
        public Musicas(string nomeMusicas, int tempo, string banda, int albumId)
        {
            NomeMusicas = nomeMusicas;
            Tempo = tempo;  
            Banda = banda;
            AlbumId = albumId;
        }
        public int Id { get; set; }
        public string NomeMusicas { get; set; }
        public int Tempo { get; set; }
        public string Banda { get; set; }

        public int AlbumId { get; set; }

        public Album? Album { get; set; }

    }
}

