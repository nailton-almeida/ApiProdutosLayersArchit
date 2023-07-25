using ApiCatalogoProdutos.Model;
using AutoMapper;

namespace CatalogoProdutosMinimalAPI.DTO.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Produto, ProdutoDTO>().ReverseMap();
    }
}
