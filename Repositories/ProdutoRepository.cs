using ApiCatalogoProdutos.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        public readonly AppDbContext _context;
        public ProdutoRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Produto> Create(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
            return produto;
        }

        public async Task Delete(int Id)
        {
                     
            var produto = await _context.Produtos.FirstOrDefaultAsync(produto => produto.Id == Id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            
        }

        public async Task<IEnumerable<Produto>> Get()
        {
            return await _context.Produtos.ToListAsync();
            
        }

        public async Task<Produto> Get(int Id)
        {
            return await _context.Produtos.FirstOrDefaultAsync(produto => produto.Id == Id);
            
        }

        public async Task Update(Produto produto)
        {
             _context.Entry(produto).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }
    }
}
