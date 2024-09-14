using api_noticia.Models;
using api_noticia.Repositories.Interfaces;
using Dapper;
using System.Data.Common;
using System.Data.SqlClient;

namespace api_noticia.Repositories
{
    public class NoticiaRepository : INoticia
    {
        SqlConnection conexao;

        public NoticiaRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("conexao");
            conexao = new SqlConnection(connectionString);
        }
        public IEnumerable<Noticia> GetAll()
        {
            try
            {
                conexao.Open();
                return conexao.Query<Noticia>("SELECT * FROM Noticias");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao acessar o banco de dados: {ex.Message}");
                throw;
            }
            finally
            {
                conexao.Close();
            }
        }

        public Noticia? GetById(int id)
        {
            var sql = "SELECT * FROM Noticias WHERE Id = @Id";
            var parametros = new { Id = id };
            return conexao.QueryFirstOrDefault<Noticia>(sql, parametros);
        }

        public int NewNoticia(Noticia noticia)
        {
            var sql = "INSERT INTO Noticias (Titulo, Texto, Data, AutorId) " + "VALUES (@Titulo, @Texto, @Data, @AutorId)";
            var parametros = new
            {
                noticia.Titulo,
                noticia.Texto,
                noticia.Data,
                noticia.AutorId
            };

            return conexao.Execute(sql, parametros);
        }

        public int DeleteNoticia(int id)
        {
            var sql = "DELETE FROM Noticias WHERE Id = @Id";
            var parametros = new { id };
            return conexao.Execute(sql, parametros);
        }

        public int UpNoticia(Noticia noticia)
        {
            var sql = "UPDATE Noticias SET Titulo = @Titulo, Texto = @Texto, Data = @Data, AutorId = @AutorId WHERE Id = @Id";
            var parametros = new { noticia.Id, noticia.Titulo, noticia.Texto, noticia.Data, noticia.AutorId };

            return conexao.Execute(sql, parametros);
        }


    }

}
