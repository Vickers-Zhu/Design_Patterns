using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform
{
    abstract class Android
    {
        protected string PlatformName = "Android";
        protected string ObjectName { get; set; }
    }
    class AndroidButton : Android, IButton
    {
        public string Content { get; set; }

        public AndroidButton(string content)
        {
            ObjectName = "IButton";
            int length = content.Length < 8 ? content.Length : 8;
            this.Content = content.Substring(0, length);
            Console.WriteLine($"{PlatformName}{ObjectName} created");
        }

        public void ButtonPressed()
        {
            Console.WriteLine($"Sweet {Content}!");
        }

        public void DrawContent()
        {
            Console.WriteLine(Content);
        }
    }

    class AndroidTextBox : Android, ITextBox
    {
        public string Content { get; set; }

        public AndroidTextBox(string content)
        {
            ObjectName = "ITextBox";
            content.Reverse();
            this.Content = content;
            Console.WriteLine($"{PlatformName}{ObjectName} created");
        }

        public void DrawContent()
        {
            Console.WriteLine(Content);
        }
    }

    class AndroidGrid : Android, IGrid
    {
        List<IButton> buttons;
        List<ITextBox> textBoxes;

        public AndroidGrid()
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
            return null;
        }
    }
}
