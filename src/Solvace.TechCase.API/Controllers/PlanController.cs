
using Microsoft.AspNetCore.Mvc;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Interfaces;
using Solvace.TechCase.Domain.Utilities;

namespace Solvace.TechCase.API.Controllers;


#region QUESTION 1
// TYPE YOUR RESPONSE HERE: 
// O conceito SOLID violado é o princípio de inversão de dependência, que se refere à necessidade de o controlador
// depender de uma abstração (ex interface) em vez de uma implementação concreta do serviço.
// Problema:    No código a PlanController está dependendo diretamente da implementação concreta do ActionPlanService
//              que está sendo criado uma nova instância no construtor oque impede a reutilização do código,
//              ocasiona pouca ou nenhuma flexibilidade além de dificultar a troca do ActionPlanService
//              por uma implementação diferente ou mock para testes básicos além de não usar a injeção de dependência
//              para evitar o acoplamento direto entre as classes.
// Solução:     Desenvolvi e apliquei a injeção de dependência para delegar as responsabilidades de gerênciamento ao 
//              framework que passa a depender de uma interface (contrato)
// Benefício:   Modularidade, Flexibilidade e Reutilização
#endregion


[ApiController]
[Route("api/v1/[controller]")]
public class PlanController : ControllerBase
{
    private readonly IActionPlanService _actionPlanService;
    public PlanController(IActionPlanService actionPlanService)
    {
        _actionPlanService = actionPlanService;
    }

    [HttpPost("create")]
    public async Task<ActionResult<ActionPlanDto>> Create([FromBody] CreateActionPlan actionPlan)
    {
        var result = await _actionPlanService.CreateAsync(actionPlan);
        return Created($"/api/actionplans/{result.Id}", result);
    }

    [HttpPost("end/{id}")]
    public async Task<ActionResult<ActionPlanDto>> EndActionPlan(int id)
    {
        var result = await _actionPlanService.EndActionPlanAsync(id);
        return Ok(result);
    }

    [HttpPut("update/{id}")]
    public async Task<ActionResult<ActionPlanDto>> UpdateActionPlan(int id, [FromBody] UpdateActionPlanDto updateDto)
    {
        var result = await _actionPlanService.UpdateActionPlanAsync(id, updateDto);
        return Ok(result);
    }

    [HttpPost("deactivate/{id}")]
    public async Task<ActionResult<ActionPlanDto>> DeactivateActionPlan(int id)
    {
        var result = await _actionPlanService.DeactivateActionPlanAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActionPlanDto>> GetActionPlanById(int id)
    {
        var result = await _actionPlanService.GetActionPlanByIdAsync(id);
        return Ok(result);
    }

    [HttpGet("all")]
    public async Task<ActionResult<PaginatedList<ActionPlanDto>>> GetAllActionPlans([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var result = await _actionPlanService.GetAllActionPlansAsync(pageNumber, pageSize);
        return Ok(result);
    }
}
