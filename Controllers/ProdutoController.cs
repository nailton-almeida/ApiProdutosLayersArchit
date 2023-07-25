using ApiCatalogoProdutos.Model;
using ApiCatalogoProdutos.Repositories;
using AutoMapper;
using CatalogoProdutosMinimalAPI.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ApiCatalogoProdutos.Controllers;

[Route("v1/api/produtos")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private readonly IProdutoRepository _context;
    private readonly IMapper _mapper;
    public ProdutoController(IProdutoRepository context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    [HttpGet]
     //public async Task<IEnumerable<ProdutoDTO>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
     public async Task<IEnumerable<ProdutoDTO>> Get([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {

        pageNumber = Math.Max(1, pageNumber);
        pageSize = Math.Min(50, Math.Max(1, pageSize)); // Limitando o tamanho máximo da página para 50, por exemplo.

        // Calcula o número de itens que devem ser pulados (offset) com base no número da página e no tamanho da página.

        int offset = (pageNumber - 1) * pageSize;

        var produto = await _context.Get();
        var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produto);
        var produtosPaginados = produtosDTO.Skip(offset).Take(pageSize);
         

        // Obtém os produtos paginados do repositório.
        //var produtosPaginados = await produto.Skip(offset).Take(pageSize);


        // Mapeia os objetos Produto para ProdutoDTO usando o _mapper.
        //var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produtosPaginados);



        return produtosPaginados;


        //var produto = await _context.Get();
        //var produtosDTO = _mapper.Map<IEnumerable<ProdutoDTO>>(produto);
        //return produtosDTO;
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProdutoDTO>> Get(int Id)
    {
        var produto = await _context.Get();
        var produtosDTO = _mapper.Map<ProdutoDTO>(produto);
        return produtosDTO;  

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
            return Ok("Produto Removido");
        }
        return BadRequest("ID Inválido");
    }

    [HttpPut]
    public async Task<ActionResult> Put(Produto produto)
    {
        
            await _context.Update(produto);
            return Ok("Produto Modificado");
        

    }
}
