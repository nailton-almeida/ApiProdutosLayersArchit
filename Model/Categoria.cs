using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiCatalogoProdutos.Model;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    [JsonIgnore]
    public int Id { get; set; }
    [Required]
    [StringLength(50)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(300)]
    public string? ImagemUrl { get; set; }
    
    [JsonIgnore]
    public ICollection<Produto> Produtos { get; set; }
}
