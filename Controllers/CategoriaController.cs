using ApiCatalogoProdutos.DTO;
using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogoProdutos.Controllers;

[Route("v1/api/categorias")]
[ApiController]
public class CategoriaController : ControllerBase 
{
    private readonly ICategoriaRepository _context;
    private readonly IMapper _mapper;

    public CategoriaController(ICategoriaRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IEnumerable<CategoriaDTO>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10) 
    {
        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Min(50, Math.Max(1, pageSize)); // Limitando o tamanho máximo da página para 50, por exemplo.

        int offset = (pageNumber - 1) * pageSize;
        var categoria = await _context.Get();
        var categoriasDTO = _mapper.Map<IEnumerable<CategoriaDTO>>(categoria);
        var categoriaPaginados = categoriasDTO.Skip(offset).Take(pageSize);
        return categoriaPaginados;
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
