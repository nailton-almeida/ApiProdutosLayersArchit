namespace CatalogoProdutosMinimalAPI.DTO;

public class ProdutoDTO
{
    public int ProdutoId { get; set; }
    public string? Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
   
}
