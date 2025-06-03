using Microsoft.AspNetCore.Http.HttpResults;
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
    public Task<List<Racket>> Get()
    {
        logger.LogInformation("Retrieving all Rackets");
        return Task.FromResult(racketsRepository.GetRackets());
    }

    [HttpGet("/{id}")]
    [ProducesResponseType<Racket>(StatusCodes.Status200OK, "application/json")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public Results<Ok<Racket>, NotFound<ProblemDetails>> Get(string id)
    {
        var result = racketsRepository.GetRacket(id);
        return result != null ? TypedResults.Ok(result) : TypedResults.NotFound((ProblemDetails) this.NotFoundProblem("Racket not found").Value!);
    }
}