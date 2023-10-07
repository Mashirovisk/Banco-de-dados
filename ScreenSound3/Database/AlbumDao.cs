using Microsoft.Data.Sqlite;
using ScreenSound3.Models;
using System.Net.Mail;

namespace ScreenSound3.Database;

public class AlbumDao
{

    private readonly SqliteConnection _connection;
    private object _connectionFactory;

    public AlbumDao(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public void CadastrarAlbum(Album album)
    {
        const string sql = "insert into Album (nome_album, banda, nota) values (@album, @banda, @nota)";
        var stmt = new SqliteCommand(sql, _connection);
        stmt.Parameters.Add(new SqliteParameter("@album", album.NomeAlbum));
        stmt.Parameters.Add(new SqliteParameter("@banda", album.Banda));
        stmt.Parameters.Add(new SqliteParameter("@nota", album.Nota));
        

        stmt.ExecuteNonQuery();
    }

    public List<Album> PegarTudo()
    {
        const string sql = "select * from Album";
        var stmt = new SqliteCommand(sql, _connection);
        var rs = stmt.ExecuteReader();
        var Albums = new List<Album>();
        while (rs.Read())
        {
            var idAlbum = Convert.ToInt32(rs["id"]);
            var nomealbum = rs["nome_album"].ToString();
            var banda = rs["banda"].ToString(); 
            var nota = Convert.ToInt32(rs["nota"]);

            var album = new Album (nomealbum, banda, nota)
            {
                Id = idAlbum
            };
            Albums.Add(album);
        }
        return Albums;
       
    }



    public void DeletarAlbum(int id)
    {
        const string sql = "delete from Album where id =@id";
        var stmt = new SqliteCommand(sql, _connection);
        stmt.Parameters.Add(new SqliteParameter("@id", id));


        stmt.ExecuteNonQuery();
    }


    public void AtualizarAlbum(Album album)
    {
        const string sql = "update Album set nome_album = @nome, banda = @banda, nota = @nota where id =@id  ";
        var stmt = new SqliteCommand(sql, _connection);
        stmt.Parameters.Add(new SqliteParameter("@id", album.Id));
        stmt.Parameters.Add(new SqliteParameter("@nome", album.NomeAlbum));
        stmt.Parameters.Add(new SqliteParameter("@banda", album.Banda));
        stmt.Parameters.Add(new SqliteParameter("@nota", album.Nota));
        
        stmt.ExecuteNonQuery();
    }
}









