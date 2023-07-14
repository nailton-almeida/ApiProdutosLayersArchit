using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers;

[Route("v1/api/categorias")]
[ApiController]
public class CategoriaController : ControllerBase 
{
    private readonly ICategoriaRepository _context;
    public CategoriaController(ICategoriaRepository context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Categoria>> Get() 
    {
        return await _context.Get();
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Categoria>> Get(int id) 
    { 
        return await _context.Get(id);
       
    }

    [HttpPost]
    public async Task<ActionResult<Categoria>> Post(Categoria categoria) 
    {

        return await _context.Create(categoria);
          
    }
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> Delete(int id) 
    {
        var categoriaRemover = await _context.Get(id);
       
        if (categoriaRemover != null && await _context.Delete(id))
        {
           return Ok("Produto Removido");
        }
        return BadRequest("Categoria inválida e não pode ser apagada no momento");
    }

    [HttpPut]
    public async Task<ActionResult> Update(Categoria categoria)
    {
        await _context.Update(categoria);
        return Ok("Categoria atualizada");
    }


}
