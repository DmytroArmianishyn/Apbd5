using Apbd5.Dto;
using Apbd5.Models;
using Apbd5.Service;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("/api/animals")]
    public IActionResult GetAnimals()
    {
        var animals = animalService.GetAnimals(_configuration);
        return Ok(animals);
    }
    [HttpGet("/api/animals/{sort}")]
    public IActionResult GetAnimalsbySort(String sort)
    {
        var animals = animalService.GetAnimalsort(_configuration,sort);
        return Ok(animals);
    }

    [HttpPost("/api/animals")]
    public IActionResult Postanimal(Animal animal)
    {
   animalService.Postanimal(_configuration, animal);
       return Created();
    }

    [HttpPut("/api/animals")]
    public IActionResult Putanimal(int id, DtoAnimalNoID animalNoId)
    {
        animalService.PutAnimal(_configuration,id,animalNoId);


        return Created();
    }
    [HttpDelete("/api/animals")]
    public IActionResult Deleteanimal(int id)
    {
        animalService.DeleteAnimal(_configuration,id);


        return Created();
    }
    
    
    
}