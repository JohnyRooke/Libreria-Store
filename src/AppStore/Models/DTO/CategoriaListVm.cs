using System.Linq;
using AppStore.Models.Domain;

namespace AppStore.Models.DTO
{
    public class CategoriaListVm
    {
        public IQueryable<Categoria> CategoriaList { get; set; } = Enumerable.Empty<Categoria>().AsQueryable();
        public string Nombre { get; set; } = string.Empty;
    }
}
