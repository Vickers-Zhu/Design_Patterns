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
                    string picture = new string(LeftFrame.ToCharArray()[0], 2) +
                        Color + new string(RightFrame.ToCharArray()[0], 2);
                    picture = picture + " " + Text + " " + picture;
                    Console.WriteLine(picture);
                    break;
                case 2:
                    TestOperation();
                    if (Color == "" ^ operation == "spacing")
                    {
                        picture = new string(LeftFrame.ToCharArray()[0], 2) +
                            Color + new string(RightFrame.ToCharArray()[0], 2);
                    }
                    else if (Color == "" && operation == "spacing")
                    {
                        picture = new string(LeftFrame.ToCharArray()[0], 3) +
                            Color + new string(RightFrame.ToCharArray()[0], 3);
                    }
                    else
                    {
                        picture = new string(LeftFrame.ToCharArray()[0], 1) +
                            Color + new string(RightFrame.ToCharArray()[0], 1);
                    }
                    picture = picture + " " + Text + " " + picture;
                    Console.WriteLine(picture);
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
