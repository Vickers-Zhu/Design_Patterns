using System;
using System.Collections.Generic;

namespace PictureProduction
{
    class Program
    {
        private readonly static Order[] orders =
        {
            new Order("circle", "red", "Hello", "spacing"),
            new Order("square", "green", "HelloWorld", "spacing"),
            new Order("triangle", "blue", "ChainIsBeauty", "spacing"),

            new Order("circle", "red", "Hello", "uppercase"),
            new Order("square", "green", "HelloWorld", "uppercase"),
            new Order("triangle", "blue", "ChainIsBeauty", "uppercase"),

            new Order("circle", "red", "Hello", "lowercase"),
            new Order("square", "yellow", "HelloWorld", "lowercase"),
            new Order("hash", "red", "ChainIsBeauty", "uppercase"),

            new Order("", "green", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "1234", "ChainIsBeauty", "uppercase"), //invalid order
            new Order("star", "green", null, "uppercase"), //invalid order
        };
        
        static void ProducePictures(IEnumerable<Order> orders, int mode)
        {
            IPicture picture = new Picture(null, null, null, mode);

            IMachine operation1 = new Painting(mode);
            IMachine operation2 = new Signing(mode);
            IMachine operation3 = new Framing(mode);

            operation1.SetNextChain(operation2);
            operation2.SetNextChain(operation3);

            foreach(Order order in orders)
            {
                if (order.Validate())
                    operation1.Handle(order, picture);
                else
                    Console.WriteLine("Error: Invalid order!");         
            }          
        }

        static void Main(string[] args)
        {
            Console.WriteLine("--- Simple Production Line ---");
            ProducePictures(orders, 1);

            Console.WriteLine();

            Console.WriteLine("--- Complex Production Line ---");
            ProducePictures(orders, 2);

            Console.ReadLine();
        }
    }
}
