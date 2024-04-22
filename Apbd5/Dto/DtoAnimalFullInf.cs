namespace Apbd5.Dto;

public class DtoAnimalFullInf
{
    public int _id { get; set; }
    public string _name { get; set; }
    public string _description { get; set; }
    public string _category { get; set; }
    public int _area { get; set; }

    public DtoAnimalFullInf(int id, string name, string description, string category, int area)
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