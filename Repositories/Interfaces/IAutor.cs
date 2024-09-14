using api_noticia.Models;

namespace api_noticia.Repositories.Interfaces
{
    public interface IAutor
    {
        IEnumerable<Autor> GetAll();
        Autor? GetById(int id);
        int InsertAutor(Autor autor);
        int UpAutor(Autor autor);
        int DeleteAutor(int id);
    }
}
