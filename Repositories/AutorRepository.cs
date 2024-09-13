using api_noticia.Models;
using api_noticia.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace api_noticia.Repositories
{
    public class AutorRepository : IAutor
    {
        SqlConnection conexao;

        public AutorRepository(IConfiguration config)
        {
            var connectionString = config.GetConnectionString("conexao");
            conexao = new SqlConnection(connectionString);
        }
        public IEnumerable<Autor> GetAll()
        {
            try
            {
                conexao.Open();
                return conexao.Query<Autor>("SELECT * FROM Autor");
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

        public Autor? GetById(int id)
        {
            var sql = "SELECT * FROM Autor WHERE Id = @Id";
            var parametros = new { Id = id };
            return conexao.QueryFirstOrDefault<Autor>(sql, parametros);
        }

        public int InsertAutor(Autor autor)
        {
            var sql = "INSERT INTO Autor (Nome, Email) VALUES (@Nome, @Email)";
            var parametros = new { autor.Nome, autor.Email };
            return conexao.Execute(sql, parametros);
        }

        public int UpAutor(Autor autor)
        {
            var sql = "UPDATE Autor SET Nome = @Nome, Email = @Email WHERE Id = @Id";
            var parametros = new { autor.Id, autor.Nome, autor.Email };

            return conexao.Execute(sql, parametros);
        }

        public int DeleteAutor(int id)
        {
            var sql = "DELETE FROM Autor WHERE Id = @Id";
            var parametros = new { id };
            return conexao.Execute(sql, parametros);
        }
    }
}
