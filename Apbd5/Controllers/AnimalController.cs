using Apbd5.Models;
using Apbd5.Service;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace Apbd5.Controllers;
[ApiController]
[Route("/api/animals")]
public class AnimalController : ControllerBase
{

    private readonly IConfiguration _configuration;
    private AnimalService animalService = new AnimalService();
    public AnimalController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet]
    public IActionResult GetAnimals()
    {
        var animals = animalService.GetAnimals(_configuration);
        return Ok(animals);


    }



}