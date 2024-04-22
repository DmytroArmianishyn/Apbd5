using Apbd5.Models;
using Npgsql;

namespace Apbd5.Service;

public class AnimalService
{

    public List<Animal> GetAnimals(IConfiguration _configuration)
    {
        Console.WriteLine(1);
        List<Animal> animals = new List<Animal>();
        var conn = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        Console.WriteLine(1);
        NpgsqlCommand command = new NpgsqlCommand();
        Console.WriteLine(1);
        command.Connection = new NpgsqlConnection();
        Console.WriteLine(1);
        command.CommandText = "SELECT * from Animal";
        Console.WriteLine(2);
       var reader = command.ExecuteReader();
        Console.WriteLine(1);

        while (reader.Read())
        {
            animals.Add(new Animal(
                id: reader.GetInt32(0), 
                name: reader.GetString(1), 
                description: reader.GetString(2), 
                category: reader.GetString(3), 
                area: reader.GetInt32(4)
            ));
            Console.WriteLine(1);
        }
        Console.WriteLine(animals);
        return animals;
    }
    
    
    
}