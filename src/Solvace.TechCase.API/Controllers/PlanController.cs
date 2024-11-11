
using Microsoft.AspNetCore.Mvc;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;
using Solvace.TechCase.Services;

namespace Solvace.TechCase.API.Controllers;


#region QUESTION 1
// TYPE YOUR RESPONSE HERE: 
#endregion


[ApiController]
[Route("api/v1/[controller]")]
public class PlanController : ControllerBase
{
    private readonly ActionPlanService _actionPlanService;
    public PlanController()
    {
        _actionPlanService = new ActionPlanService();
    }

    [HttpPost("create")]
    public async Task<ActionResult<ActionPlanDto>> Create([FromBody] CreateActionPlan actionPlan)
    {
        var result = await _actionPlanService.Create(actionPlan);
        return Created($"/api/actionplans/{result.Id}", result);
    }

}
