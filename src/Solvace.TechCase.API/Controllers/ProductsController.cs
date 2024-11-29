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
    //          1 - Perda de Consist�ncia: Ocorre porque cada inst�ncia tem/mant�m sua pr�pria vers�o dos dados.
    //          2 - Dificuldade de sincroniza��o: A manipula��o de uma inst�ncia n�o propaga para outra.
    //          3 - Problema em Reboots e implanta~��es: Cada inst�ncia cria uma nova lista na mem�ria perdendo as informa��es
    // Solu��o:
    //          Para garantir a consist�ncia e sincronismo dos dados � necess�rio remover os dados est�tico e persistir no banco
    //          para que as inst�ncias tenham somente uma base de consulta.
    //          Refatorar a controller no intuito de trazer para melhores pr�tica com uso de interface, services, inje��o de depend�ncia
    //          DDD dando a cada parte sua responsabilidade
    // Benef�cio:
    //          Modularidade, Flexibilidade e Reutiliza��o
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
