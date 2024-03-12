using AppStore.Repositories.Abstract;
using AppStore.Models.Domain;

namespace AppStore.Repositories.Implementation;

public class CategoriaService : ICategoriaService
{
    private readonly DatabaseContext context;

    public CategoriaService(DatabaseContext context)
    {
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public IQueryable<Categoria> List()
    {
        return context.Categorias!.AsQueryable();
    }

    public bool Add(Categoria categoria)
    {
        try
        {
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public Categoria GetById(int id)
    {
        return context.Categorias!.Find(id)!;
    }

    public bool Update(Categoria categoria)
    {
        try
        {
            var existingCategoria = GetById(categoria.Id);
            if (existingCategoria != null)
            {
                existingCategoria.Nombre = categoria.Nombre;

                context.SaveChanges();
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool Delete(int id)
    {
        try
        {
            var categoria = GetById(id);
            if (categoria is null || context is null)
            {
                return false;
            }

            var libroCategorias = context.LibroCategorias?.Where(a => a.CategoriaId == categoria.Id);
            context.LibroCategorias?.RemoveRange(libroCategorias ?? Enumerable.Empty<LibroCategoria>());

            context.Categorias?.Remove(categoria);
            context.SaveChanges();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

}