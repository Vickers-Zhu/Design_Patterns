using System;

namespace PictureProduction
{
    interface IPicture
    {
        string LeftFrame { get;}
        string RightFrame { get; }
        string Color { get; }
        string Text { get; }
        
        void Print();
    }

    class Picture : IPicture
    {
        private Tuple<string, string> shape;

        private string operation;

        public string LeftFrame { get {
                if (shape != null)
                    return shape.Item1.Trim();
                else return null;
            } }

        public string RightFrame { get {
                if (shape != null)
                    return shape.Item2.Trim();
                else return null;
            } }

        public string Color { get; private set; }

        public string Text { get; private set; }

        private int mode;

        public Picture(Tuple<string, string> shape, string Color, string Text, int mode)
        {
            this.shape = shape;
            this.Color = Color;
            this.Text = Text;
            this.mode = mode;
        }

        public void Print()
        {
            switch (mode)
            {
                case 1:
                    Console.Write(LeftFrame);
                    Console.Write(LeftFrame);
                    Console.Write(Color);
                    Console.Write(RightFrame);
                    Console.Write(RightFrame);
                    Console.Write(" " + Text + " ");
                    Console.Write(LeftFrame);
                    Console.Write(LeftFrame);
                    Console.Write(Color);
                    Console.Write(RightFrame);
                    Console.Write(RightFrame);
                    Console.WriteLine();
                    break;
                case 2:
                    TestOperation();
                    if (Color == "" ^ operation == "spacing")
                    {
                        Console.Write(LeftFrame);
                        Console.Write(LeftFrame);
                        Console.Write(Color);
                        Console.Write(RightFrame);
                        Console.Write(RightFrame);
                    }
                    else if (Color == "" && operation == "spacing")
                    {
                        Console.Write(LeftFrame);
                        Console.Write(LeftFrame);
                        Console.Write(LeftFrame);
                        Console.Write(Color);
                        Console.Write(RightFrame);
                        Console.Write(RightFrame);
                        Console.Write(RightFrame);
                    }
                    else
                    {
                        Console.Write(LeftFrame);
                        Console.Write(Color);
                        Console.Write(RightFrame);
                    }
                    Console.Write(" " + Text + " ");
                    if (Color == "" ^ operation == "spacing")
                    {
                        Console.Write(LeftFrame);
                        Console.Write(LeftFrame);
                        Console.Write(Color);
                        Console.Write(RightFrame);
                        Console.Write(RightFrame);
                    }
                    else if (Color == "" && operation == "spacing")
                    {
                        Console.Write(LeftFrame);
                        Console.Write(LeftFrame);
                        Console.Write(LeftFrame);
                        Console.Write(Color);
                        Console.Write(RightFrame);
                        Console.Write(RightFrame);
                        Console.Write(RightFrame);
                    }
                    else
                    {
                        Console.Write(LeftFrame);
                        Console.Write(Color);
                        Console.Write(RightFrame);
                    }
                    Console.WriteLine();
                    break;
            }
        }

        private void TestOperation()
        {
            bool isUpper = false;
            bool isLower = false;
            foreach (char c in Text)
            {
                isUpper = Char.IsUpper(c);
                isLower = Char.IsLower(c);
                if (c == ' ')
                {
                    operation = "spacing";
                    return;
                }
            }
            if (isUpper && !isLower)
            {
                operation = "uppercase";
                return;
            }
            if (isLower && !isUpper)
            {
                operation = "lowercase";
                return;
            }
        }
    }
}
