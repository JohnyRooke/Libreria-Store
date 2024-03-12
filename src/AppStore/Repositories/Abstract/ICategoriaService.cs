using AppStore.Models.Domain;

namespace AppStore.Repositories.Abstract
{
    public interface ICategoriaService
    {
        IQueryable<Categoria> List();
        bool Add(Categoria categoria);
        Categoria GetById(int id);
        bool Update(Categoria categoria);
        bool Delete(int id);
    }
}
