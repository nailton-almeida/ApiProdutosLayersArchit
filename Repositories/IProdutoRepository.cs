using ApiCatalogoProdutos.Model;


namespace ApiCatalogoProdutos.Repositories;

public interface IProdutoRepository
{
    Task<IEnumerable<Produto>> Get();
    Task<Produto> Get(int Id);
    Task<Produto> Create(Produto produto);
    Task Update(Produto produto);
    Task Delete(int Id);
}
