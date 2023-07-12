using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace ApiCatalogoProdutos.Model;

public class Categoria


{

    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }

    public ICollection<Produto> Produtos { get; set; }
}
