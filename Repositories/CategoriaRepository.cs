using ApiCatalogoProdutos.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiCatalogoProdutos.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AppDbContext _context;
        public CategoriaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categoria>> Get()
        {
            return await _context.Categorias.ToListAsync();
        }

        public async Task<Categoria> Get(int Id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(categoria => categoria.Id == Id);

        }

        public async Task<Categoria> Create(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<bool> Delete(int id)
        {
           
           var produtoCategoria = _context.Produtos.FirstOrDefaultAsync(p => p.CategoriaId == id);
           

            if (produtoCategoria == null)
            {
                var categoria = _context.Categorias.FirstOrDefault(c => c.Id == id);
                _context.Remove(categoria);
                await _context.SaveChangesAsync();
                return true;
            } 
            return false;
            

        }

        public async Task Update(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        
    }
}
