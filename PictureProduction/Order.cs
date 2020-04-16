using System.Text.RegularExpressions;

namespace PictureProduction
{
    class Order
    {
        public string Shape { get; private set; }
        public string Color { get; private set; }
        public string Text { get; private set; }
        public string Operation { get; private set; }

        public Order(string shape, string color, string text, string operation)
        {
            Shape = shape;
            Color = color;
            Text = text;
            Operation = operation;
        }

        public bool Validate()
        {
            if (Shape != null && Color != null && Text != null && Operation != null &&
                Shape != "" && Color != "" && Text != "" && Operation != "" &&
                Regex.IsMatch(Shape, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(Color, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(Text, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(Operation, @"^[a-zA-Z]+$"))
                return true;
            else return false;
        }
    }
}
