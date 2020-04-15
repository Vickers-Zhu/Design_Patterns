using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiPlatform.Interfaces;

namespace MultiPlatform
{
    abstract class Windows
    {
        protected string PlatformName = "Windows";
        protected string ObjectName { get; set; }
    }

    class WindowsButton : Windows, IButton
    {
        public string Content { get; set; }

        public WindowsButton(string content)
        {
            ObjectName = "IButton";
            this.Content = content.ToUpper();
            Console.WriteLine($"{PlatformName}{ObjectName} created");
        }

        public void ButtonPressed()
        {
            Console.WriteLine("Windows button pressed");
        }

        public void DrawContent()
        {
            Console.WriteLine(Content);
        }
    }

    class WindowsTextBox : Windows, ITextBox
    {
        public string Content { get; set; }

        public WindowsTextBox(string content)
        {
            ObjectName = "ITextBox";         
            this.Content = content.Substring(content.Length/2) + " by .Net Core";
            Console.WriteLine($"{PlatformName}{ObjectName} created");
        }

        public void DrawContent()
        {
            Console.WriteLine(Content);
        }
    }

    class WindowsGrid : Windows, IGrid
    {
        List<IButton> buttons;
        List<ITextBox> textBoxes;

        public WindowsGrid()
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
            List<IButton> getbuttons;
            buttons.Reverse();
            getbuttons = buttons;
            //buttons.Reverse();
            return getbuttons;          
        }

        public IEnumerable<ITextBox> GetTextBoxes()
        {
            List<ITextBox> getTextBoxes;
            textBoxes.Reverse(1, textBoxes.Count-1);
            getTextBoxes = textBoxes;
            //textBoxes.Reverse(1, textBoxes.Count-1);
            return getTextBoxes;         
        }      
    }
}
