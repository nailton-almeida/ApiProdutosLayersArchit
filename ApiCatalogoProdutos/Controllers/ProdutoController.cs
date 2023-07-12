using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers;

[Route("v1/api/produtos")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _context;
    public ProdutoController(IProdutoRepository context)
    {
        _context = context;
    }

    [HttpGet]
     public async Task<IEnumerable<Produto>> Get()
    {
        return await _context.Get();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Produto>> Get(int Id)
    {
          
        return await _context.Get(Id);
    }

    [HttpPost]
    public async Task<ActionResult<Produto>> Post(Produto produto)
    {
        return await _context.Create(produto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id)
    {
        var produtoApagado= await _context.Get(id);
        if (produtoApagado != null)
        {
            await _context.Delete(produtoApagado.Id);
        }
        return BadRequest();
    }

    [HttpPut]
    public async Task<ActionResult> Put(Produto produto)
    {
        throw new NotImplementedException();
    }
}
