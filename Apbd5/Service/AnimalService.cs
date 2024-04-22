using Apbd5.Dto;
using Apbd5.Models;
using Npgsql;

namespace Apbd5.Service;

public class AnimalService
{

    public List<DtoAnimalFullInf> GetAnimals(IConfiguration _configuration)
    {
        List<DtoAnimalFullInf> animals = new List<DtoAnimalFullInf>();
        var conn = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        NpgsqlCommand command = new NpgsqlCommand();
        command.Connection = conn;
        command.CommandText = "Select  * from animal  order by name asc  ;";
        try
        {  var reader = command.ExecuteReader();
            while (reader.Read())
            {
                animals.Add(new DtoAnimalFullInf(
                    id: reader.GetInt32(0), 
                    name: reader.GetString(1), 
                    description: reader.GetString(2), 
                    category: reader.GetString(3), 
                    area: reader.GetInt32(4)
                ));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return animals;
    }
    public List<DtoAnimalFullInf> GetAnimalsort(IConfiguration _configuration,string sort)
    {
        List<DtoAnimalFullInf> animals = new List<DtoAnimalFullInf>();
        var conn = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        NpgsqlCommand command = new NpgsqlCommand();
        command.Connection = conn;
        command.CommandText = "Select  * from animal  order by " + sort +" asc  ;";
        try
        {  var reader = command.ExecuteReader();
            while (reader.Read())
            {
                animals.Add(new DtoAnimalFullInf(
                    id: reader.GetInt32(0), 
                    name: reader.GetString(1), 
                    description: reader.GetString(2), 
                    category: reader.GetString(3), 
                    area: reader.GetInt32(4)
                ));
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        return animals;
    }

    public void Postanimal(IConfiguration _configuration, Animal animal)
    {
        List<DtoAnimalFullInf> animals = new List<DtoAnimalFullInf>();
        var conn = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        using (var command =
               new NpgsqlCommand("INSERT INTO Animal (id, name, description, category, area) VALUES (@i,@n,@d,@c,@a)",
                   conn))
        {
            command.Connection = conn;
            command.CommandText = "INSERT INTO Animal (id, name, description, category, area) VALUES (@i,@n,@d,@c,@a)";
            command.Parameters.AddWithValue("i", animal._id);
            command.Parameters.AddWithValue("n", animal._name);
            command.Parameters.AddWithValue("d", animal._description);
            command.Parameters.AddWithValue("c", animal._category);
            command.Parameters.AddWithValue("a", animal._area);
            int nRows = command.ExecuteNonQuery();

        }
    }

    public void PutAnimal(IConfiguration _configuration, int id, DtoAnimalNoID animal)
    {
        
        List<DtoAnimalFullInf> animals = new List<DtoAnimalFullInf>();
        var conn = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        using (var command = new NpgsqlCommand("UPDATE Animal SET name = @n, description = @d, category = @c, area = @a WHERE id = @i", conn))
        {
            command.Parameters.AddWithValue("n", animal._name);
            command.Parameters.AddWithValue("d", animal._description);
            command.Parameters.AddWithValue("c", animal._category);
            command.Parameters.AddWithValue("a", animal._area);
            command.Parameters.AddWithValue("i", id); // Додайте параметр для id
            int nRows = command.ExecuteNonQuery();
            Console.Out.WriteLine(String.Format("Number of rows updated={0}", nRows));
        }
    }

    public void DeleteAnimal(IConfiguration _configuration, int id)
    {
        List<DtoAnimalFullInf> animals = new List<DtoAnimalFullInf>();
        var conn = new NpgsqlConnection(_configuration.GetConnectionString("Default"));
        conn.Open();
        using (var command =
               new NpgsqlCommand(
                   "Delete From Animal where id = " + id, conn)) ;




    }
}