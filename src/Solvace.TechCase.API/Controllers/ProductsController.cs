using Microsoft.AspNetCore.Mvc;
using Solvace.TechCase.Domain.Entities.Product;
using Solvace.TechCase.Domain.Entities.Product.Dtos;
using Solvace.TechCase.Domain.Interfaces;

namespace Solvace.TechCase.API.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly IProductServices _productService;
    public ProductsController(IProductServices productService)
    {
        _productService = productService;
    }
    #region QUESTION 4
    // TYPE YOUR RESPONSE HERE: 
    // 
    // Problema:
    //          1 - Perda de Consistência: Ocorre porque cada instância tem/mantém sua própria versão dos dados.
    //          2 - Dificuldade de sincronização: A manipulação de uma instância não propaga para outra.
    //          3 - Problema em Reboots e implanta~ções: Cada instância cria uma nova lista na memória perdendo as informações
    // Solução:
    //          Para garantir a consistência e sincronismo dos dados é necessário remover os dados estático e persistir no banco
    //          para que as instâncias tenham somente uma base de consulta.
    //          Refatorar a controller no intuito de trazer para melhores prática com uso de interface, services, injeção de dependência
    //          DDD dando a cada parte sua responsabilidade
    // Benefício:
    //          Modularidade, Flexibilidade e Reutilização
    #endregion

    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);      
        return Ok(product);
    }

    [HttpPost("create")]
    public async Task<ActionResult<Product>> Create(CreateProduct product)
    {
        var result = await _productService.Create(product);
        return Created($"/api/products/{result.Id}", result);
    }
}
