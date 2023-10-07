using Microsoft.Data.Sqlite;
using ScreenSound3.Models;
using System.Net.Mail;

namespace ScreenSound3.Database;

public class MusicasDao
{


    private readonly SqliteConnection _connection;

    public MusicasDao(ConnectionFactory connectionFactory)
    {
        _connection = connectionFactory.GetConnection();
    }

    public void CadastrarMusica(Musicas musicas)
    {
        const string sql = "insert into Musicas (nome, tempo, banda, albumid) values (@nome, @tempo, @banda, @albumid)";
        var stmt = new SqliteCommand(sql, _connection);
        stmt.Parameters.Add(new SqliteParameter("@nome", musicas.NomeMusicas));
        stmt.Parameters.Add(new SqliteParameter("@tempo", musicas.Tempo));
        stmt.Parameters.Add(new SqliteParameter("@banda", musicas.Banda));
        stmt.Parameters.Add(new SqliteParameter("@albumid", musicas.AlbumId));

        stmt.ExecuteNonQuery();
    }

    public List<Musicas> PegarMusicas() 
    {

        const string sql = "select * from Musicas";
        var stmt = new SqliteCommand(sql, _connection);
        var rs = stmt.ExecuteReader();
        var musicas = new List<Musicas>();
        while (rs.Read())
        {
            var idmusica = Convert.ToInt32(rs["id"]);
            var nomemusicas = rs["nome_musicas"].ToString();
            var banda = rs["banda"].ToString();
            var albumid = Convert.ToInt32(rs["albumid"]);
            var tempmusicas = Convert.ToInt32(rs["tempo_musicas"]);

            var Musicas = new Musicas(nomemusicas, tempmusicas, banda, albumid)
            {
                Id = idmusica
            };
            musicas.Add(Musicas);
            
         
           
        }
        return musicas;
    }


    public void DeletarMusicas(int id)
    {
        const string sql = "delete from Musicas where id =@id";
        var stmt = new SqliteCommand(sql, _connection);
        stmt.Parameters.Add(new SqliteParameter("@id", id));


        stmt.ExecuteNonQuery();
    }


   public void AtualizarMusicas(Musicas musicas)
    {
        const string sql = "update Musicas set nome = @nome, tempo = @tempo, banda = @banda,albumid = @albumid where id =@id  ";
        var stmt = new SqliteCommand(sql, _connection);
            stmt.Parameters.Add(new SqliteParameter("@id", musicas.Id));
            stmt.Parameters.Add(new SqliteParameter("@nome",musicas.NomeMusicas));
            stmt.Parameters.Add(new SqliteParameter("@tempo", musicas.Tempo));
            stmt.Parameters.Add(new SqliteParameter("@banda", musicas.Banda));
            stmt.Parameters.Add(new SqliteParameter("@albumid", musicas.AlbumId));
            stmt.ExecuteNonQuery();
    }


}