namespace Apbd5.Models;

public class Animal
{
    private int _id { get; set; }
    private string _name { get; set; }
    private string _description { get; set; }
    private string _category { get; set; }
    private int _area { get; set; }

    public Animal(int id, string name, string description, string category, int area)
    {
        this._id = id;
        this._name = name;
        this._description = description;
        this._category = category;
        this._area = area;
    }

    public override string ToString()
    {
        return $"id {_id} name {_name} description {_description} category {_category} area {_area}";
    }
}