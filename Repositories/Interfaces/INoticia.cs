using api_noticia.Models;

namespace api_noticia.Repositories.Interfaces
{
    public interface INoticia
    {
        IEnumerable<Noticia> GetAll();

        Noticia? GetById(int id);

        int NewNoticia(Noticia noticia);

        int UpNoticia(Noticia noticia);

        int DeleteNoticia(int id);

    }
}
