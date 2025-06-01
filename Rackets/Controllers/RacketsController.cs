using Microsoft.AspNetCore.Mvc;
using Rackets.Domain;
using Rackets.Domain.Model;

namespace Rackets.Controllers;

[ApiController]
[Route("[controller]")]
public class RacketsController : ControllerBase
{
    private readonly ILogger<RacketsController> _logger;
    private readonly IRacketsRepository _racketsRepository;

    public RacketsController(ILogger<RacketsController> logger, IRacketsRepository racketsRepository)
    {
        _logger = logger;
        _racketsRepository = racketsRepository;
    }

    [HttpGet]
    public List<Racket> Get()
    {
        _logger.LogInformation("Retrieving all Rackets");
        return _racketsRepository.GetRackets();
    }
}