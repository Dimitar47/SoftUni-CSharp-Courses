using System.Text;

namespace Cars
{
    public class Seat : ICar
    {
        public string Model { get; set; }
        public string Color { get; set; }

        public Seat(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{Color} {this.GetType().Name} {Model}");
            stringBuilder.AppendLine($"{Start()}");
            stringBuilder.AppendLine($"{Stop()}");
            return stringBuilder.ToString().TrimEnd();
        }
    }
}
