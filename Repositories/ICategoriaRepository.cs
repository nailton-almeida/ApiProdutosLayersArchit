using ApiCatalogoProdutos.Model;

namespace ApiCatalogoProdutos.Repositories
{
    public interface ICategoriaRepository
    {
        Task<IEnumerable<Categoria>> Get();
        Task<Categoria> Get(int id);

        Task<Categoria> Create(Categoria categoria);

        Task<bool> Delete(int id);
        Task Update(Categoria categoria);

    }
}
