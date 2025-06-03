using Microsoft.AspNetCore.Mvc;
using Rackets.Domain;
using Rackets.Domain.Model;
using Rackets.Extensions;

namespace Rackets.Controllers;

[ApiController]
[Route("[controller]")]
public class RacketsController(ILogger<RacketsController> logger, IRacketsRepository racketsRepository)
    : ControllerBase
{
    [HttpGet]
    [ProducesResponseType<List<Racket>>(StatusCodes.Status200OK, "application/json")]
    public ActionResult<List<Racket>> GetAllRackets()
    {
        logger.LogInformation("Retrieving all Rackets");
        return Ok(racketsRepository.GetRackets());
    }

    [HttpGet("{name}")]
    [ProducesResponseType<Racket>(StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<Racket> GetRacketByName(string name)
    {
        logger.LogInformation("Retrieving Racket {Name}", name);
        var result = racketsRepository.GetRacket(name);
        return result != null ? Ok(result) : NotFound((ProblemDetails) this.NotFoundProblem($"Racket {name} not found").Value!);
    }

    [HttpGet("search")]
    [ProducesResponseType<List<Racket>>(StatusCodes.Status200OK, "application/json")]
    public ActionResult<List<Racket>> SearchRackets(Brand? brand, Flex? flex, Balance? balance, WeightCategory? weightCategory)
    {
        logger.LogInformation("Searching Rackets with parameters [Brand: {}, Flex: {}, Balance: {}, Weight category: {}]",
            brand, flex, balance, weightCategory);
        return Ok(racketsRepository.SearchRackets(brand, flex, balance, weightCategory));
    }
}