using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models.Domain
{
public class Categoria
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "El campo Nombre es obligatorio.")]
    public string Nombre { get; set; } = string.Empty; 

    public virtual ICollection<Libro> LibroRelationList { get; set; } = new List<Libro>(); 

    public virtual ICollection<LibroCategoria> LibroCategoriaRelationList { get; set; } = new List<LibroCategoria>();
}
}
