using System;
using System.Text.RegularExpressions;

namespace PictureProduction
{
    interface IMachine
    {
        void Handle(Order order, IPicture picture);
        void SetNextChain(IMachine machine);
    }

    class Validation : IMachine
    {
        private IMachine nextMachine;

        private int mode;

        public Validation(int mode)
        {
            this.mode = mode;
        }

        public void Handle(Order order, IPicture picture)
        {
            if (order.Shape != null && order.Color != null && order.Text != null && order.Operation != null &&
                order.Shape != "" && order.Color != "" && order.Text != "" && order.Operation != "" &&
                Regex.IsMatch(order.Shape, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(order.Color, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(order.Text, @"^[a-zA-Z]+$") &&
                Regex.IsMatch(order.Operation, @"^[a-zA-Z]+$"))
                nextMachine.Handle(order, picture);
            else
                Console.WriteLine("Error: Invalid order!");
        }

        public void SetNextChain(IMachine machine)
        {
            this.nextMachine = machine;
        }
    }

    class Painting : IMachine
    {
        private IMachine nextMachine;

        private int mode;

        public Painting(int mode)
        {
            this.mode = mode;
        }

        public void Handle(Order order, IPicture picture)
        {
            switch (mode)
            {
                case 1:
                    if (order.Color == "red")
                        nextMachine.Handle(order, new Picture(null, order.Color, null, mode));
                    else
                        nextMachine.Handle(order, new Picture(null, "", null, mode));
                    break;
                case 2:
                    if (order.Color == "red" || order.Color == "green" || order.Color == "blue")
                        nextMachine.Handle(order, new Picture(null, order.Color, null, mode));
                    else
                        nextMachine.Handle(order, new Picture(null, "", null, mode));
                    break;
            }
        }

        public void SetNextChain(IMachine machine)
        {
            this.nextMachine = machine;
        }
    }

    class Signing : IMachine
    {
        private IMachine nextMachine;

        private int mode;

        public Signing(int mode)
        {
            this.mode = mode;
        }

        public void Handle(Order order, IPicture picture)
        {
            switch (mode)
            {
                case 1:
                    nextMachine.Handle(order, new Picture(null, picture.Color, order.Text, mode));
                    break;
                case 2:
                    string text = order.Text;
                    if (order.Operation == "uppercase")
                        text = order.Text.ToUpper();
                    if (order.Operation == "spacing")
                        text = Regex.Replace(order.Text, ".{1}", "$0 ").Trim();
                    nextMachine.Handle(order, new Picture(null, picture.Color, text, mode));
                    break;
            }
        }

        public void SetNextChain(IMachine machine)
        {
            this.nextMachine = machine;
        }
    }

    class Framing : IMachine
    {
        private IMachine nextMachine;

        private int mode;

        public Framing(int mode)
        {
            this.mode = mode;
        }

        public void Handle(Order order, IPicture picture)
        {
            Tuple<string, string> shape = null;
            switch (mode)
            {
                case 1:
                    shape = null;
                    if (picture.Color == null || picture.Text == null)
                    {
                        Console.WriteLine("Error: Cannot be paint without Color or Text!");
                        return;
                    }
                    if (order.Shape == "circle")
                        shape = new Tuple<string, string>("(", ")");
                    if (order.Shape == "square")
                        shape = new Tuple<string, string>("[", "]");
                    if (shape == null)
                    {
                        Console.WriteLine("Error: Cannot create picture!");
                        return;
                    }
                    nextMachine.Handle(order, new Picture(shape, picture.Color, picture.Text, mode));
                    break;
                case 2:
                    shape = null;
                    if (picture.Color == null || picture.Text == null)
                    {
                        Console.WriteLine("Error: Cannot be paint without Color or Text!");
                        return;
                    }
                    if (order.Shape == "circle")
                        shape = new Tuple<string, string>("(", ")");
                    if (order.Shape == "square")
                        shape = new Tuple<string, string>("[", "]");
                    if (order.Shape == "triangle")
                        shape = new Tuple<string, string>("<", ">");
                    if (shape == null)
                    {
                        Console.WriteLine("Error: Cannot create picture!");
                        return;
                    }
                    nextMachine.Handle(order, new Picture(shape, picture.Color, picture.Text, mode));
                    break;
            }
        }

        public void SetNextChain(IMachine machine)
        {
            this.nextMachine = machine;
        }
    }

    class Print : IMachine
    {
        IMachine nextMachine;
        private int mode;
        public Print(int mode)
        {
            this.mode = mode;
        }

        public void Handle(Order order, IPicture picture)
        {
            picture.Print();
        }

        public void SetNextChain(IMachine machine)
        {
            this.nextMachine = machine;
        }
    }
}
