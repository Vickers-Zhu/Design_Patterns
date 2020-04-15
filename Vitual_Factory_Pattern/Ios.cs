using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform
{
    abstract class Ios
    {
        protected string PlatformName = "IOS";
        protected string ObjectName { get; set; }
    }
    class IosButton : Ios, IButton
    {
        public string Content { get; set; }

        public IosButton(string content)
        {
            ObjectName = "IButton";
            this.Content = content;
            Console.WriteLine($"{PlatformName}{ObjectName} created");
        }

        public void ButtonPressed()
        {
            Console.WriteLine($"IOS Button pressed, content - {Content}");
        }

        public void DrawContent()
        {
            Console.WriteLine(Content);
        }
    }

    class IosTextBox : Ios, ITextBox
    {
        public string Content { get; set; }

        public IosTextBox(string content)
        {
            ObjectName = "ITextBox";
            this.Content = content;
            Console.WriteLine($"{PlatformName}{ObjectName} created");
        }

        public void DrawContent()
        {
            Console.WriteLine(Content);
        }
    }

    class IosGrid : Ios, IGrid
    {
        List<IButton> buttons;
        List<ITextBox> textBoxes;

        public IosGrid()
        {
            ObjectName = "IGrid";
            buttons = new List<IButton>();
            textBoxes = new List<ITextBox>();
        }

        public void AddButton(IButton button)
        {
            buttons.Add(button);
        }

        public void AddTextBox(ITextBox textBox)
        {
            textBoxes.Add(textBox);
        }

        public IEnumerable<IButton> GetButtons()
        {
            return buttons;
        }

        public IEnumerable<ITextBox> GetTextBoxes()
        {
            return textBoxes;
        }
    }
}
