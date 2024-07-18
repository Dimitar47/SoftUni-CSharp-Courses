namespace CinemaApp.Models
{
    public class CinemaModel
    {
        public CinemaModel(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Address { get; set; } = null!;
    }
}
