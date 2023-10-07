namespace ScreenSound3.Models
{
    public class Album
    {

    public Album (string nomealbum, string banda, float nota) 
        {
            NomeAlbum = nomealbum;
            Banda = banda; 
            Nota = nota; 
        }

     public int Id { get; set; }
     public string NomeAlbum { get; set; } 
     public string Banda { get; set; }
     public float Nota { get; set; }

      List<Musicas> Musicas { get; set; }
  
    }
}
