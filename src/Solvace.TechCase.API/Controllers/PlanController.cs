
using Microsoft.AspNetCore.Mvc;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Domain.Interfaces;
using Solvace.TechCase.Domain.Utilities;

namespace Solvace.TechCase.API.Controllers;


#region QUESTION 1
// TYPE YOUR RESPONSE HERE: 
// O conceito SOLID violado � o princ�pio de invers�o de depend�ncia, que se refere � necessidade de o controlador
// depender de uma abstra��o (ex interface) em vez de uma implementa��o concreta do servi�o.
// Problema:    No c�digo a PlanController est� dependendo diretamente da implementa��o concreta do ActionPlanService
//              que est� sendo criado uma nova inst�ncia no construtor oque impede a reutiliza��o do c�digo,
//              ocasiona pouca ou nenhuma flexibilidade al�m de dificultar a troca do ActionPlanService
//              por uma implementa��o diferente ou mock para testes b�sicos al�m de n�o usar a inje��o de depend�ncia
//              para evitar o acoplamento direto entre as classes.
// Solu��o:     Desenvolvi e apliquei a inje��o de depend�ncia para delegar as responsabilidades de ger�nciamento ao 
//              framework que passa a depender de uma interface (contrato)
// Benef�cio:   Modularidade, Flexibilidade e Reutiliza��o
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
